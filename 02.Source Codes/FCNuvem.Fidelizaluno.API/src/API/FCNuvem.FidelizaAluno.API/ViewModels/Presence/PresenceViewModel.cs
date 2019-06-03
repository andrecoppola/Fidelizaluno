using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Presence
{
    public class PresenceViewModel
    {
        public int? Id { get; set; }
        public int? IdCourse { get; set; }
        public int? IdClass { get; set; }
        public DateTime? Data { get; set; }
        public int IdStudent { get; set; }
        public bool Presence { get; set; }
        public string Student { get; set; }
    }
}
