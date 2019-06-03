using FCNuvem.FidelizaAluno.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class DefaultRespositoryFactory : RepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DefaultRespositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override IRepository Create(Type iRepositoryType)
        {
            var repositoryType = GetType().Assembly.GetTypes()
                .FirstOrDefault(t => typeof(RepositoryBase).IsAssignableFrom(t) &&
                                     iRepositoryType.IsAssignableFrom(t));

            return (IRepository)_serviceProvider.GetService(repositoryType);
        }

        protected override IRepositoryTransaction InitTransaction()
        {
            var ts = new RepositoryTransaction(_serviceProvider);
            ts.BeginTransaction();

            return ts;
        }
    }
}
