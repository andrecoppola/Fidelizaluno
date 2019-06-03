using FCNuvem.FidelizaAluno.API.ViewModels.Degree;
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
    public class DegreeViewModelService : BaseViewModelService
    {
        public DegreeViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private DegreeService DegreeService => GetService<DegreeService>();
        private IDegreeReadOnlyRepository DegreeReadOnlyRepository => GetService<IDegreeReadOnlyRepository>();

        public void Save(DegreeViewModel vm)
        {
            var entity = new DegreeEntity(0);
            vm.Bind(entity);
            DegreeService.Save(entity);
        }

        internal IEnumerable<DegreeViewModel> GetByClassRoom(int idClassRoom)
        {
            var entities = DegreeReadOnlyRepository.GetByClassRoom(idClassRoom);

            return entities.Select(e => new DegreeViewModel
            {
                IdClass = idClassRoom,
                IdEmployee = e.IdEmployee,
                IdCourse = e.IdCourse,
                Course = e.Course.Name
            });
        }
    }
}
