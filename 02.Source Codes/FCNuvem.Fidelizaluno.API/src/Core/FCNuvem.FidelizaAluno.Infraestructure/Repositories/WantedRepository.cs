using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infraestructure.Repositories
{
     internal class WantedRepository : RepositoryBase<WantedEntity>, IWantedRepository
    {
        public WantedRepository(IServiceProvider serviceProvider)
            : base(serviceProvider)
        { }

        public IEnumerable<WantedEntity> RetornarWanteds(IEnumerable<string> personIds)
        {
            return DbContext.Wanted.Where(u => personIds.Contains(u.PersonId));
        }
    }
}
