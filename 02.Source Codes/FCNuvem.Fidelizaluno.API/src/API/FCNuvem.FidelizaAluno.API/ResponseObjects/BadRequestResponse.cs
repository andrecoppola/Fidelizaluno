using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ResponseObjects
{
    public class BadRequestResponse : ResponseModelBase
    {
        public BadRequestResponse(List<LocalizedString> erros, object data = null)
            : base(data)
        {
            Messages = erros.Select(e => e.Value);
        }

        public BadRequestResponse(string errorMessage, object data = null) : base(data)
        {
            Sucess = false;
            Messages = new[] { errorMessage };
        }

        public BadRequestResponse(IEnumerable<string> errorMessage, object data = null) : base(data)
        {
            Sucess = false;
            Messages = errorMessage;
        }
    }
}
