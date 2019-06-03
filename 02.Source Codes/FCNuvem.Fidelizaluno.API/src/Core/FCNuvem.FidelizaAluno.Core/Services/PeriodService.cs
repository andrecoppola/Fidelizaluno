using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class PeriodService : ServiceBase
    {
        public PeriodService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IPeriodRepository PeriodRepository => GetService<IPeriodRepository>();
        private IPeriodReadOnlyRepository PeriodReadOnlyRepository => GetService<IPeriodReadOnlyRepository>();


        public void Save(PeriodEntity alunoEntity)
        {
            PeriodRepository.Save(alunoEntity);
        }
    }
}
