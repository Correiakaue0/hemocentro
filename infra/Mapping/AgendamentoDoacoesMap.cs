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
    public class AgendamentoDoacoesMap : IEntityTypeConfiguration<AgendamentoDoacoes>
    {
        public void Configure(EntityTypeBuilder<AgendamentoDoacoes> builder)
        {
            builder.ToTable("AgendamentoDoacoes");

            builder.HasKey(x => x.Id);

            builder.Property(u => u.Codigo)
                .HasColumnName("Codigo")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(u => u.DataAgendamento)
                .HasColumnName("DataAgendamento")
                .IsRequired();

            builder.Property(u => u.Local)
                .HasColumnName("Local")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(u => u.Doador)
                .WithMany(p => p.AgendamentoDoacoes)
                .HasForeignKey(p => p.DoadorId);
        }
    }
}
