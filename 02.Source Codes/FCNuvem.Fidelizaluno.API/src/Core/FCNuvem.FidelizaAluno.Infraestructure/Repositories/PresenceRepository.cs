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
    internal class PresenceRepository : RepositoryBase<PresenceEntity>, IPresenceRepository
    {
        public PresenceRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        public PresenceEntity Get(int idStudent, int idClass)
        {
            return DbContext.Presence
                .Where(i => i.IdStudent == idStudent && i.IdClass == idClass)
                .FirstOrDefault();
        }

        public IEnumerable<PresenceEntity> GetAbsent(DateTime date, int? idPeriod, int? idProgram = null, int? IdClassRoom = null, int? idCampus = null)
        {
            var query = DbContext.Presence
                    .Include(u => u.Student)
                        .ThenInclude(p => p.Person)
                    .Include(u => u.Student)
                        .ThenInclude(p => p.Presence)
                    .Include(i => i.Class)
                        .ThenInclude(x => x.Degree)
                            .ThenInclude(i => i.ClassRoom)
                    .Where(i => i.Class.ClassDate.Date == date.Date && i.Presence == false)
                    .AsQueryable();

            if (idCampus.HasValue)
                query = query.Where(o => o.Class.Degree.ClassRoom.IdCampus == idCampus);

            if (IdClassRoom.HasValue)
                query = query.Where(u => u.Class.Degree.IdClassRoom == IdClassRoom);

            if (idProgram.HasValue)
                query = query.Where(u => u.Class.Degree.ClassRoom.IdProgram == idProgram);

            if (idPeriod.HasValue)
                query = query.Where(u => u.Class.Degree.ClassRoom.IdPeriod == idPeriod);

            query = query.OrderBy(t => t.Student.Person.Name);

            return query;
        }

        public IEnumerable<PresenceEntity> GetByClass(int IdClass, DateTime? date)
        {
            var query = DbContext.Presence
                        .Include(p => p.Student)
                            .ThenInclude(s => s.Person)
                        .Where(p => p.IdClass == IdClass);

            if (date != null)
                query = query.Where(u => u.Data.Date == date.Value.Date);

            return query;
        }
    }
}
