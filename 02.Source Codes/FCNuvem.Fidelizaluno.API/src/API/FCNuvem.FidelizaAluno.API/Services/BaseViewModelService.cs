using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.Services
{
    public abstract class BaseViewModelService
    {
        private readonly IServiceProvider _serviceProvider;


        protected BaseViewModelService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected TService GetService<TService>() => _serviceProvider.GetService<TService>();

    }
}
