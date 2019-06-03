

using System;
using System.Collections.Generic;

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class EvasionHistoryEntity : EntityBase
    {
        public EvasionHistoryEntity(int id) 
            : base(id)
        {}

        public StudentEntity Student { get; set; }
        public int IdStudent { get; set; }
        public decimal? EvasionScore { get; set; }
        public decimal? Distance { get; set; }
        public decimal? MediaScore { get; set; }
        public int? AmountPaymentPendent { get; set; }
        public DateTime Date { get; set; }


        public ICollection<ReasonEvasionEntity> ReasonEvasion { get; set; } = new List<ReasonEvasionEntity>();

    }
}

