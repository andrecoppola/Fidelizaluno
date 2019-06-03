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
    public class ClassRoomViewModelService : BaseViewModelService
    {
        public ClassRoomViewModelService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private ClassRoomService ClassService => GetService<ClassRoomService>();
        private IClassRoomReadOnlyRepository ClassRoomReadOnlyRepository => GetService<IClassRoomReadOnlyRepository>();

        internal IEnumerable<ClassRoomViewModel> GetClassRoomByProgram(int idProgram)
        {
            var entities = ClassRoomReadOnlyRepository.GetClassRoomByProgram(idProgram);
            return entities.Select(l => new ClassRoomViewModel
            {
                Id = l.Id,
                Name = l.Name
            });
        }

        internal IEnumerable<ClassRoomViewModel> GetAll(int? idCampus)
        {
            var entities = ClassRoomReadOnlyRepository.GetAll(idCampus);
            return entities.Select(l => new ClassRoomViewModel
            {
                Id = l.Id,
                Name = l.Name
            });
        }

        public void Save(ClassRoomViewModel vm)
        {
            var entity = new ClassRoomEntity(0);
            vm.Bind(entity);
            ClassService.Save(entity);
        }
    }
}
