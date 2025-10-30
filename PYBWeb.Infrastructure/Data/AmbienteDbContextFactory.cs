using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PYBWeb.Infrastructure.Data
{
    public class AmbienteDbContextFactory : IDesignTimeDbContextFactory<AmbienteDbContext>
    {
        public AmbienteDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AmbienteDbContext>();
            var connectionString = "Data Source=Z:\\CICS APP\\PYB001 - SOLICITACOES\\DATA\\ambiente.db";
            optionsBuilder.UseSqlite(connectionString);

            return new AmbienteDbContext(connectionString);
        }
    }
}