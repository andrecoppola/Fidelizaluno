using FCNuvem.FidelizaAluno.API.ViewModels.Student;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using FCNuvem.FidelizaAluno.Core.Enums;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly.Filter;
using FCNuvem.FidelizaAluno.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FCNuvem.FidelizaAluno.API.Services
{
    public class StudentViewModelService : BaseViewModelService
    {
        public StudentViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private StudentService StudentService => GetService<StudentService>();
        private IStudentReadOnlyRepository StudentReadOnlyRepository => GetService<IStudentReadOnlyRepository>();
        private IStudentRepository StudentRepository => GetService<IStudentRepository>();


        internal StudentViewModel GetStudent(int id)
        {
            var entity = StudentReadOnlyRepository.Get(id);
            var vm = new StudentViewModel();
            vm.Fill(entity);
            return vm;
        }

        internal IEnumerable<ListStudentViewModel> GetStudentByClassRoom(int idClassRoom)
        {
            var entities = StudentReadOnlyRepository.GetAllByClassRoom(idClassRoom);
            return entities.Select(l => new ListStudentViewModel
            {
                Id = l.Id,
                Name = l.Person.Name,
                EvasionChance = l.EvasionScore,
                MediaScore = l.MediaScore,
                ReasonEvasion = l.EvasionHistory.Select(i => i.ReasonEvasion.Select(j => j.Reason?.Name).LastOrDefault()).LastOrDefault(),
            Frequency = Calculetefrequency(l.Presence.Where(q => q.Presence).Count(), l.Presence.Count()),
            }).OrderBy(l => l.Name);
        }

        private decimal Calculetefrequency(decimal quantity, decimal occurrence)
        {
            if (quantity == 0)
                return 0;

            return quantity / occurrence * 100;
        }

        internal IEnumerable<ListStudentViewModel> GetStudent(string nome, int? idProgram, int? idClassRoom, int? RA, int? idCampus)
        {
            var entities = StudentReadOnlyRepository.Search(new PersonFilter
            {
                Name = nome,
                IdProgram = idProgram,
                IdClassRoom = idClassRoom,
                RA = RA,
                IdCampus = idCampus
            });

            return entities.Select(l => new ListStudentViewModel
            {
                Name = l.Person.Name,
                UrlPicture = l.Person.UrlPicture,
                EvasionChance = l.EvasionScore,
                MediaScore = l.MediaScore,
                Overdue = l.Overdue,
                Frequency = Calculetefrequency(l.Presence.Where(q => q.Presence).Count(), l.Presence.Count()),
                Id = l.Id,
                
            }).OrderBy(l => l.Name);
        }

        public void Save(StudentViewModel vm)
        {
            var entity = new StudentEntity(0);
            vm.Bind(entity);
            StudentService.Save(entity);
        }
    }
}
