using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Score
{
    public class ScoreViewModel : IViewModelAdapter<ScoreEntity>
    {
        public int IdCourse { get; set; }
        public int IdStudent { get; set; }
        public decimal Valor { get; set; }

        public void Bind(ScoreEntity model)
        {
            model.IdCourse = IdCourse;
            model.IdStudent = IdStudent;
            model.Value = Valor;
        }

        public void Fill(ScoreEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
