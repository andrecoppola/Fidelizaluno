using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.Configuration
{
    public class APIConfiguration
    {
        public AuthConfiguration Auth { get; set; } = new AuthConfiguration();

        public EmbeddedConfiguration Embedded { get; set; } = new EmbeddedConfiguration();
    }
}
