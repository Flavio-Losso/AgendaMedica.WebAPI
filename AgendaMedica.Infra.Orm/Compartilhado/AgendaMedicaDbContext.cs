using Microsoft.EntityFrameworkCore;
using AgendaMedica.Dominio.Compartilhado;
using AgendaMedica.Dominio.ModuloMedico;
using AgendaMedica.Dominio.ModuloAtividade;
using AgendaMedica.Infra.Orm.ModuloMedico;
using AgendaMedica.Infra.Orm.ModuloAtividade;

namespace AgendaMedica.Infra.Orm.Compartilhado
{
    public class AgendaMedicaDbContext : DbContext, IContextoPersistencia
    {
        public AgendaMedicaDbContext(DbContextOptions options) : base(options)
        {
        }      

        public async Task<bool> GravarAsync()
        {
            await SaveChangesAsync();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorMedicoOrm());

            modelBuilder.ApplyConfiguration(new MapeadorAtividadeOrm());

            base.OnModelCreating(modelBuilder);
        }

    }
}
