using FCNuvem.FidelizaAluno.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal abstract class EntityMapConfiguration<TEntity> : EntityMapConfiguration<TEntity, int> where TEntity : EntityBase
    { }

    internal abstract class EntityMapConfiguration<TEntity, TKey> : EntityMapConfiguration where TEntity : EntityBase<TKey>
    {
        protected EntityTypeBuilder<TEntity> Builder { get; private set; }

        protected abstract void OnMapping();

        internal override void Mapping(ModelBuilder modelBuilder)
        {
            Builder = modelBuilder.Entity<TEntity>();

            //Padronizando os nomes das tabelas
            Builder.ToTable(typeof(TEntity).Name.Replace("Entity", string.Empty));

            Builder.HasKey(nameof(EntityBase.Id));

            OnMapping();
        }

        protected void HasDataEnum<TEnumKey>()
        {
            foreach (var item in Enum.GetValues(typeof(TEnumKey)))
            {
                Builder.HasData(Activator.CreateInstance(typeof(TEntity), item));
            }
        }
    }

    internal abstract class EntityMapConfiguration
    {
        internal abstract void Mapping(ModelBuilder modelBuilder);
    }
}
