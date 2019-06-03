using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infraestructure.Repositories.Mappings
{
    class EmployeeEntityMap : EntityMapConfiguration<EmployeeEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithMany(l => l.Person);
            Builder.HasOneWithMany(l => l.Role);
            Builder.HasOneWithOne(l => l.Login);
        }
    }
}
