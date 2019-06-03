using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    public class AdressOwnedTypeMap
    {
        public static void Mapping<TEntity>(ReferenceOwnershipBuilder<TEntity, AddressOwnedType> builder, string columnNamePrefix = null)
            where TEntity : class
        {
            builder.Property(c => c.Cep)
                .HasColumnName(columnNamePrefix + nameof(AddressOwnedType.Cep))
                .HasMaxLength(8);

            builder.Property(c => c.Logradouro)
                .HasColumnName(columnNamePrefix + nameof(AddressOwnedType.Logradouro))
                .HasMaxLength(200);

            builder.Property(c => c.Bairro)
                .HasColumnName(columnNamePrefix + nameof(AddressOwnedType.Bairro))
                .HasMaxLength(100);

            builder.Property(c => c.Municipio)
                .HasColumnName(columnNamePrefix + nameof(AddressOwnedType.Municipio))
                .HasMaxLength(100);

            builder.Property(c => c.Numero)
                .HasColumnName(columnNamePrefix + nameof(AddressOwnedType.Numero))
                .HasMaxLength(20);

            builder.Property(c => c.Uf)
                .HasColumnName(columnNamePrefix + nameof(AddressOwnedType.Uf));

            builder.Property(c => c.Complemento)
                .HasColumnName(columnNamePrefix + nameof(AddressOwnedType.Complemento))
                .HasMaxLength(200);

            builder.Property(c => c.CodigoMunicipio)
                .HasColumnName(columnNamePrefix + nameof(AddressOwnedType.CodigoMunicipio))
                .HasMaxLength(50);
        }
    }
}
