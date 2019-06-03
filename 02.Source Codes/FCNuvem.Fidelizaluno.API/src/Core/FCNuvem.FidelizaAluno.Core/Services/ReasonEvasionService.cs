using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class ReasonEvasionService : ServiceBase
    {
        public ReasonEvasionService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IReasonEvasionRepository ReasonEvasionRepository => GetService<IReasonEvasionRepository>();
        private IReasonEvasionReadOnlyRepository ReasonEvasionReadOnlyRepository => GetService<IReasonEvasionReadOnlyRepository>();


        public void Save(ReasonEvasionEntity alunoEntity)
        {
            ReasonEvasionRepository.Save(alunoEntity);
        }
    }
}
