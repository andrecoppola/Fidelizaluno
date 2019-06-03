using FCNuvem.FidelizaAluno.Core.Enums;
using FCNuvem.FidelizaAluno.Framework.Extenders;
using System.Collections.Generic;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class ReasonEntity : EntityBase
    {
        public ReasonEntity(int id) 
            : base(id)
        {
            Name = ((EReason)id).GetDescription();
        }

        public string Name { get; private set; }

        public ICollection<ReasonEvasionEntity> ReasonEvasion { get; set; } = new List<ReasonEvasionEntity>();
        public ICollection<AlertEntity> Alert { get; set; } = new List<AlertEntity>();
    }
}
