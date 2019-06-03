using FCNuvem.FidelizaAluno.API.ViewModels.Class;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.Services
{
    public class ClassViewModelService : BaseViewModelService
    {
        public ClassViewModelService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IClassReadOnlyRepository ClassReadOnlyRepository => GetService<IClassReadOnlyRepository>();

        internal IEnumerable<ClassRoomViewModel> GetAll(int? idClassRoom, int? idCourse)
        {
            var entities = ClassReadOnlyRepository.GetAll(idClassRoom, idCourse);

            return entities.Select(u => new ClassRoomViewModel
            {
                Id = u.Id,
                StartTime = u.StartTime,
                EndTime = u.EndTime
            });
        }
    }
}
