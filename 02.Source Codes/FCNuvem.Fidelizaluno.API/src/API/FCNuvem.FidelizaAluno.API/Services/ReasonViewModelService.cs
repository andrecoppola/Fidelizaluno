using FCNuvem.FidelizaAluno.API.ViewModels;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Services;
using System;


namespace FCNuvem.FidelizaAluno.API.Services
{
    public class ReasonViewModelService : BaseViewModelService
    {
        public ReasonViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private ReasonService ReasonService => GetService<ReasonService>();
        private IReasonReadOnlyRepository ReasonReadOnlyRepository => GetService<IReasonReadOnlyRepository>();

        public void Save(int vm)
        {
            var entity = new ReasonEntity(0);
            //vm.Bind(entity);
            ReasonService.Save(entity);
        }
    }
}
