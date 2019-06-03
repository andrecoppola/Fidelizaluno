using FCNuvem.FidelizaAluno.API.ViewModels;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Services;
using System;


namespace FCNuvem.FidelizaAluno.API.Services
{
    public class WantedViewModelService : BaseViewModelService
    {
        public WantedViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private WantedService WantedService => GetService<WantedService>();
        private IWantedReadOnlyRepository WantedReadOnlyRepository => GetService<IWantedReadOnlyRepository>();

        public void Save(int vm)
        {
            var entity = new WantedEntity(0);
            //vm.Bind(entity);
            WantedService.Save(entity);
        }
    }
}
