using FCNuvem.FidelizaAluno.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes
{
    public class AddressOwnedType
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Municipio { get; set; }
        public EUf? Uf { get; set; }
        public string Complemento { get; set; }
        public string CodigoMunicipio { get; set; }


        internal AddressOwnedType()
        { }
    }
}
