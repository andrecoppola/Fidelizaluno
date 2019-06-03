using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class PresenceService : ServiceBase
    {
        public PresenceService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IPresenceRepository PresenceRepository => GetService<IPresenceRepository>();
        private IPresenceReadOnlyRepository PresenceReadOnlyRepository => GetService<IPresenceReadOnlyRepository>();


        public void Save(IEnumerable<PresenceEntity> alunosEntities)
        {
            PresenceRepository.Save(alunosEntities, l => true);
        }

        public void Save(PresenceEntity studentEntity)
        {
            PresenceRepository.Save(studentEntity, studentEntity.Id == 0);
        }
    }
}
