using domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.Mapping
{
    public class ConsultaMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("Consulta");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.AgendamentoId);
            builder.Property(c => c.DataConsulta);
            builder.Property(c => c.Status).HasMaxLength(50);
            builder.Property(c => c.Observacoes).HasMaxLength(500);
            builder.Property(c => c.DuracaoMinutos).IsRequired();
            builder.Property(c => c.TipoConsulta).HasMaxLength(50);
            builder.Property(c => c.DataCriacao).IsRequired();

            builder.HasOne(c => c.Agendamento)
                   .WithMany()
                   .HasForeignKey("AgendamentoId");
        }
    }
}
