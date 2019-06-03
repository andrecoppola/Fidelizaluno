using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Payment
{
    public class PaymentViewModel : IViewModelAdapter<PaymentEntity>
    {
        public decimal Valor { get; set; }
        public int IdProgram { get; set; }
        public int IdPerson { get; set; }
        public DateTime DataPagamento { get; set; }

        public void Bind(PaymentEntity model)
        {
            model.Valor = Valor;
            model.IdStudent = IdPerson;
            model.Data = DataPagamento;
        }

        public void Fill(PaymentEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
