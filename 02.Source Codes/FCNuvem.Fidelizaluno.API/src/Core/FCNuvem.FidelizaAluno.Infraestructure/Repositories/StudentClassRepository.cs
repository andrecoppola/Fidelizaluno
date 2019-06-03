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
    internal class StudentClassRepository : RepositoryBase<ClassRoomStudentEntity>, IStudentClassRepository
    {
        public StudentClassRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

       
    }
}
