﻿// <auto-generated />
using System;
using CartaoVacina.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CartaoVacina.DataAccess.Migrations
{
    [DbContext(typeof(CartaoVacinaContext))]
    partial class CartaoVacinaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CartaoVacina.Core.Entities.CardenetaVacina", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<long>("PessoaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("CardenetaVacina", (string)null);
                });

            modelBuilder.Entity("CartaoVacina.Core.Entities.Pessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Pessoa", (string)null);
                });

            modelBuilder.Entity("CartaoVacina.Core.Entities.Vacina", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("QuantidadeDoses")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeReforcos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vacina", (string)null);
                });

            modelBuilder.Entity("CartaoVacina.Core.Entities.Vacinacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CardenetaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroDose")
                        .HasColumnType("int");

                    b.Property<long>("VacinaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CardenetaId");

                    b.HasIndex("VacinaId");

                    b.ToTable("Vacinacao", (string)null);
                });

            modelBuilder.Entity("CartaoVacina.Core.Entities.CardenetaVacina", b =>
                {
                    b.HasOne("CartaoVacina.Core.Entities.Pessoa", "Pessoa")
                        .WithOne("CardenetaVacina")
                        .HasForeignKey("CartaoVacina.Core.Entities.CardenetaVacina", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CartaoVacina.Core.Entities.Vacinacao", b =>
                {
                    b.HasOne("CartaoVacina.Core.Entities.CardenetaVacina", "Cardeneta")
                        .WithMany("Vacinacoes")
                        .HasForeignKey("CardenetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CartaoVacina.Core.Entities.Vacina", "Vacina")
                        .WithMany()
                        .HasForeignKey("VacinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cardeneta");

                    b.Navigation("Vacina");
                });

            modelBuilder.Entity("CartaoVacina.Core.Entities.CardenetaVacina", b =>
                {
                    b.Navigation("Vacinacoes");
                });

            modelBuilder.Entity("CartaoVacina.Core.Entities.Pessoa", b =>
                {
                    b.Navigation("CardenetaVacina")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
