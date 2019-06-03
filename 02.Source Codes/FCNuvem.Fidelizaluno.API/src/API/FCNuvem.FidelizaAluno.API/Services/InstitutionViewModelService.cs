using FCNuvem.FidelizaAluno.API.ViewModels.Institution;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Services;
using System;


namespace FCNuvem.FidelizaAluno.API.Services
{
    public class InstitutionViewModelService : BaseViewModelService
    {
        public InstitutionViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private InstitutionService InstitutionService => GetService<InstitutionService>();
        private IInstitutionReadOnlyRepository InstitutionReadOnlyRepository => GetService<IInstitutionReadOnlyRepository>();

        public void Save(InstitutionViewModel vm)
        {
            var entity = new InstitutionEntity(0);
            vm.Bind(entity);
            InstitutionService.Save(entity);
        }
    }
}
