using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class CourseEntity : EntityBase
    {
        public CourseEntity(int id) 
            : base(id)
        {}

        public string Name { get; set; }
        public int Time { get; set; }
        public ICollection<ClassDiaryEntity> ClassDiary { get; set; } = new List<ClassDiaryEntity>();
        public ICollection<DegreeEntity> Degree { get; set; } = new List<DegreeEntity>();
        public ICollection<ScoreEntity> Score { get; set; } = new List<ScoreEntity>();

    }
}
