using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.Services
{
    public class PersonViewModelService : BaseViewModelService
    {
        public PersonViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private PersonService ReasonService => GetService<PersonService>();
        private IPersonReadOnlyRepository ReasonReadOnlyRepository => GetService<IPersonReadOnlyRepository>();
    }
}
