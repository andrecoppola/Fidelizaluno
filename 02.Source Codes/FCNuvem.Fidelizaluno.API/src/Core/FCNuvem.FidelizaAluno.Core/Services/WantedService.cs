using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class WantedService : ServiceBase
    {
        public WantedService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IWantedRepository WantedRepository => GetService<IWantedRepository>();
        private IWantedReadOnlyRepository WantedReadOnlyRepository => GetService<IWantedReadOnlyRepository>();


        public void Save(WantedEntity alunoEntity)
        {
            WantedRepository.Save(alunoEntity);
        }
    }
}
