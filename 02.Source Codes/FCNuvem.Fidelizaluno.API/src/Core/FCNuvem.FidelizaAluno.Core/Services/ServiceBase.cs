using FCNuvem.FidelizaAluno.Core.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FCNuvem.FidelizaAluno.Core.Services
{
    public abstract class ServiceBase
    {
        private readonly IServiceProvider _serviceProvider;

        protected ServiceBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected TService GetService<TService>()
        {
            if (typeof(IRepository).IsAssignableFrom(typeof(TService)))
            {
                return (TService)_serviceProvider.GetService<RepositoryFactory>().Create(typeof(TService));
            }

            return _serviceProvider.GetService<TService>();
        }

        protected IRepositoryTransaction InitTransaction() => _serviceProvider.GetService<RepositoryFactory>().InitTransaction();
    }
}
