using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class TaskService : ServiceBase
    {
        public TaskService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private ITaskRepository TaskRepository => GetService<ITaskRepository>();
        private ITaskReadOnlyRepository TaskReadOnlyRepository => GetService<ITaskReadOnlyRepository>();


        public void Save(TaskEntity alunoEntity)
        {
            TaskRepository.Save(alunoEntity);
        }
    }
}
