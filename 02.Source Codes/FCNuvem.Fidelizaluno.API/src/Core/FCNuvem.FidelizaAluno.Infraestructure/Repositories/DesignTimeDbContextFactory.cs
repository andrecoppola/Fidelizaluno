using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;

namespace FCNuvem.FidelizaAluno.Infrastructure.Repositories
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EfContext>
    {
        public EfContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EfContext>();
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseSqlServer(args?.FirstOrDefault() ??
            "Server=tcp:srv-fidelizalunodb.database.windows.net,1433;Initial Catalog=FidelizalunoDB;Persist Security Info=False;User ID=admindb;Password=abc1234!@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            //"Server=localhost;Initial Catalog=FidelizalunoDB;User Id=sa;Password=Abc1234!@"
            );

            return new EfContext(optionsBuilder.Options);
        }
    }
}
