﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using infra.Context;

#nullable disable

namespace infra.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240902235143_estoque_sangue")]
    partial class estoque_sangue
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("domain.Entities.EstoqueSangue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CodigoIdentificacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataDaColeta")
                        .HasColumnType("datetime2");

                    b.Property<long>("DoadorId")
                        .HasColumnType("bigint");

                    b.Property<string>("TipoSanguineo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DoadorId");

                    b.ToTable("EstoqueSangue");
                });

            modelBuilder.Entity("domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Role");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("domain.Entities.Doadores", b =>
                {
                    b.HasBaseType("domain.Entities.User");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataNasc");

                    b.Property<string>("Peso")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Peso");

                    b.Property<string>("TipoSanguineo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("TipoSanguineo");

                    b.ToTable("Doadores", (string)null);
                });

            modelBuilder.Entity("domain.Entities.EstoqueSangue", b =>
                {
                    b.HasOne("domain.Entities.Doadores", "Doador")
                        .WithMany("EstoquesSangue")
                        .HasForeignKey("DoadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doador");
                });

            modelBuilder.Entity("domain.Entities.Doadores", b =>
                {
                    b.HasOne("domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("domain.Entities.Doadores", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("domain.Entities.Doadores", b =>
                {
                    b.Navigation("EstoquesSangue");
                });
#pragma warning restore 612, 618
        }
    }
}
