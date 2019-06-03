

using System;

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class AlertEntity : EntityBase
    {
        public AlertEntity(int id) 
            : base(id)
        {}

        public int IdReason { get; set; }
        public ReasonEntity Reason { get; set; }
        public string Email { get; set; }
        public int IdTemplate { get; set; }
        public TemplateEntity Template { get; set; }
        public DateTime SendAt { get; set; }

    }
}

