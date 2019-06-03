namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class ReasonEvasionEntity : EntityBase
    {
        public ReasonEvasionEntity(int id)
            : base(id)
        { }

        public int IdReason { get; set; }
        public ReasonEntity Reason { get; set; }

        public int IdEvasionHistory { get; set; }
        public EvasionHistoryEntity EvasionHistory { get; set; }

        public decimal ReasonPercentage { get; set; }
    }
}