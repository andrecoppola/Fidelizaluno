

namespace FCNuvem.FidelizaAluno.Core.Entities
{

    public class CampusProgramEntity : EntityBase
    {
        public CampusProgramEntity(int id) 
            : base(id)
        {}

        public int IdCampus { get; set; }
        public CampusEntity Campus { get; set; }
        public int IdProgram { get; set; }
        public ProgramEntity Program { get; set; }
    }
}

