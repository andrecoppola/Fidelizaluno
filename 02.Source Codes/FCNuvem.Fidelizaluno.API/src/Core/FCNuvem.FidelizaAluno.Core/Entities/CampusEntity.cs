using FCNuvem.FidelizaAluno.Core.Enums;
using System.Collections.Generic;

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class CampusEntity : EntityBase
    {
        public CampusEntity(int id)
            : base(id)
        { }

        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public ECampusType CampusType { get; set; }

        public InstitutionEntity Institution { get; set; }
        public int IdInstitution { get; set; }

        public AddressEntity Address { get; set; }
        public int IdAddress { get; set; }

        public ICollection<CampusProgramEntity> CampusProgram { get; set; } = new List<CampusProgramEntity>();
        public ICollection<ClassRoomEntity> ClassRoom { get; set; } = new List<ClassRoomEntity>();

    }
}
