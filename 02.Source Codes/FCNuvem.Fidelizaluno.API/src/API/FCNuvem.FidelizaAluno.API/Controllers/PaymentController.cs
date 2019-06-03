using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.API.ViewModels;
using FCNuvem.FidelizaAluno.API.ViewModels.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : APIBaseController
    {
        PaymentViewModelService ViewModelService => GetService<PaymentViewModelService>();

        [HttpPost]
        public ActionResult Post([FromBody] PaymentViewModel vm)
        {
            ViewModelService.Save(vm);
            return Ok();
        }

    }
}

