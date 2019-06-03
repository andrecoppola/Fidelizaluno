using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCNuvem.FidelizaAluno.API.ResponseObjects;
using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.Framework.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FCNuvem.FidelizaAluno.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : APIBaseController
    {
        UserViewModelService ViewModelService => GetService<UserViewModelService>();

        [HttpPost]
        [Route("Validate")]
        public ActionResult Post()
        {
            try
            {
                var email = HttpContext.User.Identity.Name;
                var response = ViewModelService.ValidateLogin(email);
                return Ok(new SuccessResponse(response));
            }
            catch (Exception)
            {
                return BadRequest(new BadRequestResponse("Not Found"));
            }
        }
    }
}