﻿// <auto-generated />
using System;
using CartaoVacina.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CartaoVacina.DataAccess.Migrations
{
    [DbContext(typeof(CartaoVacinaContext))]
    [Migration("20240422224458_Add-TipoDose-Vacinacao")]
    partial class AddTipoDoseVacinacao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CartaoVacina.Core.Entities.CadernetaVacina", b =>
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

                    b.ToTable("CadernetaVacina", (string)null);
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

                    b.Property<long>("CadernetaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroDose")
                        .HasColumnType("int");

                    b.Property<int>("TipoDose")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<long>("VacinaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CadernetaId");

                    b.HasIndex("VacinaId");

                    b.ToTable("Vacinacao", (string)null);
                });

            modelBuilder.Entity("CartaoVacina.Core.Entities.CadernetaVacina", b =>
                {
                    b.HasOne("CartaoVacina.Core.Entities.Pessoa", "Pessoa")
                        .WithOne("CadernetaVacina")
                        .HasForeignKey("CartaoVacina.Core.Entities.CadernetaVacina", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CartaoVacina.Core.Entities.Vacinacao", b =>
                {
                    b.HasOne("CartaoVacina.Core.Entities.CadernetaVacina", "Caderneta")
                        .WithMany("Vacinacoes")
                        .HasForeignKey("CadernetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CartaoVacina.Core.Entities.Vacina", "Vacina")
                        .WithMany()
                        .HasForeignKey("VacinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caderneta");

                    b.Navigation("Vacina");
                });

            modelBuilder.Entity("CartaoVacina.Core.Entities.CadernetaVacina", b =>
                {
                    b.Navigation("Vacinacoes");
                });

            modelBuilder.Entity("CartaoVacina.Core.Entities.Pessoa", b =>
                {
                    b.Navigation("CadernetaVacina")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
