using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class ClassRoomRepository : RepositoryBase<ClassRoomEntity>, IClassRoomRepository
    {
        public ClassRoomRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        public IEnumerable<ClassRoomEntity> GetClassRoomByProgram(int idProgram)
        {
            return DbContext.ClassRoom.Where(l => l.IdProgram == idProgram);
        }

        public IEnumerable<ClassRoomEntity> GetAll(int? IdCampus)
        {
            var query = DbContext.ClassRoom.AsQueryable();

            if (IdCampus.HasValue)
                query = query.Where(u => u.IdCampus == IdCampus);

            return query;
        }
    }
}
