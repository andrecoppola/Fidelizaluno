using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class ReasonHistoryService : ServiceBase
    {
        public ReasonHistoryService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IReasonHistoryRepository ReasonHistoryRepository => GetService<IReasonHistoryRepository>();
        private IReasonHistoryReadOnlyRepository ReasonHistoryReadOnlyRepository => GetService<IReasonHistoryReadOnlyRepository>();


        public void Save(ReasonHistoryEntity alunoEntity)
        {
            ReasonHistoryRepository.Save(alunoEntity);
        }
    }
}
