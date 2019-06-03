using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class WantedEntity : EntityBase
    {
        public WantedEntity(int id) : base(id)
        {
        }

        public string PersonId { get; set; }
        public string Name { get; set; }
        public int IdReason { get; set; }

        public ReasonEntity Reason { get; set; }

    }
}
