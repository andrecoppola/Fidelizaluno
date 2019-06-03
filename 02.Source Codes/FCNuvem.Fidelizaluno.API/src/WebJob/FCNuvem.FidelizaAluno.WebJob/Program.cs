using FCNuvem.FidelizaAluno.Framework.Configurations;
using FCNuvem.FidelizaAluno.WebJob.Internal;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Options;
using FCNuvem.FidelizaAluno.WebJob.Triggers.Jobs.Send;
using FCNuvem.FidelizaAluno.Core.DependecyInjection;
using FCNuvem.FidelizaAluno.Infrastructure.Configurations;
using FCNuvem.FidelizaAluno.Infrastructure.DependecyInjection;
using System;
using FCNuvem.FidelizaAluno.Framework.Extenders;
using Microsoft.Extensions.Logging;

namespace FCNuvem.FidelizaAluno.WebJob
{
    class Program
    {

        private static IConfigurationRoot Configuration { get; set; }


        static void Main(string[] args)
        {
            SetCulture();

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Environment.CurrentDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile(EnvironmentHelper.Desenvolvimento ? "appsettings.Development.json"
                   : EnvironmentHelper.Homologacao
                   ? "appsettings.Homologacao.json"
                   : "appsettings.Producao.json", optional: false, reloadOnChange: true)
               .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            Environment.SetEnvironmentVariable("AzureWebJobsStorage", Configuration["Infrastructure:Storage:ConnectionString"]);
            Environment.SetEnvironmentVariable("AzureWebJobsDashboard", Configuration["Infrastructure:Storage:ConnectionString"]);

            var builder = new HostBuilder()
                .UseEnvironment(Environment.GetEnvironmentVariable("WEBJOB_ENVIRONMENT"))
                .ConfigureWebJobs(b => b.AddAzureStorageCoreServices().AddAzureStorage())
                .ConfigureAppConfiguration(b => b.AddCommandLine(args))
                .ConfigureLogging((context, b) =>
                {
                    b.SetMinimumLevel(LogLevel.Debug);
                    b.AddConsole();

                    var appInsightsKey = Configuration["ApplicationInsights:InstrumentationKey"];
                    if (!string.IsNullOrEmpty(appInsightsKey))
                        b.AddApplicationInsights(o => o.InstrumentationKey = appInsightsKey);
                })

                .ConfigureServices(services =>
                {
                    ConfigureServices(services);
                    ConfigureFunctionsServices(services);
                })
                .UseConsoleLifetime();

            using (var host = builder.Build())
            {
                host.Run();
            }
        }

        private static void ConfigureServices(IServiceCollection services) => services
              .Configure<FrameworkConfig>(options => Configuration.GetSection(nameof(Framework)).Bind(options))
              .AddCore()
              .Configure<InfrastructureConfig>(options => Configuration.GetSection(nameof(Infrastructure)).Bind(options))
              .AddInfrastructure(sp => sp.GetService<IOptions<InfrastructureConfig>>().Value)
              .AddScoped<SendEmailFunction>()
              .AddSingleton<IJobActivator, WebJobActivator>()
              .AddSingleton<INameResolver, NameResolver>();


        private static void ConfigureFunctionsServices(IServiceCollection services)
        {
            services.AddSingleton<IJobActivator, WebJobActivator>()
                .AddSingleton<INameResolver, NameResolver>();

            var functionTypes = typeof(Program).Assembly.GetTypes()
                .Where(t => t.GetInterface(typeof(IFunction).FullName) != null);

            foreach (var item in functionTypes)
            {
                services.AddScoped(item);
            }
        }

        private static void SetCulture()
        {
            var culture = CultureInfo.GetCultureInfo("pt-BR");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

    }
}
