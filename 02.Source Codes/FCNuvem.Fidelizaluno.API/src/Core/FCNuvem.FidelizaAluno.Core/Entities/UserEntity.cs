
namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class UserEntity : EntityBase
    {
        public UserEntity(int id) 
            : base(id)
        {}

        public string DisplayName { get; set; }
        public string Login { get; set; }

        public EmployeeEntity Employee { get; set; }
        public int IdEmployee { get; set; }

        public PerfilEntity Perfil { get; set; }
        public int IdPerfil { get; set; }
    }
}
