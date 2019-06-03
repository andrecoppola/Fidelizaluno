using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.Security.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    public class BaseController<TUserAuthenticated> : Controller
           where TUserAuthenticated : IUserAuthenticated
    {
        protected TService GetService<TService>() => (TService)HttpContext.RequestServices.GetService(typeof(TService));
    }
}