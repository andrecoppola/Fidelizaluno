using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.Configuration
{
    public class EmbeddedConfiguration
    {
        public string AuthorityUrl { get; set; }
        public string ResourceUrl { get; set; }
        public string ApplicationId { get; set; }
        public string ApiUrl { get; set; }
        public string WorkspaceId { get; set; }
        public string ReportId { get; set; }
        public string AuthenticationType { get; set; }
        public string ApplicationSecret { get; set; }
        public string Tenant { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
