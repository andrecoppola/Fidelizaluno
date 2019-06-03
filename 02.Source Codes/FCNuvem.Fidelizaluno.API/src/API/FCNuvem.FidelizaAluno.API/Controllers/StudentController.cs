using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.API.ViewModels.Student;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : APIBaseController
    {
        StudentViewModelService ViewModelService => GetService<StudentViewModelService>();

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            var vm = ViewModelService.GetStudent(id);
            return Ok(vm);
        }

        [HttpGet]
        public ActionResult Get(string name, int? idProgram, int? idClassRoom, int? RA, int? IdCampus)
        {
            var vm = ViewModelService.GetStudent(name, idProgram, idClassRoom, RA, IdCampus);
            return Ok(vm);
        }

        [HttpGet]
        [Route("ClassRoom/{idClassRoom}")]
        public ActionResult StudentByClass(int idClassRoom)
        {
            var vm = ViewModelService.GetStudentByClassRoom(idClassRoom);
            return Ok(vm);
        }

        [HttpPost]
        public ActionResult Post([FromBody] StudentViewModel vm)
        {
            ViewModelService.Save(vm);
            return Ok(new { sucess = true });
        }
    }
}
