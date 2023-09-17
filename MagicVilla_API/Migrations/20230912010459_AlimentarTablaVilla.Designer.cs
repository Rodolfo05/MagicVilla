﻿// <auto-generated />
using System;
using MagicVilla_API.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVillaAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230912010459_AlimentarTablaVilla")]
    partial class AlimentarTablaVilla
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_API.Modelos.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("int");

                    b.Property<double>("Tarifa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Detalle = "detalle 1",
                            FechaActualizacion = new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2634),
                            FechaCreacion = new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2543),
                            ImagenUrl = "",
                            MetrosCuadrados = 200,
                            Nombre = "Vira",
                            Ocupantes = 10,
                            Tarifa = 3000.0
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Detalle = "detalle 2",
                            FechaActualizacion = new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2642),
                            FechaCreacion = new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2639),
                            ImagenUrl = "",
                            MetrosCuadrados = 2330,
                            Nombre = "Monstaf",
                            Ocupantes = 20,
                            Tarifa = 2000.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
