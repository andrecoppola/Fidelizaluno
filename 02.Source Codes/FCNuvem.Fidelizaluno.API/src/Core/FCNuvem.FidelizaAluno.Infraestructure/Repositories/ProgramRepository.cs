using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class ProgramRepository : RepositoryBase<ProgramEntity>, IProgramRepository
    {
        public ProgramRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        public IEnumerable<ProgramEntity> GetAll(int? IdCampus)
        {
            var query = DbContext
                    .Program
                        .Include(l => l.CampusProgram)
                        .AsQueryable();

            if (IdCampus.HasValue)
                query = query.Where(l => l.CampusProgram.Any(u => u.IdCampus == IdCampus));

            return query;
        }

        public IEnumerable<ProgramEntity> GetAllProgram(EvasionFilter evasionFilter)
        {
            var query = DbContext.Program
                                .Include(l => l.ClassRoom)
                                    .ThenInclude(t => t.ClassRoomStudent)
                                        .ThenInclude(t => t.Student)
                                .Include(l => l.ClassRoom)
                                    .ThenInclude(t => t.Period)
                                .Where(l => l.ClassRoom.Any(c => c.ClassRoomStudent.Any(s => s.Student.EvasionScore >= evasionFilter.IntervalMin && s.Student.EvasionScore < evasionFilter.IntervalMax)))
                                .AsQueryable();

            if (evasionFilter.IdCampus.HasValue)
                query = query.Where(l => l.ClassRoom.Any(u => u.IdCampus == evasionFilter.IdCampus));

            query = query.OrderBy(t => t.Name);

            return query;
        }
    }

    
}
