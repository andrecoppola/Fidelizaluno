using System.Collections.Generic;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class PersonEntity : EntityBase
    {
        public PersonEntity(int id)
            : base(id)
        { }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string TelephoneCelular { get; set; }
        public string TelephoneResidencial { get; set; }
        public char Genre { get; set; }
        public string UrlPicture { get; set; }
        public string FaceId { get; set; }

        public AddressEntity Address { get; set; }
        public int IdAddress { get; set; }

        public ICollection<EmployeeEntity> Employee { get; set; } = new List<EmployeeEntity>();
        public ICollection<StudentEntity> Student { get; set; } = new List<StudentEntity>();


    }
}
