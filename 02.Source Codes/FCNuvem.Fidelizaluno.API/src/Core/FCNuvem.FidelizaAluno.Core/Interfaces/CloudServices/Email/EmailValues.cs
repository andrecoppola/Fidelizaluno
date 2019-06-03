using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Interfaces.CloudServices.Email
{
    public class EmailValues
    {
        public int Id { get; set; }

        public List<Framework.ValueObjects.Email> to { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }

        private EmailValues() { }

        public EmailValues(int id, IEnumerable<Framework.ValueObjects.Email> to, string subject, string body)
        {
            if (id == 0) throw new ArgumentException(nameof(id));
            Id = id;


            to = to.ToList();
            this.Subject = subject;
            this.Body = body;
        }

        public EmailValues(int id, IEnumerable<string> to, string subject, string body)
            : this(id, to.Select(e => (Framework.ValueObjects.Email)e), subject, body)
        {
        }

        public EmailValues(int id, Framework.ValueObjects.Email to, string subject, string body)
            : this(id, new[] { to }, subject, body)
        {
        }

    }
}