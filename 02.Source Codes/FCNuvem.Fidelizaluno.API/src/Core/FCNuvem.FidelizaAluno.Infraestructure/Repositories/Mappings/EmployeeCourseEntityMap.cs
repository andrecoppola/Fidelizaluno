using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infraestructure.Repositories.Mappings
{
    internal class EmployeeCourseEntityMap : EntityMapConfiguration<EmployeeCourseEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithOne(l => l.Course);
            Builder.HasOneWithOne(l => l.Employee);
        }
    }
}
