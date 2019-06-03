using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.API.ViewModels.Period;
using FCNuvem.FidelizaAluno.API.ViewModels.Person;
using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Class
{
    public class ClassRoomViewModel : IViewModelAdapter<ClassRoomEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdProgram { get; set; }
        public string Semestre { get; set; }
        public DateTime? DataInicial { get; set; }
        public IEnumerable<ListaPersonViewModel> Alunos { get; set; }
        public PeriodViewModel Period { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Amount { get; set; }

        public void Bind(ClassRoomEntity model)
        {
            model.Name = Name;
            model.IdProgram = IdProgram ?? 0;
            model.Half = Semestre;
            model.DataInicial = DataInicial ?? new DateTime();
        }

        public void Fill(ClassRoomEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
