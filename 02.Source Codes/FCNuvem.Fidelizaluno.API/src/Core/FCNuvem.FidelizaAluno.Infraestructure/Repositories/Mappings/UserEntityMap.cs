using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal class UserEntityMap : EntityMapConfiguration<UserEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithOne(l => l.Employee);
            Builder.HasOneWithOne(l => l.Perfil);
        }
    }
}
