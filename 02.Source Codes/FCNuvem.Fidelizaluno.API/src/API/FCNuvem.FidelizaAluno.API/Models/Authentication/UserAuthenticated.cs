using FCNuvem.FidelizaAluno.API.Security.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.Models.Authentication
{
    public class UserAuthenticated: IUserAuthenticated
    {
        public string IdProfile { get; set; }
    }
}
