using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class NotificationRepository : RepositoryBase<NotificationEntity>, INotificationRepository
    {
        public NotificationRepository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        public void RemoverTodos()
        {
            DbContext.Notification.RemoveRange(DbContext.Notification);
            DbContext.SaveChanges();
        }
    }
}
