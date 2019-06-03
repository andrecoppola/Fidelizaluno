using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal class PersonTypeEntityMap : EntityMapConfiguration<PersonTypeEntity>
    {
        protected override void OnMapping()
        {
            Builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(100);

            Builder.Property(t => t.Id)
                .ValueGeneratedNever();

            HasDataEnum<EPersonType>();
        }
    }
}