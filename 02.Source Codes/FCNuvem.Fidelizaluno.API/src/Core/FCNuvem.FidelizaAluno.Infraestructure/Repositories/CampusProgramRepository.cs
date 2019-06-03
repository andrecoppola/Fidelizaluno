using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class CampusProgramRepository : RepositoryBase<CampusProgramEntity>, ICampusProgramRepository
    {
        public CampusProgramRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}
    }
}
