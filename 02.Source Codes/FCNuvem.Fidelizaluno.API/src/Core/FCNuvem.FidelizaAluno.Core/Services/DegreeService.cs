using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class DegreeService : ServiceBase
    {
        public DegreeService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IDegreeRepository DegreeRepository => GetService<IDegreeRepository>();

        public void Save(DegreeEntity alunoEntity)
        {
            DegreeRepository.Save(alunoEntity);
        }
    }
}
