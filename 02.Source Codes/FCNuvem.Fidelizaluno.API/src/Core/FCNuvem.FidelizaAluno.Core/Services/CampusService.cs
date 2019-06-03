using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class CampusService : ServiceBase
    {
        public CampusService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private ICampusRepository CampusRepository => GetService<ICampusRepository>();
        private ICampusReadOnlyRepository CampusReadOnlyRepository => GetService<ICampusReadOnlyRepository>();


        public void Save(CampusEntity alunoEntity)
        {
            CampusRepository.Save(alunoEntity);
        }
    }
}
