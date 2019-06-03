using FCNuvem.FidelizaAluno.Core.Configurations;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class AlertService : ServiceBase
    {
        public AlertService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IAlertRepository AlertRepository => GetService<IAlertRepository>();
        private IAlertReadOnlyRepository AlertReadOnlyRepository => GetService<IAlertReadOnlyRepository>();
        private EmbeddedConfig EmbeddedConfig => GetService<EmbeddedConfig>();



        public void Save(AlertEntity alunoEntity)
        {
            AlertRepository.Save(alunoEntity);
        }
    }
}
