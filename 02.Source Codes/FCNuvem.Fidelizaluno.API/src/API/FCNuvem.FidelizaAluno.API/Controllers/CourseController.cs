using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.API.ViewModels;
using FCNuvem.FidelizaAluno.API.ViewModels.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : APIBaseController
    {
        CourseViewModelService ViewModelService => GetService<CourseViewModelService>();

        [HttpPost]
        public ActionResult Post([FromBody] CourseViewModel vm)
        {
            ViewModelService.Save(vm);
            return Ok();
        }

        [HttpGet]
        [Route("Class/{idClass}")]
        public ActionResult GetByClass(int idClass)
        {
            var vm = ViewModelService.GetByClass(idClass);
            return Ok(vm);
        }
    }
}
