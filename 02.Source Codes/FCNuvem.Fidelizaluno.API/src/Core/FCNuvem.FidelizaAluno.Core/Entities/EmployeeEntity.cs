using System.Collections.Generic;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class EmployeeEntity : EntityBase
    {
        public EmployeeEntity(int id)
            : base(id)
        { }

        public RoleEntity Role { get; set; }
        public int IdRole { get; set; }

        public LoginEntity Login { get; set; }
        public int IdLogin { get; set; }

        public PersonEntity Person { get; set; }
        public int IdPerson { get; set; }

        public ICollection<ProgramEntity> Program { get; set; } = new List<ProgramEntity>();
        public ICollection<ClassDiaryEntity> ClassDiary { get; set; } = new List<ClassDiaryEntity>();
        public ICollection<DegreeEntity> Degree { get; set; } = new List<DegreeEntity>();

    }
}