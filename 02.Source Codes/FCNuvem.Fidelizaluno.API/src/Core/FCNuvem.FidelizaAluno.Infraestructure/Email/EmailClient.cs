using FCNuvem.FidelizaAluno.Core.Interfaces.CloudServices.Email;
using FCNuvem.FidelizaAluno.Infrastructure.Configurations;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using FCNuvem.FidelizaAluno.Framework.Extenders;

namespace FCNuvem.FidelizaAluno.Infraestructure.Email
{
    public class EmailClient : IEmailClient
    {
        private readonly IServiceProvider _serviceProvider;

        private InfrastructureConfig InfrastructureConfig => _serviceProvider.GetService<InfrastructureConfig>();

        public EmailClient(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SendAsync(string to, string body)
        {
            using (var smtp = new SmtpClient())
            {
                BindSmtpClient(smtp);
                
                using (var mensagem = new MailMessage())
                {
                    mensagem.Subject = "Evasão";
                    mensagem.Body = body;
                    mensagem.IsBodyHtml = true;
                    mensagem.To.Add(to);

                    BindMailMessage(mensagem);

                    try
                    {
                        await smtp.SendMailAsync(mensagem);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }

        private void BindMailMessage(MailMessage mensagem)
        {
            mensagem.From = new MailAddress(InfrastructureConfig.Email.AddresFrom, InfrastructureConfig.Email.NameFrom);

            if ((EnvironmentHelper.Desenvolvimento || EnvironmentHelper.Homologacao) &&
                !string.IsNullOrWhiteSpace(InfrastructureConfig.Email.DebugEmail))
            {
                mensagem.To.Clear();

                foreach (var e in InfrastructureConfig.Email.DebugEmail.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mensagem.To.Add(e);
                }
            }
        }

        private void BindSmtpClient(SmtpClient smtpClient)
        {
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;

            smtpClient.Host = InfrastructureConfig.Email.Server;
            smtpClient.Port = InfrastructureConfig.Email.Port;
            smtpClient.EnableSsl = InfrastructureConfig.Email.Ssl;
            smtpClient.Credentials = new NetworkCredential(InfrastructureConfig.Email.User, InfrastructureConfig.Email.Password);
        }
    }
}
