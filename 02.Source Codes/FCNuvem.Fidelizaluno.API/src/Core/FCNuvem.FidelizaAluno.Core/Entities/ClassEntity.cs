

using System;
using System.Collections.Generic;

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class ClassEntity : EntityBase
    {
        public ClassEntity(int id) 
            : base(id)
        {}

        public int IdDegree { get; set; }
        public DegreeEntity Degree { get; set; }

        public DateTime ClassDate { get; set; }
        public TimeSpan StartTime  { get; set; }
        public TimeSpan EndTime { get; set; }

        public ICollection<ClassDiaryEntity> ClassDiary { get; set; } = new List<ClassDiaryEntity>();

        public ICollection<PresenceEntity> Presence { get; set; } = new List<PresenceEntity>();

    }
}

