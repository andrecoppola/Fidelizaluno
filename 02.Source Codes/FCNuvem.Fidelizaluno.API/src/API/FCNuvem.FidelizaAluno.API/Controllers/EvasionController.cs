using FCNuvem.FidelizaAluno.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EvasionController : APIBaseController
    {
        EvasaoViewModelService ViewModelService => GetService<EvasaoViewModelService>();

        [HttpGet]
        [Route("Students/{min}/{max}/{idClassRoom}")]
        public ActionResult Get(int min, int max, int? IdClassRoom, int? IdCampus)
        {
            var vm = ViewModelService.GetStudents(min, max, IdCampus, IdClassRoom);
            return Ok(vm);
        }

        [HttpGet]
        [Route("Amount/{min}/{max}")]
        public ActionResult GetAmount(int min, int max, int? idCampus)
        {
            var vm = ViewModelService.GetAmount(min, max, idCampus);
            return Ok(new {
                min,
                max,
                amount = vm
            });
        }

        [HttpGet]
        [Route("Program/{min}/{max}")]
        public ActionResult GetProgram(int min, int max, int? IdCampus)
        {
            var vm = ViewModelService.GetProgram(min, max, IdCampus);
            return Ok(new {
                min,
                max,
                data = vm
            });
        }
    }
}