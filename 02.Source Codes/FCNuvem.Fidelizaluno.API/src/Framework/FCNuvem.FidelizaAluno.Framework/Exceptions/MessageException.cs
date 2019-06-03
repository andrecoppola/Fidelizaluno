using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Localization;

namespace FCNuvem.FidelizaAluno.Framework.Exceptions
{
    public class MessageException : Exception
    {
        public readonly List<LocalizedString> Errors;

        public MessageException()
            : base()
        {
            Errors = new List<LocalizedString>();
        }

        public MessageException(params LocalizedString[] errors)
            : this(new List<LocalizedString>(errors))
        { }

        public MessageException(IEnumerable<LocalizedString> errors)
        {
            Errors = new List<LocalizedString>();
            Errors.AddRange(errors);
        }

        public MessageException(LocalizedString erro, Exception ex)
            : base(erro.Value, ex)
        {
            Errors = new List<LocalizedString>();
            Errors.Add(erro);
        }

        public string GetMessages()
        {
            var errors = "";
            Errors.ForEach(erro => errors += $"{erro.Value}, ");
            return errors.Substring(0, errors.Length - 2);
        }
    }
}
