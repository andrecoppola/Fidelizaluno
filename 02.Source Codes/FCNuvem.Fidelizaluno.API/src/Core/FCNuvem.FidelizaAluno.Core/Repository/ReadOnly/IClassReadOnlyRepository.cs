using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository.ReadOnly
{
    public interface IClassReadOnlyRepository : IReadOnlyRepository<ClassEntity>
    {
        IEnumerable<ClassEntity> GetAll(int? idClassRoom, int? idCourse);
        ClassEntity Get(DateTime date);
    }
}
