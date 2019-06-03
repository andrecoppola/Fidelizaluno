using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class ProgramService : ServiceBase
    {
        public ProgramService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IProgramRepository ProgramRepository => GetService<IProgramRepository>();
        private IProgramReadOnlyRepository ProgramReadOnlyRepository => GetService<IProgramReadOnlyRepository>();


        public void Save(ProgramEntity alunoEntity)
        {
            ProgramRepository.Save(alunoEntity);
        }
    }
}
