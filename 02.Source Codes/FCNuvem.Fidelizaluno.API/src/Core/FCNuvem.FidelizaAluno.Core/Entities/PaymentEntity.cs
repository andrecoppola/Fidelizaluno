using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class PaymentEntity : EntityBase
    {
        public PaymentEntity(int id) 
            : base(id)
        {}

        public decimal Valor { get; set; }
        public ClassRoomEntity Class { get; set; }
        public int IdClass { get; set; }
        public StudentEntity Student { get; set; }
        public int IdStudent { get; set; }
        public DateTime Data { get; set; }

    }
}
