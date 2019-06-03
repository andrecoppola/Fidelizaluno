using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class StudentClassService : ServiceBase
    {
        public StudentClassService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IStudentClassRepository StudentClassRepository => GetService<IStudentClassRepository>();
        private IStudentClassReadOnlyRepository StudentClassReadOnlyRepository => GetService<IStudentClassReadOnlyRepository>();


        public void Save(ClassRoomStudentEntity alunoEntity)
        {
            StudentClassRepository.Save(alunoEntity);
        }
    }
}
