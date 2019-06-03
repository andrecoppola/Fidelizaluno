

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class ReasonHistoryEntity : EntityBase
    {
        public ReasonHistoryEntity(int id) 
            : base(id)
        {}

        public ReasonEntity Reason { get; set; }
        public int IdReason { get; set; }

    }
}

