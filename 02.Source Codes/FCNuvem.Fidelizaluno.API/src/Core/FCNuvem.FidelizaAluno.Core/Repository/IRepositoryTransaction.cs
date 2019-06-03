using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository
{
    public interface IRepositoryTransaction : IDisposable
    {
        void Commit();
    }
}
