

using System.Collections.Generic;

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class PeriodEntity : EntityBase
    {
        public PeriodEntity(int id) 
            : base(id)
        {}

        public string Description { get; set; }

        public ICollection<ClassRoomEntity> ClassRoom { get; set; } = new List<ClassRoomEntity>();

    }
}

