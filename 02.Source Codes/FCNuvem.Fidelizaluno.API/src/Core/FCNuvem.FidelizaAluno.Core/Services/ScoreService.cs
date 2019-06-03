using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class ScoreService : ServiceBase
    {
        public ScoreService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IScoreRepository ScoreRepository => GetService<IScoreRepository>();
        private IScoreReadOnlyRepository ScoreReadOnlyRepository => GetService<IScoreReadOnlyRepository>();


        public void Save(ScoreEntity alunoEntity)
        {
            ScoreRepository.Save(alunoEntity);
        }
    }
}
