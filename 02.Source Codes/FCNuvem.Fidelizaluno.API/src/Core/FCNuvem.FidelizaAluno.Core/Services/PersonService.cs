using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class PersonService : ServiceBase
    {
        public PersonService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IPersonRepository PersonRepository => GetService<IPersonRepository>();
        private IPersonReadOnlyRepository PersonReadOnlyRepository => GetService<IPersonReadOnlyRepository>();


        public void Save(PersonEntity alunoEntity)
        {
            PersonRepository.Save(alunoEntity);
        }
    }
}
