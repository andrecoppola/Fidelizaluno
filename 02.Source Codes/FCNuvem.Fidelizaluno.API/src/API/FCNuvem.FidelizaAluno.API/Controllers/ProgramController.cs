using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProgramController : APIBaseController
    {
        ProgramViewModelService ViewModelService => GetService<ProgramViewModelService>();


        [HttpGet]
        public ActionResult Get(int? IdCampus)
        {
            var vm = ViewModelService.GetPrograms(IdCampus);
            return Ok(vm);
        }
    }
}
