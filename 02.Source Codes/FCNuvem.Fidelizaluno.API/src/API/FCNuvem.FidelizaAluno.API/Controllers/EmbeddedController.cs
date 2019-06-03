using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmbeddedController : APIBaseController
    {
        EmbeddedViewModelService ViewModelService => GetService<EmbeddedViewModelService>();

        [HttpGet]
        public async Task<ActionResult> Index(string username, string roles)
        {
            await ViewModelService.EmbedReport(username, roles);
            var embedded = ViewModelService.EmbedConfig;
            return Ok(embedded);
        }
    }
}