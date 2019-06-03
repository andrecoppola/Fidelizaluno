using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.Notification
{
    public class NotificationViewModel : IViewModelAdapter<NotificationEntity>
    {
        public string Name { get; set; }
        public string PersonId { get; set; }
        public DateTime? Data { get; set; }
        public string Reason { get; set; }


        public void Bind(NotificationEntity model)
        {
            model.Data = Data;
            model.PersonId = PersonId;
            model.Name = Name;
        }

        public void Fill(NotificationEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
