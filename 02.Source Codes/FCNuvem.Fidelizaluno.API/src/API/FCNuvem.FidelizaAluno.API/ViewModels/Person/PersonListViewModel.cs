using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Person
{
    public class ListaPersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Inadimplente { get;  set; }
        public decimal? Frequencia { get; set; }
        public decimal? MediaScores { get; set; }

        private decimal? chanceEvasao;

        public decimal? ChanceEvasao
        {
            get { return chanceEvasao * 100; }
            set { chanceEvasao = value; }
        }

        public string UrlFoto { get; internal set; }
        public string ReasonEvasao { get; internal set; }
    }
}
