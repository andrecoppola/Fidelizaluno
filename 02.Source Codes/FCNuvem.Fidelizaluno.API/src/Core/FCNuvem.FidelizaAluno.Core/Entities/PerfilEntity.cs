

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class PerfilEntity : EntityBase
    {
        public PerfilEntity(int id) 
            : base(id)
        {}

        public string Description { get; set; }
        public string Title { get; set; }

    }
}

