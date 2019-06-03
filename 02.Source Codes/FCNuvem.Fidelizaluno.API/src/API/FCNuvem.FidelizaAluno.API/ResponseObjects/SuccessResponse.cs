using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ResponseObjects
{
    public class SuccessResponse : ResponseModelBase
    {
        public SuccessResponse(object data) : base(data)
        {
            Sucess = true;
        }
    }
}
