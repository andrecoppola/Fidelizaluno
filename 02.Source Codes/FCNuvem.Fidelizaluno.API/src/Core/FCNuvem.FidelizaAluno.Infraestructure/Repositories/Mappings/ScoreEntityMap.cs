using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal class ScoreEntityMap : EntityMapConfiguration<ScoreEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithMany(l => l.Course);
            Builder.HasOneWithMany(l => l.Student);
        }
    }
}
