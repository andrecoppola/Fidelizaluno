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
    internal class ClassRepository : RepositoryBase<ClassEntity>, IClassRepository
    {
        public ClassRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        public ClassEntity Get(DateTime date)
        {
            return DbContext
                    .Class.Where(o =>
                    o.ClassDate.Date == date.Date
                    && o.StartTime <= date.TimeOfDay &&
                    o.EndTime >= date.TimeOfDay)
                    .FirstOrDefault();
        }

        public IEnumerable<ClassEntity> GetAll(int? idClassRoom, int? idCourse)
        {
            var query = DbContext.Class
                        .Include(u => u.Degree)
                        .AsQueryable();

            if (idClassRoom.HasValue)
                query = query.Where(u => u.Degree.IdClassRoom == idClassRoom);

            if (idCourse.HasValue)
                query = query.Where(k => k.Degree.IdCourse == idCourse);

            return query;
        }
    }
}
