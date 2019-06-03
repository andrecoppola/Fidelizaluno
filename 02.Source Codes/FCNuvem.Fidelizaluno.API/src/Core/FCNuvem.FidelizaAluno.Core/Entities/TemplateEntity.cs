

using System.Collections.Generic;

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class TemplateEntity : EntityBase
    {
        public TemplateEntity(int id) 
            : base(id)
        {}

        public string Template { get; set; }
        public ICollection<AlertEntity> Alert { get; set; } = new List<AlertEntity>();

    }
}

