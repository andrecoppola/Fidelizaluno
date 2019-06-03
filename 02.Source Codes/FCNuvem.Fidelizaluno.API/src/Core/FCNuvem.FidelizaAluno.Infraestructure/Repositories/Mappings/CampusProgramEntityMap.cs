using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infraestructure.Repositories.Mappings
{
    internal class CampusProgramEntityMap : EntityMapConfiguration<CampusProgramEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithMany(l => l.Campus);
            Builder.HasOneWithMany(l => l.Program);
        }
    }
}

