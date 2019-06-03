using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal class DegreeEntityMap : EntityMapConfiguration<DegreeEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithMany(l => l.Employee);
            Builder.HasOneWithMany(l => l.Course);
            Builder.HasOneWithMany(l => l.ClassRoom);
        }
    }
}
