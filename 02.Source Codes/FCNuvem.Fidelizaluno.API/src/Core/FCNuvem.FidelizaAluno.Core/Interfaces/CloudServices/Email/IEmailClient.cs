using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.Core.Interfaces.CloudServices.Email
{
    public interface IEmailClient
    {
        Task SendAsync(string to, string body);
    }
}
