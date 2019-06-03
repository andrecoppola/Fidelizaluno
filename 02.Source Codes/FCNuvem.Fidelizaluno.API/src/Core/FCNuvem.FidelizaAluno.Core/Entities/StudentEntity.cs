using System;
using System.Collections.Generic;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class StudentEntity : EntityBase
    {
        public StudentEntity(int id)
            : base(id)
        { }

        public int RA { get; set; }
        public decimal EvasionScore { get; set; }
        public int PaymentDay { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public ushort AmountPaymentPendent { get; set; }
        public decimal Distance { get; set; }
        public decimal MediaScore { get; set; }
        public decimal? Frequency { get; set; }
        public bool? Overdue { get; set; }
        public bool? Enrolled { get; set; }

        public PersonEntity Person { get; set; }
        public int IdPerson { get; set; }

        public ICollection<PresenceEntity> Presence { get; set; } = new List<PresenceEntity>();
        public ICollection<EvasionHistoryEntity> EvasionHistory { get; set; } = new List<EvasionHistoryEntity>();
        public ICollection<PaymentEntity> Payment { get; set; } = new List<PaymentEntity>();
        public ICollection<ClassRoomStudentEntity> ClassRoomStudent { get; set; } = new List<ClassRoomStudentEntity>();
        public ICollection<ClassDiaryEntity> ClassDiary { get; set; } = new List<ClassDiaryEntity>();
        public ICollection<ScoreEntity> Score { get; set; } = new List<ScoreEntity>();
    }
}