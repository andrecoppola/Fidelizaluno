
using FCNuvem.FidelizaAluno.Core.Interfaces.CloudServices.CloudQueue;
using FCNuvem.FidelizaAluno.Core.Interfaces.CloudServices.Email;
using FCNuvem.FidelizaAluno.WebJob.Internal;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.WebJob.Triggers.Jobs.Send
{
    public class SendEmailFunction : IFunction
    {
        private readonly IEmailClient EmailClient;

        public SendEmailFunction(IEmailClient emailClient)
        {
            EmailClient = emailClient;
        }


        public Task Run([TimerTrigger("0 0 0 * * *")]TimerInfo myTimer, string to, string body) =>
            EmailClient.SendAsync(to, body);
    }
}
