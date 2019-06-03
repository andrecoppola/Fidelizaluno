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
    internal class PersonRepository : RepositoryBase<PersonEntity>, IPersonRepository
    {
        public PersonRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        public PersonEntity Get(string faceId)
        {
            return DbContext.Person
                .Include(u => u.Student)
                .Where(i => i.FaceId == faceId)
                .FirstOrDefault();
        }
    }
}
