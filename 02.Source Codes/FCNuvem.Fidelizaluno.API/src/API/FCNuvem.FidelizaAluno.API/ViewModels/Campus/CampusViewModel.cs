using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.API.ViewModels.Institution;
using FCNuvem.FidelizaAluno.API.ViewModels.Shared;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Campus
{
    public class CampusViewModel : IViewModelAdapter<CampusEntity>
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public ECampusType? CampusType { get; set; }

        public InstitutionViewModel Institution { get; set; }
        public int? IdInstituition { get; set; }

        public AddressViewModel Address { get; set; }
        public int IdAddress { get; set; }
        public int Id { get; internal set; }

        public void Bind(CampusEntity model)
        {
            throw new NotImplementedException();
        }

        public void Fill(CampusEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
