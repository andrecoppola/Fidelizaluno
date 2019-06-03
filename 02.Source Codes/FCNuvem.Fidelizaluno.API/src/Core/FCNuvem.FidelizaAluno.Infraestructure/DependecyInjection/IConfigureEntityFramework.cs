using FCNuvem.FidelizaAluno.Framework.Extenders;
using FCNuvem.FidelizaAluno.Infrastructure.Configurations;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.DependecyInjection
{
    public interface IConfigureEntityFramework
    {
        void Configure(IServiceCollection services, LoggerFactory loggerFactory);
    }

    public class ConfigureEntityFramework : IConfigureEntityFramework
    {
        public void Configure(IServiceCollection services, LoggerFactory loggerFactory)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<EfContext>((sp, b) =>
                    b.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                        .EnableSensitiveDataLogging(EnvironmentHelper.Desenvolvimento)
                        .UseSqlServer(sp.GetService<InfrastructureConfig>().ConnectionString)
                        .UseLoggerFactory(loggerFactory)
                        .UseInternalServiceProvider(sp)
                );
        }
    }
}
