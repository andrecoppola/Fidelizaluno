using Microsoft.Azure.WebJobs.Host;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace FCNuvem.FidelizaAluno.WebJob.Internal
{
    public class WebJobActivator : IJobActivator
    {
        private readonly IServiceProvider _serviceProvider;

        public WebJobActivator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T CreateInstance<T>() => _serviceProvider.GetService<T>();
    }
}
