using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.API.ViewModels;
using FCNuvem.FidelizaAluno.API.ViewModels.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : APIBaseController
    {
        NotificationViewModelService ViewModelService => GetService<NotificationViewModelService>();

        [HttpPost]
        [Route("Set")]
        public ActionResult Set([FromBody] NotificationViewModel vm)
        {
            ViewModelService.Save(vm);
            return Ok();
        }


        [HttpPost]
        [Route("DeleteAll")]
        public ActionResult DeleteAll()
        {
            ViewModelService.DeleteAll();
            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var vm = ViewModelService.GetNotification().ToList();

            //TODO: Retirar depois da apresentação do dia 20
            vm.Add(new NotificationViewModel
            {
                Data = DateTime.Now.AddDays(-1),
                Reason = "Wanted Pela Policia",
                Name = "Fabio Camara",
                PersonId = "dcc1cab3-3c13-4e13-b41f-9a3ffef04ab6"
            });

            vm.Add(new NotificationViewModel
            {
                Data = DateTime.Now.AddDays(-1),
                Reason = "Desaparecido",
                Name = "Daniel Maia",
                PersonId = "60ccff3d-9b9c-49cd-a3cd-2732d60266e9"
            });
          
            vm.Add(new NotificationViewModel
            {
                Data = DateTime.Now.AddDays(-1),
                Reason = "Desaparecido",
                Name = "Leandro Lousada",
                PersonId = "2885937c-d674-4dc8-9418-a45b0daa7266"
            });

            vm.Add(new NotificationViewModel
            {
                Data = DateTime.Now.AddDays(-1),
                Reason = "Wanted Pela Policia",
                Name = "Fabiano Brito",
                PersonId = "83489564-fa8d-45eb-a7d9-34b709955692"
            });


            return Ok(vm);
        }
    }
}
