using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.Models.Interfaces
{
    public interface IViewModelAdapter<in TModel> where TModel : EntityBase
    {
        void Bind(TModel model);

        void Fill(TModel model);
    }
}
