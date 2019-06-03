using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class RoleService : ServiceBase
    {
        public RoleService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IRoleRepository RoleRepository => GetService<IRoleRepository>();
        private IRoleReadOnlyRepository RoleReadOnlyRepository => GetService<IRoleReadOnlyRepository>();


        public void Save(RoleEntity alunoEntity)
        {
            RoleRepository.Save(alunoEntity);
        }
    }
}
