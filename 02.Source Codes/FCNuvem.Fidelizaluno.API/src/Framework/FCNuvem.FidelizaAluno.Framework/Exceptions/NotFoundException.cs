using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Framework.Exceptions
{
    public class NotFoundException : MessageException
    {
        public NotFoundException(params LocalizedString[] errors) : base(errors)
        {
        }
    }
}
