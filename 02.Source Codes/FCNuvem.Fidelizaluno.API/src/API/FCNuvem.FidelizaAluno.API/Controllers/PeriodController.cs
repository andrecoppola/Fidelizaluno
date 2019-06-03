using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PeriodController : APIBaseController
    {
        PeriodViewModelService ViewModelService => GetService<PeriodViewModelService>();


        [HttpGet]
        public ActionResult GetAll(int? idClass, int? idProgram)
        {
            var vm = ViewModelService.GetAll(idClass, idProgram);
            return Ok(vm);
        }


    }
}