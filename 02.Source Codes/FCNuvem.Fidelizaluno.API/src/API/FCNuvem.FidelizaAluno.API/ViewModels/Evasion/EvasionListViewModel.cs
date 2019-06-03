using FCNuvem.FidelizaAluno.API.ViewModels.Program;
using FCNuvem.FidelizaAluno.API.ViewModels.Class;
using FCNuvem.FidelizaAluno.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Evasao
{
    public class ListaEvasaoViewModel
    {
        public IEnumerable<ProgramViewModel> Programs { get; set; }
        public int IntervaloMin { get; set; }
        public int IntervaloMax { get; set; }
        public int TotalAlunos { get; set; }

        public void Fill(IEnumerable<ProgramEntity> Programs)
        {
            //this.Programs = Programs.Select(l => new ProgramViewModel
            //{
            //    Name = l.Name,
            //    Class = l.ClassRoom.Select(x => new ClassViewModel
            //    {
            //    })
            //});
        }
    }
}
