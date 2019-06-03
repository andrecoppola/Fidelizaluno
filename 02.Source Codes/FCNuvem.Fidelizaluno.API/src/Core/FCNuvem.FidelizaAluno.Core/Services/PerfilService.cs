using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class PerfilService : ServiceBase
    {
        public PerfilService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IPerfilRepository PerfilRepository => GetService<IPerfilRepository>();
        private IPerfilReadOnlyRepository PerfilReadOnlyRepository => GetService<IPerfilReadOnlyRepository>();


        public void Save(PerfilEntity alunoEntity)
        {
            PerfilRepository.Save(alunoEntity);
        }
    }
}
