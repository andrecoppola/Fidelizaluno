using FCNuvem.FidelizaAluno.Core.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class RepositoryTransaction : IRepositoryTransaction
    {
        private readonly IServiceProvider _serviceProvider;
        private IDbContextTransaction _transaction;

        public RepositoryTransaction(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        internal void BeginTransaction()
        {
            if (_serviceProvider.GetService<EfContext>().Database.CurrentTransaction != null)
            {
                return;
            }

            _transaction = _serviceProvider.GetService<EfContext>().Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            GC.SuppressFinalize(this);
        }

    }
}
