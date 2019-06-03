using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class EvasionHistoryService : ServiceBase
    {
        public EvasionHistoryService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IEvasionHistoryRepository EvasionHistoryRepository => GetService<IEvasionHistoryRepository>();
        private IEvasionHistoryReadOnlyRepository EvasionHistoryReadOnlyRepository => GetService<IEvasionHistoryReadOnlyRepository>();


        public void Save(EvasionHistoryEntity alunoEntity)
        {
            EvasionHistoryRepository.Save(alunoEntity);
        }
    }
}
