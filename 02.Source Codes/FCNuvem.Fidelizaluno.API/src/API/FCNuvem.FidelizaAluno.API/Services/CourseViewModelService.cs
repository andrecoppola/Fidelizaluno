using FCNuvem.FidelizaAluno.API.ViewModels.Course;
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
    public class CourseViewModelService : BaseViewModelService
    {
        public CourseViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private CourseService CourseService => GetService<CourseService>();
        private ICourseReadOnlyRepository CourseReadOnlyRepository => GetService<ICourseReadOnlyRepository>();

        public void Save(CourseViewModel vm)
        {
            var entity = new CourseEntity(0);
            vm.Bind(entity);
            CourseService.Save(entity);
        }

        internal IEnumerable<CourseViewModel> GetByClass(int idClass)
        {
            var entities = CourseReadOnlyRepository.GetAllByClass(idClass);
            return entities.Select(l => new CourseViewModel
            {
                Id = l.Id,
                Name = l.Name,
            });
        }
    }
}
