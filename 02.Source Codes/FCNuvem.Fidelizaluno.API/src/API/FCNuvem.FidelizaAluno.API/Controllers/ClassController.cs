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
    public class ClassController : APIBaseController
    {
        ClassViewModelService ViewModelService => GetService<ClassViewModelService>();

        [HttpGet]
        public ActionResult Get(int? IdClassRoom, int? IdCourse)
        {
            var vm = ViewModelService.GetAll(IdClassRoom, IdCourse);
            return Ok(vm);
        }
    }
}