using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AgendaMedica.Dominio.ModuloAtividade;

namespace AgendaMedica.Infra.Orm.ModuloAtividade
{
    public class MapeadorAtividadeOrm : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("TBAtividade");

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.HoraInicio)
                .IsRequired();

            builder.Property(x => x.HoraFim)
              .IsRequired();

            builder.Property(x => x.TipodeAtividade)
                .HasConversion<int>()
              .IsRequired();

            builder.Property(x => x.Descricao);
            builder.HasMany(x => x.Medico)
            .WithOne()
            .HasForeignKey("AtividadeId")
            .HasConstraintName("FK_TBAtividade_TBMedico");
        }
    }
}
