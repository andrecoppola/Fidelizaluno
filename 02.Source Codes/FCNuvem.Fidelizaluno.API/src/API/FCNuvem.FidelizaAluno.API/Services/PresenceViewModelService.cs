using FCNuvem.FidelizaAluno.API.ViewModels.Presence;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FCNuvem.FidelizaAluno.API.Services
{
    public class PresenceViewModelService : BaseViewModelService
    {
        public PresenceViewModelService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        { }

        private PresenceService PresenceService => GetService<PresenceService>();
        private IPresenceReadOnlyRepository PresenceReadOnlyRepository => GetService<IPresenceReadOnlyRepository>();
        private IPersonReadOnlyRepository PersonReadOnlyRepository => GetService<IPersonReadOnlyRepository>();
        private IClassReadOnlyRepository ClassReadOnlyRepository => GetService<IClassReadOnlyRepository>();
        private IStudentReadOnlyRepository StudentReadOnlyRepository => GetService<IStudentReadOnlyRepository>();


        internal void Save(PresenceCognitionViewModel vm)
        {
            var student = PersonReadOnlyRepository.Get(vm.PersonId);

            if (student != null)
            {
                var classEntity = ClassReadOnlyRepository.Get(vm.Date);
                var presence = PresenceReadOnlyRepository.Get(student.Id, classEntity.Id);

                if (presence != null && !presence.Presence)
                {
                    presence.Presence = true;
                }
                else
                {
                    presence = new PresenceEntity(0)
                    {
                        Presence = true,
                        IdClass = classEntity.Id,
                        IdStudent = student.Id
                    };
                }

                PresenceService.Save(presence);
            }
        }


        public void Save(PresenceListViewModel vm)
        {
            var entities = new List<PresenceEntity>();

            entities.AddRange(vm.Presences.Select(l => new PresenceEntity(0)
            {
                IdClass = vm.IdClass,
                IdStudent = l.IdStudent,
                Presence = l.Presence,
                Data = vm.Data
            }).ToList());


            PresenceService.Save(entities);
        }

        internal IEnumerable<PresenceViewModel> GetByClass(int IdClass, DateTime date)
        {
            IEnumerable<PresenceViewModel> vm;

            var entities = PresenceReadOnlyRepository.GetByClass(IdClass, date);

            vm = entities.Select(e => new PresenceViewModel
            {
                IdStudent = e.IdStudent,
                IdClass = e.IdClass,
                Student = e.Student.Person.Name,
                Data = e.Data,
                Presence = e.Presence
            });

            if (vm.Any())
                return vm;
            else
            {
                var students = StudentReadOnlyRepository.GetAllByClass(IdClass);
                return students.Distinct().Select(s => new PresenceViewModel
                {
                    IdStudent = s.Id,
                    Student = s.Person.Name,
                    Presence = false
                });
            }
        }

        internal IEnumerable<AbsentViewModel> GetAbsent(DateTime date, int? idPeriod, int? idProgram = null, int? IdClassRoom = null, int? idCampus = null)
        {
            var entities = PresenceReadOnlyRepository.GetAbsent(date, idPeriod, idProgram, IdClassRoom, idCampus);

            return entities.Distinct().Select(e => new AbsentViewModel
            {
                IdStudent = e.IdStudent,
                RA = e.Student.RA,
                Frequency = Calculetefrequency(e.Student.Presence.Where(q => q.Presence).Count(), e.Student.Presence.Count()),//e.Student.Frequency ?? 0,
                Name = e.Student.Person.Name,
                PhoneNumber = e.Student.Person.TelephoneCelular ?? e.Student.Person.TelephoneResidencial ?? "",
                PhotoUrl = e.Student.Person.UrlPicture
            }).Distinct();
        }

        private decimal Calculetefrequency(decimal quantity, decimal occurrence)
        {
            if (quantity == 0)
                return 0;

            return quantity / occurrence * 100;
        }
    }
}
