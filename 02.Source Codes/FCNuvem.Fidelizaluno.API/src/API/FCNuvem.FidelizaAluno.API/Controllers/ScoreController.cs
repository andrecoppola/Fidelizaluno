using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.API.ViewModels;
using FCNuvem.FidelizaAluno.API.ViewModels.Score;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScoreController : APIBaseController
    {
        ScoreViewModelService ViewModelService => GetService<ScoreViewModelService>();

        [HttpPost]
        public ActionResult Post([FromBody] ScoreViewModel vm)
        {
            ViewModelService.Save(vm);
            return Ok();
        }

    }
}
