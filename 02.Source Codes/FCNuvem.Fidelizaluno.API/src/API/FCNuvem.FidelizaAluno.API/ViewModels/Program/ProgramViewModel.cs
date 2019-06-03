using FCNuvem.FidelizaAluno.API.ViewModels.Period;
using System.Collections.Generic;
using System.Linq;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Program
{
    public class ProgramViewModel
    {
        public string Name { get; set; }
        public int Id { get; internal set; }
        public IEnumerable<PeriodViewModel> Periods { get; set; }
        public int Amount
        {
            get
            {
                return (Periods != null ? Periods.Sum(p => p.Amount) : 0);
            }
        }
    }
}
