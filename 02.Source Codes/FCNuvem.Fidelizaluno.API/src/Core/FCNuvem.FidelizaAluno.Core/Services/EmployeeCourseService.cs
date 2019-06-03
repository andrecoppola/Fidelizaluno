using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class EmployeeCourseService : ServiceBase
    {
        public EmployeeCourseService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IEmployeeCourseRepository EmployeeCourseRepository => GetService<IEmployeeCourseRepository>();
        private IEmployeeCourseReadOnlyRepository EmployeeCourseReadOnlyRepository => GetService<IEmployeeCourseReadOnlyRepository>();


        public void Save(EmployeeCourseEntity alunoEntity)
        {
            EmployeeCourseRepository.Save(alunoEntity);
        }
    }
}
