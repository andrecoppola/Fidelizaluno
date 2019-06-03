

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class DegreeCourseEntity : EntityBase
    {
        public DegreeCourseEntity(int id) 
            : base(id)
        {}

        public int IdDegree { get; set; }
        public DegreeEntity Degree { get; set; }
        public int IdCourse { get; set; }
        public CourseEntity Course { get; set; }
    }
}

