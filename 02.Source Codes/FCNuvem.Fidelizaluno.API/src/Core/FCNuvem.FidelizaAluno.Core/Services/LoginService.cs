using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class LoginService : ServiceBase
    {
        public LoginService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private ILoginRepository LoginRepository => GetService<ILoginRepository>();
        private ILoginReadOnlyRepository LoginReadOnlyRepository => GetService<ILoginReadOnlyRepository>();


        public void Save(LoginEntity alunoEntity)
        {
            LoginRepository.Save(alunoEntity);
        }
    }
}
