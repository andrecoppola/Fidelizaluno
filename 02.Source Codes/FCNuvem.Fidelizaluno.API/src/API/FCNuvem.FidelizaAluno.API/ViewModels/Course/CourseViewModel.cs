using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Course
{
    public class CourseViewModel : IViewModelAdapter<CourseEntity>
    {
        public string Name { get; set; }

        public int CargaHoraria { get; set; }
        public int Id { get; set; }

        public void Bind(CourseEntity model)
        {
            model.Name = Name;
        }

        public void Fill(CourseEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
