using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class PeriodRepository : RepositoryBase<PeriodEntity>, IPeriodRepository
    {
        public PeriodRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        public IEnumerable<PeriodEntity> GetAll(int? idClass, int? idProgram)
        {
            var query = DbContext.Period
                .Include(u => u.ClassRoom)
                    .ThenInclude(l => l.Program)
                .AsQueryable();

            if (idClass.HasValue)
                query = query.Where(p => p.ClassRoom.Any(u => u.Id == idClass));

            if (idProgram.HasValue)
                query = query.Where(u => u.ClassRoom.Any(c => c.IdProgram == idProgram));

            return query;
        }
    }
}
