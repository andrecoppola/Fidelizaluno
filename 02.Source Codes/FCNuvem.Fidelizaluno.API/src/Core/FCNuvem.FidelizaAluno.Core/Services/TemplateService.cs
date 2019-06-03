using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class TemplateService : ServiceBase
    {
        public TemplateService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private ITemplateRepository TemplateRepository => GetService<ITemplateRepository>();
        private ITemplateReadOnlyRepository TemplateReadOnlyRepository => GetService<ITemplateReadOnlyRepository>();


        public void Save(TemplateEntity alunoEntity)
        {
            TemplateRepository.Save(alunoEntity);
        }
    }
}
