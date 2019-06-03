using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Configurations
{
    public class InfrastructureConfig
    {
        public string ConnectionString { get; set; }
        public EmailConfig Email { get; set; } = new EmailConfig();
    }
}
