using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class PaymentService : ServiceBase
    {
        public PaymentService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IPaymentRepository PaymentRepository => GetService<IPaymentRepository>();
        private IPaymentReadOnlyRepository PaymentReadOnlyRepository => GetService<IPaymentReadOnlyRepository>();


        public void Save(PaymentEntity alunoEntity)
        {
            PaymentRepository.Save(alunoEntity);
        }
    }
}
