using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class EmployeeCampusService : ServiceBase
    {
        public EmployeeCampusService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IEmployeeCampusRepository EmployeeCampusRepository => GetService<IEmployeeCampusRepository>();
        private IEmployeeCampusReadOnlyRepository EmployeeCampusReadOnlyRepository => GetService<IEmployeeCampusReadOnlyRepository>();


        public void Save(EmployeeCampusEntity alunoEntity)
        {
            EmployeeCampusRepository.Save(alunoEntity);
        }
    }
}
