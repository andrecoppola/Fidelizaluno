using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class NotificationEntity : EntityBase
    {
        public NotificationEntity(int id) : base(id)
        {
        }

        public string Name { get; set; }
        public string PersonId { get; set; }
        public DateTime? Data { get; set; }
    }
}
