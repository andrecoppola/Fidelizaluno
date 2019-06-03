using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class ReasonService : ServiceBase
    {
        public ReasonService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IReasonRepository ReasonRepository => GetService<IReasonRepository>();
        private IReasonReadOnlyRepository ReasonReadOnlyRepository => GetService<IReasonReadOnlyRepository>();


        public void Save(ReasonEntity alunoEntity)
        {
            ReasonRepository.Save(alunoEntity);
        }
    }
}
