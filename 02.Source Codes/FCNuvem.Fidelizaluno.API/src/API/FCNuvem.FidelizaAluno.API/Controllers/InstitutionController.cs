using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.API.ViewModels;
using FCNuvem.FidelizaAluno.API.ViewModels.Institution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InstitutionController : APIBaseController
    {
        InstitutionViewModelService ViewModelService => GetService<InstitutionViewModelService>();

        [HttpPost]
        public ActionResult Post([FromBody] InstitutionViewModel vm)
        {
            ViewModelService.Save(vm);
            return Ok();
        }

    }
}
