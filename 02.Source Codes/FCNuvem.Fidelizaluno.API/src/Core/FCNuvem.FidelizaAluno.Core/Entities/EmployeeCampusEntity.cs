

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class EmployeeCampusEntity : EntityBase
    {
        public EmployeeCampusEntity(int id) 
            : base(id)
        {}

        public EmployeeEntity Employee { get; set; }
        public int IdEmployee { get; set; }
        public CampusEntity Campus { get; set; }
        public int IdCampus { get; set; }

    }
}

