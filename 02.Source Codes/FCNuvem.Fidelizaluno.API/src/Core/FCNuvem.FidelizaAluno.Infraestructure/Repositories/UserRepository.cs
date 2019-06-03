using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infraestructure.Repositories
{
    class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        public UserEntity Get(string email)
        {
            return DbContext.User
                .Where(i => i.Login.Equals(email))
                .FirstOrDefault();
        }
    }
}
