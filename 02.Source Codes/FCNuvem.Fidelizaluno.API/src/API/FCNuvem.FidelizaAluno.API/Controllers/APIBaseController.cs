using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Configuration;
using FCNuvem.FidelizaAluno.API.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    public class APIBaseController : BaseController<UserAuthenticated>
    {
        protected APIConfiguration APIConfiguration => HttpContext.RequestServices.GetService<IOptions<APIConfiguration>>().Value;
    }
}