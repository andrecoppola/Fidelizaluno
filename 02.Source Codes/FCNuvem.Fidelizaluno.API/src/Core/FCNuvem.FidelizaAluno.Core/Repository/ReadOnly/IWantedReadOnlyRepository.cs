using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository.ReadOnly
{
    public interface IWantedReadOnlyRepository : IReadOnlyRepository<WantedEntity>
    {
        IEnumerable<WantedEntity> RetornarWanteds(IEnumerable<string> personIds);
    }
}