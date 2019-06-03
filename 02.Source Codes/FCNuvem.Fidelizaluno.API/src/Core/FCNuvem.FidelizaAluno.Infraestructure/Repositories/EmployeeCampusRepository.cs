using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class EmployeeCampusRepository : RepositoryBase<EmployeeCampusEntity>, IEmployeeCampusRepository
    {
        public EmployeeCampusRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}
    }
}
