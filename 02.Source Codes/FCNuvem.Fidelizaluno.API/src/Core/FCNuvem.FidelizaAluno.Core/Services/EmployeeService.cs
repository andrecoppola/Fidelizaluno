using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class EmployeeService : ServiceBase
    {
        public EmployeeService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IEmployeeRepository EmployeeRepository => GetService<IEmployeeRepository>();
        private IEmployeeReadOnlyRepository EmployeeReadOnlyRepository => GetService<IEmployeeReadOnlyRepository>();


        public void Save(EmployeeEntity alunoEntity)
        {
            EmployeeRepository.Save(alunoEntity);
        }
    }
}
