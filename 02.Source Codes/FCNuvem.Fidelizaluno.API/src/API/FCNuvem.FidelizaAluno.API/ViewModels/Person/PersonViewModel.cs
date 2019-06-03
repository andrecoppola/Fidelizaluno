using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.API.ViewModels.Shared;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Person
{
    public class PersonViewModel : IViewModelAdapter<PersonEntity>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string TelephoneCelular { get; set; }
        public string TelephoneResidencial { get; set; }
        public char Genre { get; set; }
        public bool? Overdue { get; set; }
        public string UrlPicture { get; set; }

        public AddressViewModel Address { get; set; }

        public void Bind(PersonEntity model)
        {
            throw new NotImplementedException();
        }

        public void Fill(PersonEntity model)
        {
            if (model == null)
                return;

            Name = model.Name;
            Email = model.Email;
            Cpf = model.Cpf;
            TelephoneCelular = model.TelephoneCelular;
            TelephoneResidencial = model.TelephoneResidencial;
            Genre = model.Genre;
            UrlPicture = model.UrlPicture;

            Address = new AddressViewModel();
            Address.Fill(model.Address);
        }
    }
}
