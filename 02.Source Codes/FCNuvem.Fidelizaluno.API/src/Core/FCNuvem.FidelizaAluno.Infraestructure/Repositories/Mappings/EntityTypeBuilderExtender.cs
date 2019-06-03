using FCNuvem.FidelizaAluno.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal static class EntityTypeBuilderExtender
    {
        public static EntityTypeBuilder<TEntity> HasOneWithMany<TEntity, TRelatedEntity>(this EntityTypeBuilder<TEntity> builder, Expression<Func<TEntity, TRelatedEntity>> navigationExpression,
            DeleteBehavior referentialActionOnDelete = DeleteBehavior.Restrict)
            where TEntity : class, IEntityBase
            where TRelatedEntity : class, IEntityBase
        {
            builder.HasOne(navigationExpression)
                .WithMany(typeof(TEntity).EntityName())
                .HasForeignKey("Id" + typeof(TRelatedEntity).EntityName())
                .OnDelete(referentialActionOnDelete);

            return builder;
        }

        public static EntityTypeBuilder<TEntity> HasOneWithOne<TEntity, TRelatedEntity>(this EntityTypeBuilder<TEntity> builder, Expression<Func<TEntity, TRelatedEntity>> navigationExpression,
          DeleteBehavior referentialActionOnDelete = DeleteBehavior.Restrict)
          where TEntity : class, IEntityBase
          where TRelatedEntity : class, IEntityBase
        {

            builder.HasOne(navigationExpression)
                .WithMany()
                .HasForeignKey("Id" + typeof(TRelatedEntity).EntityName())
                .OnDelete(referentialActionOnDelete);

            return builder;
        }

        public static EntityTypeBuilder<TEntity> HasOneWithManyPrivate<TEntity, TRelatedEntity>(this EntityTypeBuilder<TEntity> builder,
            DeleteBehavior referentialActionOnDelete = DeleteBehavior.Restrict)
            where TEntity : class, IEntityBase
            where TRelatedEntity : class, IEntityBase
        {
            builder.HasOne(typeof(TRelatedEntity), typeof(TRelatedEntity).EntityName(true))
                .WithMany(typeof(TEntity).EntityName())
                .HasForeignKey("Id" + typeof(TRelatedEntity).EntityName())
                .OnDelete(referentialActionOnDelete);

            return builder;
        }

        private static string EntityName(this Type type, bool firstLetterLowCase = false)
        {
            var name = type.Name.Replace("Entity", "");
            if (firstLetterLowCase)
                return char.ToLowerInvariant(name[0]) + name.Substring(1);

            return name;
        }
    }
}
