using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Student
{
    public class ListStudentViewModel
    {
        public object Name { get; internal set; }
        public int? Id { get; internal set; }
        public decimal? Frequency { get; internal set; }
        public decimal? EvasionChance { get; internal set; }
        public decimal? MediaScore { get; internal set; }
        public string UrlPicture { get; internal set; }
        public bool? Overdue { get; internal set; }
        public string ReasonEvasion { get; internal set; }
    }
}
