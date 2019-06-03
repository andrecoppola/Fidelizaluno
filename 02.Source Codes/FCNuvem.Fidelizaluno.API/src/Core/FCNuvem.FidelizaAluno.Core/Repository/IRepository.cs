using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;

namespace FCNuvem.FidelizaAluno.Core.Repository
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity, TKey> : IRepository where TEntity : EntityBase<TKey>
    {
        void Save(TEntity entity, bool? isNew = null);
        void Save(IEnumerable<TEntity> entity, Func<TEntity, bool> isNew);
        void Remove(TKey id);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : EntityBase
    {

    }
}
