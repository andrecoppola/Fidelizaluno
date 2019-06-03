using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class ProgramEntity : EntityBase
    {
        public ProgramEntity(int id) 
            : base(id)
        {}

        public string Name { get; set; }
        public int Load { get; set; }

        public EmployeeEntity Coordinator { get; set; }
        public int IdCoordinator { get; set; }

        public ICollection<CampusProgramEntity> CampusProgram { get; set; } = new List<CampusProgramEntity>();
        public ICollection<ClassRoomEntity> ClassRoom { get; set; } = new List<ClassRoomEntity>();
    }
}
