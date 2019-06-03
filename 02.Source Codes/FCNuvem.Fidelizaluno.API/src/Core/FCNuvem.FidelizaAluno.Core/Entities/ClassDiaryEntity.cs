using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class ClassDiaryEntity : EntityBase
    {
        public ClassDiaryEntity(int id) 
            : base(id)
        {}

        public ClassEntity Class { get; set; }
        public int IdClass { get; set; }
        public EmployeeEntity Employee { get; set; }
        public int IdEmployee { get; set; }
        public StudentEntity Student { get; set; }
        public int IdStudent { get; set; }
        public DateTime Data { get; set; }
        public string Observation { get; set; }

    }
}
