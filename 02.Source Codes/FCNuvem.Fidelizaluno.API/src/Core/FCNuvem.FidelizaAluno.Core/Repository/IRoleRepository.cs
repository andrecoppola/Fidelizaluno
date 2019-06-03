using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository
{
    public interface IRoleRepository : IRepository<RoleEntity>, IRoleReadOnlyRepository
    {
    }
}
