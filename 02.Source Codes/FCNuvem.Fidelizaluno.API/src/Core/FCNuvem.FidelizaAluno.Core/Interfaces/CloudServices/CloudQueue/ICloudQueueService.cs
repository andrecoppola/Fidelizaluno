using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.Core.Interfaces.CloudServices.CloudQueue
{
    public interface ICloudQueueService
    {
        Task SendAsync(object item, CloudQueueNames queueName, TimeSpan? initialVisibilityDelay = null);
    }
}
