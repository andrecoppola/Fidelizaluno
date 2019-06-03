using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Core.Repository
{
    public abstract class RepositoryFactory
    {
        protected internal abstract IRepository Create(Type repositoryType);

        protected internal abstract IRepositoryTransaction InitTransaction();
    }
}
