using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.API.ViewModels;
using FCNuvem.FidelizaAluno.API.ViewModels.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClassRoomController : APIBaseController
    {
        ClassRoomViewModelService ViewModelService => GetService<ClassRoomViewModelService>();

        [HttpGet]
        [Route("Program/{idProgram}")]
        public ActionResult ClassRoom(int idProgram)
        {
            var x = HttpContext.User;
            var vm = ViewModelService.GetClassRoomByProgram(idProgram);
            return Ok(vm);
        }

        [HttpGet]
        public ActionResult Get(int? IdCampus)
        {
            var vm = ViewModelService.GetAll(IdCampus);
            return Ok(vm);
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] ClassRoomViewModel vm)
        {
            ViewModelService.Save(vm);
            return Ok();
        }

    }
}
