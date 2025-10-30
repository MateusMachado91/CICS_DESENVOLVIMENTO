using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PYBWeb.Infrastructure.Helpers;

namespace PYBWeb.Infrastructure.Data
{
    public class AmbienteDbContextFactory : IDesignTimeDbContextFactory<AmbienteDbContext>
    {
        public AmbienteDbContext CreateDbContext(string[] args)
        {
            // Carregar configuração
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AmbienteDbContext>();
            var connectionString = DataPathHelper.GetConnectionString(configuration, "ambiente.db");
            optionsBuilder.UseSqlite(connectionString);

            return new AmbienteDbContext(connectionString);
        }
    }
}