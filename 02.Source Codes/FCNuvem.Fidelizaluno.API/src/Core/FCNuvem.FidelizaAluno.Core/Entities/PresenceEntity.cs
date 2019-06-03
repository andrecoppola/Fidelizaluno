using System;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class PresenceEntity : EntityBase
    {
        public PresenceEntity(int id) 
            : base(id)
        {}

        public ClassEntity Class { get; set; }
        public int? IdClass { get; set; }
        public StudentEntity Student { get; set; }
        public int IdStudent { get; set; }
        public DateTime Data { get; set; }
        public bool Presence { get; set; }

    }
}
