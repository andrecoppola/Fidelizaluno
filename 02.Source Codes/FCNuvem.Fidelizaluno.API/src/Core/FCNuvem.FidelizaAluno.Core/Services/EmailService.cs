using FCNuvem.FidelizaAluno.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class EmailService : ServiceBase
    {
        public EmailService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IAlertRepository AlertRepository => GetService<IAlertRepository>();

        public void SendAlerts()
        {
            using (var ts = InitTransaction())
            {
            }
        }
    }
}
