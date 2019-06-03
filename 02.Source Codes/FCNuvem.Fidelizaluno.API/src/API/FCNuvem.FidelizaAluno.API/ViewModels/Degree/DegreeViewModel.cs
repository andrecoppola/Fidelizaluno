using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Degree
{
    public class DegreeViewModel : IViewModelAdapter<DegreeEntity>
    {
        public int? IdDegreeCourse { get; set; }
        public int? IdClass { get; set; }
        public int? IdEmployee { get; internal set; }
        public int? IdCourse { get; internal set; }
        public string Course { get; internal set; }
        public TimeSpan? StartTime { get; internal set; }
        public TimeSpan? EndTime { get; internal set; }

        public void Bind(DegreeEntity model)
        {
        }

        public void Fill(DegreeEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
