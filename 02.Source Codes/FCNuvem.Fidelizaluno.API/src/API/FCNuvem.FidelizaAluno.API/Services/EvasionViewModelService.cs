using FCNuvem.FidelizaAluno.API.ViewModels.Class;
using FCNuvem.FidelizaAluno.API.ViewModels.Period;
using FCNuvem.FidelizaAluno.API.ViewModels.Program;
using FCNuvem.FidelizaAluno.API.ViewModels.Student;
using FCNuvem.FidelizaAluno.Core.Interfaces.CloudServices.Email;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly.Filter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FCNuvem.FidelizaAluno.API.Services
{
    public class EvasaoViewModelService : BaseViewModelService
    {
        public EvasaoViewModelService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        private IStudentReadOnlyRepository StudentReadOnlyRepository => GetService<IStudentReadOnlyRepository>();
        private IEmailClient EmailClient => GetService<IEmailClient>();

        internal int GetAmount(int min, int max, int? idCampus)
        {
            var amount = StudentReadOnlyRepository.GetCountByEvasion(CreateEvasionFilter(min, max, idCampus));

            return amount;
        }

        private IProgramReadOnlyRepository ProgramReadOnlyRepository => GetService<IProgramReadOnlyRepository>();

        internal IEnumerable<StudentViewModel> GetStudents(int min, int max, int? idCampus, int? idClassRoom)
        {
            var entities = StudentReadOnlyRepository.GetAllByClassRoom(CreateEvasionFilter(min, max, idCampus, idClassRoom));

            var result = entities.Select(s => new StudentViewModel
            {
                Id = s.Id,
                Name = s.Person.Name,
                EvasionChance = s.EvasionScore,
                ReasonsEvasion = ((s.EvasionHistory != null && s.EvasionHistory.Count > 0) ?
                                    s.EvasionHistory.OrderByDescending(o => o.Date).FirstOrDefault()
                                                    .ReasonEvasion?.Where(t => t.ReasonPercentage > 0)
                                                    .OrderByDescending(r => r.ReasonPercentage)
                                                    .Select(r => new ReasonEvasionViewModel
                                                    {
                                                        Name = r.Reason.Name,
                                                        Percentage = r.ReasonPercentage
                                                    }) : null)
            });

            return result;
        }

        internal IEnumerable<ProgramViewModel> GetProgram(int min, int max, int? IdCampus)
        {
            var evasionFilter = CreateEvasionFilter(min, max, IdCampus);

            var entities = ProgramReadOnlyRepository.GetAllProgram(evasionFilter);

            var query = entities.Select(t => new ProgramViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Periods = t.ClassRoom.Where(c => (c.IdCampus == IdCampus || IdCampus == null) &&
                                                 (c.ClassRoomStudent.Any(s => s.Student.EvasionScore >= evasionFilter.IntervalMin && s.Student.EvasionScore < evasionFilter.IntervalMax)))
                                     .Select(u => u.Period)
                                     .Distinct()
                                     .Select(u => new PeriodViewModel
                                     {
                                         Id = u.Id,
                                         Description = u.Description,
                                         Class = t.ClassRoom.Where(c => (c.IdCampus == IdCampus || IdCampus == null) &&
                                                                             (c.ClassRoomStudent.Any(s => s.Student.EvasionScore >= evasionFilter.IntervalMin && s.Student.EvasionScore < evasionFilter.IntervalMax)) &&
                                                                             (c.IdPeriod == u.Id))
                                                                .Select(cvm => new ClassRoomViewModel
                                                                {
                                                                    Id = cvm.Id,
                                                                    Name = cvm.Name,
                                                                    Amount = cvm.ClassRoomStudent.Where(s => s.Student.EvasionScore >= evasionFilter.IntervalMin && s.Student.EvasionScore < evasionFilter.IntervalMax).Count()
                                                                })
                                     })
            });

            return query;
        }

        private static EvasionFilter CreateEvasionFilter(int min, int max, int? idCampus, int? idClassRoom = null)
        {
            decimal intervalMin = min / 100m, intervalMax = max / 100m;

            return new EvasionFilter
            {
                IntervalMin = intervalMin,
                IntervalMax = intervalMax,
                IdClassRoom = idClassRoom,
                IdCampus = idCampus
            };
        }
    }
}

