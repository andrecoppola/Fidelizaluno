using FCNuvem.FidelizaAluno.API.ViewModels.Task;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Services;
using System;


namespace FCNuvem.FidelizaAluno.API.Services
{
    public class TaskViewModelService : BaseViewModelService
    {
        public TaskViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private TaskService TaskService => GetService<TaskService>();
        private ITaskReadOnlyRepository TaskReadOnlyRepository => GetService<ITaskReadOnlyRepository>();

        public void Save(TaskViewModel vm)
        {
            var entity = new TaskEntity(0);
            //vm.Bind(entity);
            TaskService.Save(entity);
        }
    }
}
