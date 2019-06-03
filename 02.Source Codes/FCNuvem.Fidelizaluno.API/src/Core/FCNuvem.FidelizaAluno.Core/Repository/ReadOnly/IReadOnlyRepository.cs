using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository.ReadOnly
{
    public interface IReadOnlyRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        TEntity Get(TKey id);

        List<TEntity> GetAll();
    }

    public interface IReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity, int>
        where TEntity : EntityBase
    { }
}
