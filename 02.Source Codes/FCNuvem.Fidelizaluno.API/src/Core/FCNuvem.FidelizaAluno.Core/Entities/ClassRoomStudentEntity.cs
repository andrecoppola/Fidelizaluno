using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class ClassRoomStudentEntity : EntityBase
    {
        public ClassRoomStudentEntity(int id) 
            : base(id)
        {}
        

        public StudentEntity Student { get; set; }
        public int IdStudent { get; set; }
        public ClassRoomEntity ClassRoom { get; set; }
        public int IdClassRoom { get; set; }
    }
}
