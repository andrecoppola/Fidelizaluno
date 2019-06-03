using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal class PresenceEntityMap : EntityMapConfiguration<PresenceEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithMany(l => l.Student);
            Builder.HasOneWithMany(l => l.Class);
        }
    }
}
