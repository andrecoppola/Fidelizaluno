using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class InstitutionService : ServiceBase
    {
        public InstitutionService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IInstitutionRepository InstitutionRepository => GetService<IInstitutionRepository>();
        private IInstitutionReadOnlyRepository InstitutionReadOnlyRepository => GetService<IInstitutionReadOnlyRepository>();


        public void Save(InstitutionEntity alunoEntity)
        {
            InstitutionRepository.Save(alunoEntity);
        }
    }
}
