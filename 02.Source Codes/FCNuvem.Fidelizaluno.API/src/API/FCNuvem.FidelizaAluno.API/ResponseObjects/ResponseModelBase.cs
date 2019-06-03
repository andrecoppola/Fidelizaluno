using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ResponseObjects
{
    public abstract class ResponseModelBase
    {
        protected ResponseModelBase(object data)
        {
            Data = data;
        }

        public bool Sucess { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public object Data { get; private set; }
    }
}
