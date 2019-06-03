using FCNuvem.FidelizaAluno.API.ViewModels.Period;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.Services
{
    public class PeriodViewModelService : BaseViewModelService
    {
        public PeriodViewModelService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

         private IPeriodReadOnlyRepository PeriodReadOnlyRepository => GetService<IPeriodReadOnlyRepository>();

        public IEnumerable<PeriodViewModel> GetAll(int? idClass, int? idProgram)
        {
            var entities = PeriodReadOnlyRepository.GetAll(idClass, idProgram);

            return entities.Select(u => new PeriodViewModel
            {
                Id = u.Id,
                Description = u.Description
            });
        }
    }
}
