using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class CampusProgramService : ServiceBase
    {
        public CampusProgramService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private ICampusProgramRepository CampusProgramRepository => GetService<ICampusProgramRepository>();
        private ICampusProgramReadOnlyRepository CampusProgramReadOnlyRepository => GetService<ICampusProgramReadOnlyRepository>();


        public void Save(CampusProgramEntity alunoEntity)
        {
            CampusProgramRepository.Save(alunoEntity);
        }
    }
}
