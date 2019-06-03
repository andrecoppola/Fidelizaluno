using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Enums;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infraestructure.Repositories.Mappings
{
    internal class ReasonEntityMap : EntityMapConfiguration<ReasonEntity>
    {
        protected override void OnMapping()
        {
            Builder.Property(t => t.Id)
                .ValueGeneratedNever();

            HasDataEnum<EReason>();
        }
    }
}
