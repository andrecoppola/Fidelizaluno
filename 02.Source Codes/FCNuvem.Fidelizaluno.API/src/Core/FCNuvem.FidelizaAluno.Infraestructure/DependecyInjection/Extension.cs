using FCNuvem.FidelizaAluno.Core.Interfaces.CloudServices.Email;
using FCNuvem.FidelizaAluno.Core.Repository;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Infraestructure.Email;
using FCNuvem.FidelizaAluno.Infrastructure.Configurations;
using FCNuvem.FidelizaAluno.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace FCNuvem.FidelizaAluno.Infrastructure.DependecyInjection
{
    public static class Extension
    {
        private const string ConfigSectionName = nameof(Infrastructure);

        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            Func<IServiceProvider, InfrastructureConfig> infrastructureConfigFactory,
            ILoggerProvider efContextLoggerProvider = null,
            IConfigureEntityFramework configureEntityFramework = null,
            bool useAuditoria = false)
        {
            var repositoriesImplemented = GetRepositoriesImplemented();

            services = services
                .AddSingleton(infrastructureConfigFactory)
                .AddEntityFramework(configureEntityFramework, efContextLoggerProvider, useAuditoria)
                .AddInfrastructureRepositories(repositoriesImplemented)
                .AddReadOnlyRepositories(repositoriesImplemented)
                .AddEmailServices()
                .AddCudOperationFactory()
                .AddHttpClients();

            return services;
        }

        private static IServiceCollection AddEmailServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailClient, EmailClient>();

            return services;
        }

        private static List<Type> GetRepositoriesImplemented()
        {
            var implementationsType = typeof(Extension).Assembly.GetTypes()
                .Where(t => typeof(RepositoryBase).IsAssignableFrom(t) &&
                       !t.IsGenericType &&
                       t.BaseType != typeof(object)
                      );

            return implementationsType.ToList();
        }

        private static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services, IEnumerable<Type> repositoriesImplemented)
        {
            foreach (var implementationType in repositoriesImplemented)
            {
                services.AddScoped(implementationType);
            }

            return services;
        }

        private static IServiceCollection AddReadOnlyRepositories(this IServiceCollection services, IEnumerable<Type> repositoriesImplemented)
        {
            foreach (var implementationType in repositoriesImplemented)
            {
                var repositoryInterface = implementationType.GetInterfaces()
                    .FirstOrDefault(i => i.GetInterface(typeof(IReadOnlyRepository<,>).FullName) != null &&
                                         i.GetInterface(typeof(IRepository<,>).FullName) == null &&
                                         i.Name != typeof(IReadOnlyRepository<>).Name);

                services.AddScoped(repositoryInterface, sp => sp.GetService(implementationType));
            }

            return services;
        }

        private static IServiceCollection AddCudOperationFactory(this IServiceCollection services) =>
           services.AddScoped<RepositoryFactory, DefaultRespositoryFactory>();

        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfigureEntityFramework configureEntityFramework, ILoggerProvider efContextLoggerProvider,
             bool useAuditoria)
        {
            LoggerFactory loggerFactory = null;
            if (efContextLoggerProvider != null)
            {
                loggerFactory = new LoggerFactory();
                loggerFactory.AddProvider(efContextLoggerProvider);
            }


            configureEntityFramework = configureEntityFramework ?? new ConfigureEntityFramework();
            configureEntityFramework.Configure(services, loggerFactory);

            return services;
        }

        private static IServiceCollection AddHttpClients(this IServiceCollection services)
        {

            //TODO: Exception: HttpClientLoggingHandler
            //services.AddHttpClient<IContaCorrenteClient, ContaCorrenteClient>()
            //    .AddHttpMessageHandler(sp =>
            //    {

            //        return new HttpClientLoggingHandler(sp.GetService<InfrastructureConfig>()?.Storage,
            //            sp.GetService<IAppLogger>(),
            //            typeof(ContaCorrenteClient).Name,
            //            IdentificadorLog);
            //    });

            return services;
        }

        private static string IdentificadorLog(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("RequestId", out var values))
                return values.FirstOrDefault() ?? Guid.NewGuid().ToString();

            return Guid.NewGuid().ToString();
        }
    }

    public static class IQueryableExtensions
    {
        private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

        private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");

        private static readonly FieldInfo QueryModelGeneratorField = QueryCompilerTypeInfo.DeclaredFields.First(x => x.Name == "_queryModelGenerator");

        private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");

        private static readonly PropertyInfo DatabaseDependenciesField = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");

        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            var queryCompiler = (QueryCompiler)QueryCompilerField.GetValue(query.Provider);
            var modelGenerator = (QueryModelGenerator)QueryModelGeneratorField.GetValue(queryCompiler);
            var queryModel = modelGenerator.ParseQuery(query.Expression);
            var database = (IDatabase)DataBaseField.GetValue(queryCompiler);
            var databaseDependencies = (DatabaseDependencies)DatabaseDependenciesField.GetValue(database);
            var queryCompilationContext = databaseDependencies.QueryCompilationContextFactory.Create(false);
            var modelVisitor = (RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
            modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
            var sql = modelVisitor.Queries.First().ToString();

            return sql;
        }
    }
}
