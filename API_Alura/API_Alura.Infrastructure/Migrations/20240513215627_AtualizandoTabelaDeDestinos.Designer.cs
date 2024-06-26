﻿// <auto-generated />
using System;
using API_Alura.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Alura.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240513215627_AtualizandoTabelaDeDestinos")]
    partial class AtualizandoTabelaDeDestinos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API_Alura.Application.Models.Depoimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DepoimentoUsuario")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Depoimento");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Depoimentos", (string)null);
                });

            modelBuilder.Entity("API_Alura.Application.Models.Destino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("Foto1")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("Foto2")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Meta")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<string>("TextoDescritivo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Destinos");
                });
#pragma warning restore 612, 618
        }
    }
}
