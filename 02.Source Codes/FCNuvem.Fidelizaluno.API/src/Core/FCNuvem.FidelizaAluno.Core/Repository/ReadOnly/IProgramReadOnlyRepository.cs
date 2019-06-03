using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository.ReadOnly
{
    public interface IProgramReadOnlyRepository : IReadOnlyRepository<ProgramEntity>
    {
        IEnumerable<ProgramEntity> GetAllProgram(EvasionFilter evasaoFilter);
        IEnumerable<ProgramEntity> GetAll(int? IdCampus);
    }
}
