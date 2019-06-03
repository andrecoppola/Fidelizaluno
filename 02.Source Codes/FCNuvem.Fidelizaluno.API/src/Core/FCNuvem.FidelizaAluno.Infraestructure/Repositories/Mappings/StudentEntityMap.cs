using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infraestructure.Repositories.Mappings
{
    class StudentEntityMap : EntityMapConfiguration<StudentEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithMany(l => l.Person);
        }
    }
}
