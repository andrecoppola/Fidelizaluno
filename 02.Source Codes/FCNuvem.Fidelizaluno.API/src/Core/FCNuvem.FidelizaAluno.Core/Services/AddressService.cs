using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class AddressService : ServiceBase
    {
        public AddressService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IAddressRepository AddressRepository => GetService<IAddressRepository>();
        private IAddressReadOnlyRepository AddressReadOnlyRepository => GetService<IAddressReadOnlyRepository>();


        public void Save(AddressEntity alunoEntity)
        {
            AddressRepository.Save(alunoEntity);
        }
    }
}
