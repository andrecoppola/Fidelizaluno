using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public class NotificationService : ServiceBase
    {
        public NotificationService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private INotificationRepository NotificationRepository => GetService<INotificationRepository>();
        private INotificationReadOnlyRepository NotificationReadOnlyRepository => GetService<INotificationReadOnlyRepository>();


        public void Save(NotificationEntity alunoEntity)
        {
            NotificationRepository.Save(alunoEntity);
        }


        public void DeleteAll()
        {
            NotificationRepository.RemoverTodos();
        }
    }
}
