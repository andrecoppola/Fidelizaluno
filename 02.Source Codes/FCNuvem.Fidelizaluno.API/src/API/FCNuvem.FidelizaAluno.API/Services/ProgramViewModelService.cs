using FCNuvem.FidelizaAluno.API.ViewModels.Program;
using FCNuvem.FidelizaAluno.API.ViewModels.Class;
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
    public class ProgramViewModelService : BaseViewModelService
    {
        public ProgramViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private ProgramService ProgramService => GetService<ProgramService>();
        private IClassRoomReadOnlyRepository ClassReadOnlyRepository => GetService<IClassRoomReadOnlyRepository>();
        private IProgramReadOnlyRepository ProgramReadOnlyRepository => GetService<IProgramReadOnlyRepository>();

        internal IEnumerable<ProgramViewModel> GetPrograms(int? IdCampus)
        {
            var entities = ProgramReadOnlyRepository.GetAll(IdCampus);
            return entities.Select(l => new ProgramViewModel
            {
                Id = l.Id,
                Name = l.Name
            });
        }




        public void Save(ProgramViewModel vm)
        {
            var entity = new ProgramEntity(0);
            ProgramService.Save(entity);
        }
    }
}
