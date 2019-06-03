using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class TaskRepository : RepositoryBase<TaskEntity>, ITaskRepository
    {
        public TaskRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}
    }
}
