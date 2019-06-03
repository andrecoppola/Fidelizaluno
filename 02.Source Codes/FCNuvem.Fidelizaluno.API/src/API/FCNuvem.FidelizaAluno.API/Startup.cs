using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using FCNuvem.FidelizaAluno.API.Configuration;
using FCNuvem.FidelizaAluno.API.Services;
using FCNuvem.FidelizaAluno.Core.DependecyInjection;
using FCNuvem.FidelizaAluno.Framework.Extenders;
using FCNuvem.FidelizaAluno.Infrastructure.Configurations;
using FCNuvem.FidelizaAluno.Infrastructure.DependecyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication;
using FCNuvem.FidelizaAluno.Core.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FCNuvem.FidelizaAluno.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
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
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterViewModelServices(services);

            services
                .Configure<InfrastructureConfig>(options => Configuration.GetSection(nameof(Infrastructure)).Bind(options))
                .AddCore()
                .AddInfrastructure(sp => sp.GetService<IOptions<InfrastructureConfig>>().Value)
                .Configure<EmbeddedConfig>(options => Configuration.GetSection(nameof(Core)).Bind(options))
                .Configure<APIConfiguration>(options => Configuration.GetSection(nameof(API)).Bind(options))
                .AddCors();

            services
             .AddAuthentication(sharedOptions =>
             {
                 sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
             })
             .AddJwtBearer(options =>
             {
                 options.Audience = Configuration["AzureAd:ClientId"];
                 options.Authority = $"{Configuration["AzureAd:Instance"]}{Configuration["AzureAd:TenantId"]}";
             });

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Populate;
                    options.SerializerSettings.Culture = new CultureInfo("pt-BR");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        private static void RegisterViewModelServices(IServiceCollection services)
        {
            var servicesType = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(BaseViewModelService).IsAssignableFrom(t) && t.BaseType != typeof(object));

            foreach (var type in servicesType)
                services.AddScoped(type);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
