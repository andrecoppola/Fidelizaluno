using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class InstitutionEntity : EntityBase
    {
        public InstitutionEntity(int id) 
            : base(id)
        {}

        public string Name { get; set; }
        public string TradingName { get; set; }
        public string Cnpj { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Media { get; set; }

        public AddressEntity Address { get; set; }
        public int IdAddress { get; set; }

        public ICollection<CampusEntity> Campus { get; set; } = new List<CampusEntity>();

    }
}
