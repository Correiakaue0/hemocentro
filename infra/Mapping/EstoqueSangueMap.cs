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
    public class EstoqueSangueMap : IEntityTypeConfiguration<EstoqueSangue>
    {
        public void Configure(EntityTypeBuilder<EstoqueSangue> builder)
        {
            builder.ToTable("EstoqueSangue");

            builder.HasKey(x => x.Id);

            builder.Property(u => u.CodigoIdentificacao)
                .HasColumnName("CodigoIdentificacao")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.TipoSanguineo)
                .HasColumnName("TipoSanguineo")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.DataDaColeta)
                .HasColumnName("DataDaColeta")
                .IsRequired();

            builder.Property(u => u.Volume)
                .HasColumnName("Volume")
                .IsRequired();

            builder.HasOne(u => u.Doador)
            .WithMany(p => p.EstoquesSangue)
            .HasForeignKey(p => p.DoadorId);
        }
    }
}
