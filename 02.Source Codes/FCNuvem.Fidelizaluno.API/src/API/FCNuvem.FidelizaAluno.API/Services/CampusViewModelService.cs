using FCNuvem.FidelizaAluno.API.ViewModels.Campus;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FCNuvem.FidelizaAluno.API.Services
{
    public class CampusViewModelService : BaseViewModelService
    {
        public CampusViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private CampusService CampusService => GetService<CampusService>();
        private ICampusReadOnlyRepository CampusReadOnlyRepository => GetService<ICampusReadOnlyRepository>();

        internal IEnumerable<CampusViewModel> GetCampus()
        {
            var entities = CampusReadOnlyRepository.GetAll();

            return entities.Select(l => new CampusViewModel
            {
                Id = l.Id,
                Name = l.Name,
                CampusType = l.CampusType,
                Cnpj = l.Cnpj,
                Email = l.Email,
                Telephone = l.Telephone
            });
        }


        public void Save(CampusViewModel vm)
        {
            var entity = new CampusEntity(0);
            vm.Bind(entity);
            CampusService.Save(entity);
        }
    }
}
