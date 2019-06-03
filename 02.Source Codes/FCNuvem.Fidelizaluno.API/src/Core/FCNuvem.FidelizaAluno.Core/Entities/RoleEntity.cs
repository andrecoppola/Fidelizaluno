

using System.Collections.Generic;

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class RoleEntity : EntityBase
    {
        public RoleEntity(int id) 
            : base(id)
        {}

        public string Description { get; set; }

        public ICollection<EmployeeEntity> Employee { get; set; } = new List<EmployeeEntity>();

    }
}

