using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.ViewModels.Class;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Period
{
    public class PeriodViewModel
    {
        public int Id { get; internal set; }
        public string Description { get; internal set; }
        public IEnumerable<ClassRoomViewModel> Class { get; set; }
        public int Amount
        {
            get {
                return (Class != null ? Class.Sum(c => c.Amount) : 0);
            }
        }
    }
}
