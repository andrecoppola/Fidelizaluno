using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.API.ViewModels;
using FCNuvem.FidelizaAluno.API.ViewModels.Degree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DegreeController : APIBaseController
    {
        DegreeViewModelService ViewModelService => GetService<DegreeViewModelService>();

        [HttpPost]
        public ActionResult Post([FromBody] DegreeViewModel vm)
        {
            ViewModelService.Save(vm);
            return Ok();
        }


        [HttpGet]
        [Route("ClassRoom/{idClassRoom}")]
        public ActionResult Get(int idClassRoom)
        {
            IEnumerable<DegreeViewModel> vm = ViewModelService.GetByClassRoom(idClassRoom);
            return Ok(new { sucess = true, data = vm });
        }
    }
}
