using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class CourseRepository : RepositoryBase<CourseEntity>, ICourseRepository
    {
        public CourseRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        public IEnumerable<CourseEntity> GetAllByClass(int idClass)
        {
            return from c in DbContext.Course
                    join d in DbContext.Degree on c.Id equals d.IdCourse
                    where d.IdClassRoom == idClass
                    select c;
        }
    }
}
