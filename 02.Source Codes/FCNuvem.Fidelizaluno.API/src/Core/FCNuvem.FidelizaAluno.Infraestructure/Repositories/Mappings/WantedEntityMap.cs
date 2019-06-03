using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infraestructure.Repositories.Mappings
{
    class WantedEntityMap : EntityMapConfiguration<WantedEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOne(l => l.Reason).WithMany().HasForeignKey(l => l.IdReason);
        }
    }
}
