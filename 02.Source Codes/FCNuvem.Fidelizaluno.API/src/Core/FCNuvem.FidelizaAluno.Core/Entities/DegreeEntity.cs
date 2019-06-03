using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class DegreeEntity : EntityBase
    {
        public DegreeEntity(int id) 
            : base(id)
        {}


        public int? IdClassRoom { get; set; }
        public ClassRoomEntity ClassRoom { get; set; }

        public CourseEntity Course { get; set; }
        public int IdCourse { get; set; }

        public EmployeeEntity Employee { get; set; }
        public int IdEmployee { get; set; }
        public int Load { get; set; }

        public ICollection<ClassEntity> Class { get; set; } = new List<ClassEntity>();

    }
}
