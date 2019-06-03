using FCNuvem.FidelizaAluno.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository.ReadOnly.Filter
{
    public class PersonFilter
    {
        public int? IdCampus { get; set; }
        public int? IdProgram { get; set; }
        public int? IdClassRoom { get; set; }

        public string Name { get; set; }
        public EPersonType? TipoPerson { get; set; }
        public int? RA { get; set; }
    }
}
