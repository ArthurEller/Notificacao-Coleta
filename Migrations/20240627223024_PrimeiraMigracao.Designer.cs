﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotificacaoColetaApi.Data;

#nullable disable

namespace NotificacaoColetaApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240627223024_PrimeiraMigracao")]
    partial class PrimeiraMigracao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NotificacaoColetaApi.Models.Coleta", b =>
                {
                    b.Property<int>("ColetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColetaId"));

                    b.Property<DateTime>("DataColeta")
                        .HasColumnType("datetime2");

                    b.Property<string>("TipoResiduos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColetaId");

                    b.ToTable("Coleta", (string)null);
                });

            modelBuilder.Entity("NotificacaoColetaApi.Models.Notificacao", b =>
                {
                    b.Property<int>("NotificacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificacaoId"));

                    b.Property<int?>("ColetaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificacaoId");

                    b.HasIndex("ColetaId");

                    b.ToTable("Notificacao", (string)null);
                });

            modelBuilder.Entity("NotificacaoColetaApi.Models.Notificacao", b =>
                {
                    b.HasOne("NotificacaoColetaApi.Models.Coleta", "Coleta")
                        .WithMany()
                        .HasForeignKey("ColetaId");

                    b.Navigation("Coleta");
                });
#pragma warning restore 612, 618
        }
    }
}
