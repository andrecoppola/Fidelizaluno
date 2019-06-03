using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository.ReadOnly
{
    public interface IPeriodReadOnlyRepository : IReadOnlyRepository<PeriodEntity>
    {
        IEnumerable<PeriodEntity> GetAll(int? idClass, int? idProgram);
    }
}
