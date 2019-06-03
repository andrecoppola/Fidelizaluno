using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FCNuvem.FidelizaAluno.Framework.ValueObjects;
using System.Linq;
using FCNuvem.FidelizaAluno.Framework.Extenders;
using System.Text.RegularExpressions;

namespace FCNuvem.FidelizaAluno.Core.Interfaces.CloudServices.CloudQueue
{
    public partial class CloudQueueNames
    {
        public const string SendEmailKey = "%enviar-email%";
        public static readonly CloudQueueNames SendEmail = new CloudQueueNames(SendEmailKey, "Envio de e-mail");
    }

    [Serializable]
    public partial class CloudQueueNames : Enumeration<CloudQueueNames, string>
    {
        public readonly string RealName;

        public string RowName => Value;
        public string Description => DisplayName;


        public CloudQueueNames(string rowName, string rowDescription)
            : base(rowName, rowDescription)
        {
            RealName = CreateRealName(rowName);
        }

        public static implicit operator CloudQueueNames(string rowName)
        {
            return GetAll().FirstOrDefault(c => c.Value == rowName);
        }

        public static string CreateRealName(string rowName)
        {
            rowName = rowName.Trim('%');

            if (EnvironmentHelper.Desenvolvimento)
            {
                var machineName = Regex.Replace(Environment.MachineName.ToLower(), "[^a-z0-9]", "");
                return $"dev-{machineName}-{rowName}";
            }

            return rowName;
        }
    }
}
