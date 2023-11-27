using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AgendaMedica.Infra.Orm.Compartilhado
{
    public class AgendaMedicaDbContextFactory : IDesignTimeDbContextFactory<AgendaMedicaDbContext>
    {
        public AgendaMedicaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AgendaMedicaDbContext>();

            IConfiguration configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new AgendaMedicaDbContext(optionsBuilder.Options);

            return dbContext;
        }
    }
}
