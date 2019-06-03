using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class DegreeCourseService : ServiceBase
    {
        public DegreeCourseService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IDegreeCourseRepository DegreeCourseRepository => GetService<IDegreeCourseRepository>();
        private IDegreeCourseReadOnlyRepository DegreeCourseReadOnlyRepository => GetService<IDegreeCourseReadOnlyRepository>();


        public void Save(DegreeCourseEntity alunoEntity)
        {
            DegreeCourseRepository.Save(alunoEntity);
        }
    }
}
