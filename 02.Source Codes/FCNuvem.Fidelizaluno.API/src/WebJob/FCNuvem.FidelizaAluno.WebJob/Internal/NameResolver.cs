using FCNuvem.FidelizaAluno.Core.Interfaces.CloudServices.CloudQueue;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.WebJob.Internal
{
    public class NameResolver : INameResolver
    {
        public string Resolve(string name) => CloudQueueNames.CreateRealName(name);
    }
}
