using FCNuvem.FidelizaAluno.API.ViewModels.Score;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Services;
using System;


namespace FCNuvem.FidelizaAluno.API.Services
{
    public class ScoreViewModelService : BaseViewModelService
    {
        public ScoreViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private ScoreService ScoreService => GetService<ScoreService>();
        private IScoreReadOnlyRepository ScoreReadOnlyRepository => GetService<IScoreReadOnlyRepository>();

        public void Save(ScoreViewModel vm)
        {
            var entity = new ScoreEntity(0);
            vm.Bind(entity);
            ScoreService.Save(entity);
        }
    }
}
