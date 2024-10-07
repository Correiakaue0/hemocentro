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
    public class DoadoresMap : IEntityTypeConfiguration<Doadores>
    {
        public void Configure(EntityTypeBuilder<Doadores> builder)
        {
            builder.ToTable("Doadores");

            builder.Property(u => u.Peso)
                .HasColumnName("Peso")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Telafone)
                .HasColumnName("Telafone")
                .IsRequired();

            builder.Property(u => u.DataNasc)
                .HasColumnName("DataNasc")
                .IsRequired();

            builder.Property(u => u.TipoSanguineo)
                .HasColumnName("TipoSanguineo")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
