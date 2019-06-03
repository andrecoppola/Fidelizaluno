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
    internal class DegreeRepository : RepositoryBase<DegreeEntity>, IDegreeRepository
    {
        public DegreeRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        public IEnumerable<DegreeEntity> GetByClassRoom(int idClassRoom)
        {
            return DbContext.Degree.Include(d => d.Course).Where(d => d.IdClassRoom == idClassRoom);
        }
    }
}
