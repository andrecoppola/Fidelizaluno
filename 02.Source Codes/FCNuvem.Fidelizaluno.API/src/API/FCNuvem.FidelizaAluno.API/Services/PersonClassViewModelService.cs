using FCNuvem.FidelizaAluno.API.ViewModels;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Services;
using System;


namespace FCNuvem.FidelizaAluno.API.Services
{
    public class StudentClassViewModelService : BaseViewModelService
    {
        public StudentClassViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private StudentClassService StudentClassService => GetService<StudentClassService>();
        private IStudentClassReadOnlyRepository StudentClassReadOnlyRepository => GetService<IStudentClassReadOnlyRepository>();

        public void Save()
        {
            var entity = new ClassRoomStudentEntity(0);
            StudentClassService.Save(entity);
        }
    }
}
