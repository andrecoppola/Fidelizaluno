using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository.ReadOnly.Filter
{
    public class EvasionFilter
    {
        public decimal IntervalMin { get; set; }
        public decimal IntervalMax { get; set; }
        public int? IdClassRoom { get; set; }
        public int? IdCampus { get; set; }
    }
}
