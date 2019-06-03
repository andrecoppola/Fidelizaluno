using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class StudentService : ServiceBase
    {
        public StudentService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IStudentRepository StudentRepository => GetService<IStudentRepository>();
        private IStudentReadOnlyRepository StudentReadOnlyRepository => GetService<IStudentReadOnlyRepository>();


        public void Save(StudentEntity alunoEntity)
        {
            StudentRepository.Save(alunoEntity);
        }
    }
}
