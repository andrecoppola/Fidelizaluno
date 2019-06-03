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
    public class CampusController : APIBaseController
    {
        CampusViewModelService ViewModelService => GetService<CampusViewModelService>();


        [HttpGet]
        public ActionResult Get()
        {
            var vm = ViewModelService.GetCampus();
            return Ok(vm);
        }

    }
}
