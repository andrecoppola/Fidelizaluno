using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class ScoreEntity : EntityBase
    {
        public ScoreEntity(int id) 
            : base(id)
        {}

        public CourseEntity Course { get; set; }
        public int IdCourse { get; set; }
        public StudentEntity Student { get; set; }
        public int IdStudent { get; set; }
        public decimal Value { get; set; }
        public DateTime Data { get; set; }
        public String Half { get; set; }
    }
}
