using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.API.Resource;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using FCNuvem.FidelizaAluno.Core.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Shared
{
    public class AddressViewModel : IViewModelAdapter<AddressEntity>
    {

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Region { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }


        public void Bind(AddressEntity model)
        {
            throw new NotImplementedException();
        }

        public void Fill(AddressEntity model)
        {
            if (model == null)
                return;

            AddressLine1 = model.AddressLine1;
            AddressLine2 = model.AddressLine2;
            Region = model.Region;
            Number = model.Number;
            City = model.City;
            State = model.State;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
        }
    }
}
