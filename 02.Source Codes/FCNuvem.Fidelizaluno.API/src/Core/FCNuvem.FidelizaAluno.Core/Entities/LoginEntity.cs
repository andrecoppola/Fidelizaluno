

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class LoginEntity : EntityBase
    {
        public LoginEntity(int id) 
            : base(id)
        {}

        public PerfilEntity Perfil { get; set; }
        public int IdPerfil { get; set; }

    }
}

