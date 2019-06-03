using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class CourseService : ServiceBase
    {
        public CourseService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private ICourseRepository CourseRepository => GetService<ICourseRepository>();
        private ICourseReadOnlyRepository CourseReadOnlyRepository => GetService<ICourseReadOnlyRepository>();


        public void Save(CourseEntity alunoEntity)
        {
            CourseRepository.Save(alunoEntity);
        }
    }
}
