using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AgendaMedica.Dominio.ModuloMedico;

namespace AgendaMedica.Infra.Orm.ModuloMedico
{
    public class MapeadorMedicoOrm : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("TBMedico");

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Nome)
                .IsRequired();
            builder.Property(x => x.Crm).IsRequired();

            //builder.Property(x => x.PodeRealizarAtividade);

            builder.HasMany(x => x.Atividades);
        }
    }
}
