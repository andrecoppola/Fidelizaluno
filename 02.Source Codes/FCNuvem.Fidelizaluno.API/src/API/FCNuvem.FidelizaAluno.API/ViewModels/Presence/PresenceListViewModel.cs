using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Presence
{
    public class PresenceListViewModel
    {
        public int IdClass { get; set; }
        public DateTime Data { get; set; }
        public IEnumerable<PresenceViewModel> Presences { get; set; }
        public int IdPeriod { get; internal set; }
    }
}
