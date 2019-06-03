

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class EmployeeCourseEntity : EntityBase
    {
        public EmployeeCourseEntity(int id) 
            : base(id)
        {}

        public EmployeeEntity Employee { get; set; }
        public int IdEmployee { get; set; }
        public CourseEntity Course { get; set; }
        public int IdCourse { get; set; }

    }
}

