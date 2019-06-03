using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.API.ViewModels.Shared;
using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Institution
{
    public class InstitutionViewModel : IViewModelAdapter<InstitutionEntity>
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public string Media { get; set; }
        public AddressViewModel Address { get; set; } = new AddressViewModel();

        public void Bind(InstitutionEntity model)
        {
            model.Name = Name;
            model.Cnpj = Cnpj;
            model.Telephone = Telephone;
            model.Email = Email;
            model.Media = Media;
        }

        public void Fill(InstitutionEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
