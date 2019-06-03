using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories.Mappings
{
    internal class PaymentEntityMap : EntityMapConfiguration<PaymentEntity>
    {
        protected override void OnMapping()
        {
            Builder.HasOneWithMany(l => l.Class);
            Builder.HasOneWithMany(l => l.Student);
        }
    }
}
