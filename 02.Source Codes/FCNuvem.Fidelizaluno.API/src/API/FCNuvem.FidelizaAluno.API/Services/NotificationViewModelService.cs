using FCNuvem.FidelizaAluno.API.ViewModels.Notification;
using FCNuvem.FidelizaAluno.Core.Entities;
using FCNuvem.FidelizaAluno.Core.Entities.OwnedTypes;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FCNuvem.FidelizaAluno.API.Services
{
    public class NotificationViewModelService : BaseViewModelService
    {
        public NotificationViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private NotificationService NotificationService => GetService<NotificationService>();
        private INotificationReadOnlyRepository NotificationReadOnlyRepository => GetService<INotificationReadOnlyRepository>();
        private IWantedReadOnlyRepository WantedReadOnlyRepository => GetService<IWantedReadOnlyRepository>();

        internal void DeleteAll()
        {
            NotificationService.DeleteAll();
        }

        public void Save(NotificationViewModel vm)
        {
            var entity = new NotificationEntity(0);
            vm.Bind(entity);
            NotificationService.Save(entity);
        }

        internal IEnumerable<NotificationViewModel> GetNotification()
        {
            var personsIdCapturados = NotificationReadOnlyRepository.GetAll().Select(q => q.PersonId).Distinct();
            var procurados = WantedReadOnlyRepository.RetornarWanteds(personsIdCapturados);

            return procurados.Select(l => new NotificationViewModel
            {
                Reason = l.Reason?.Name,
                Name = l.Name,
                PersonId = l.PersonId,
                //Todo pegar a hora correta da notificação
                Data = DateTime.Now
            });
        }
    }
}
