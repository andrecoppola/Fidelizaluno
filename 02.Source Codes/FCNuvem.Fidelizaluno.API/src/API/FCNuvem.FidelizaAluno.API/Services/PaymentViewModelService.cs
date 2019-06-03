using FCNuvem.FidelizaAluno.API.ViewModels.Payment;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Services;
using System;


namespace FCNuvem.FidelizaAluno.API.Services
{
    public class PaymentViewModelService : BaseViewModelService
    {
        public PaymentViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private PaymentService PaymentService => GetService<PaymentService>();
        private IPaymentReadOnlyRepository PaymentReadOnlyRepository => GetService<IPaymentReadOnlyRepository>();

        public void Save(PaymentViewModel vm)
        {
            var entity = new PaymentEntity(0);
            vm.Bind(entity);
            PaymentService.Save(entity);
        }
    }
}
