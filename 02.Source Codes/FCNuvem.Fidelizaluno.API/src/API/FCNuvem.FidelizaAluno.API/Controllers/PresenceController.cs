using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.ResponseObjects;
using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.API.ViewModels.Presence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PresenceController : APIBaseController
    {
        PresenceViewModelService ViewModelService => GetService<PresenceViewModelService>();

        [HttpPost]
        public ActionResult Post([FromBody] PresenceListViewModel vm)
        {
            ViewModelService.Save(vm);
            return Ok(new SuccessResponse(null));
        }


        [HttpPost]
        [Route("Recognition")]
        public ActionResult Recognition([FromBody] PresenceCognitionViewModel vm)
        {
            try
            {
                ViewModelService.Save(vm);
                return Ok(new SuccessResponse(null));
            }
            catch (Exception e)
            {
                return BadRequest(new BadRequestResponse("Aluno ou aula não encontrada", null));
            }
        }

        [HttpGet]
        [Route("Class/{IdClass}/{day}/{month}/{year}")]
        public ActionResult Get(int IdClass, int day, int month, int year)
        {
            try
            {
                DateTime date = new DateTime(year, month, day);
                IEnumerable<PresenceViewModel> vm = ViewModelService.GetByClass(IdClass, date);
                return Ok(new SuccessResponse(vm));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("Absent/{day}/{month}/{year}")]
        public ActionResult GetAbsent(int day, int month, int year, int? idPeriod = null, int? idProgram = null, int? IdClassRoom = null, int? idCampus = null)
        {
            try
            {
                DateTime date = new DateTime(year, month, day);
                IEnumerable<AbsentViewModel> vm = ViewModelService.GetAbsent(date, idPeriod, idProgram, IdClassRoom, idCampus);
                return Ok(new SuccessResponse(vm));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
