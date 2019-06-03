using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository.ReadOnly
{
    public interface IPersonReadOnlyRepository : IReadOnlyRepository<PersonEntity>
    {
        PersonEntity Get(string faceId);
    }
}
