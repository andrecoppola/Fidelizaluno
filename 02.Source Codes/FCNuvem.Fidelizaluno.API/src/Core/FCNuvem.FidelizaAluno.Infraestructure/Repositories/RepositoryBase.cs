using FCNuvem.FidelizaAluno.Core.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Repository;
using System.Security;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal abstract class RepositoryBase
    {
        protected readonly EfContext DbContext;
        protected readonly IServiceProvider ServiceProvider;
        protected IMemoryCache Cache => ServiceProvider.GetService<IMemoryCache>();

        protected RepositoryBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            DbContext = ServiceProvider.GetService<EfContext>();
        }

    }

    internal abstract class RepositoryBase<TEntity, TKey> : RepositoryBase, IReadOnlyRepository<TEntity, TKey>, IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        protected RepositoryBase(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public virtual TEntity Get(TKey id)
        {
            var entity = DbContext.Find<TEntity>(id);
            return entity;
        }

        public virtual void Save(TEntity entity, bool? isItNew)
        {
            var entry = DbContext.Entry(entity);

            if (!isItNew.HasValue)
                isItNew = entry.IsKeySet;

            if (isItNew.Value)
                DbContext.Set<TEntity>().Add(entity);
            else
                DbContext.Set<TEntity>().Update(entity);

            DbContext.SaveChanges();
        }

        public virtual void Save(IEnumerable<TEntity> entity, bool isItNew) =>
            Save(entity, e => isItNew);

        public virtual void Save(IEnumerable<TEntity> entity, Func<TEntity, bool> isItNew)
        {
            if (entity == null || !entity.Any()) return;

            var dbSet = DbContext.Set<TEntity>();

            foreach (var item in entity)
            {
                if (isItNew != null && isItNew.Invoke(item))
                    dbSet.Add(item);
                else
                    dbSet.Update(item);
            }

            DbContext.SaveChanges();
        }

        public virtual void Remove(TKey id)
        {
            var entity = DbContext.Set<TEntity>().Find(id);

            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }

        public List<TEntity> GetAll() => DbContext.Set<TEntity>().ToList();
    }

    internal abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, int>
        where TEntity : EntityBase
    {
        protected RepositoryBase(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }
    }
}
