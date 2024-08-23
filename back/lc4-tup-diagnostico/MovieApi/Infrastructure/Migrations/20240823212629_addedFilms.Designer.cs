﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240823212629_addedFilms")]
    partial class addedFilms
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Domain.Entities.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DirectorId");

                    b.ToTable("Directores");

                    b.HasData(
                        new
                        {
                            DirectorId = 1,
                            Nombre = "Chris Columbus"
                        },
                        new
                        {
                            DirectorId = 2,
                            Nombre = "Peter Jackson"
                        },
                        new
                        {
                            DirectorId = 3,
                            Nombre = "Lana Wachowski"
                        },
                        new
                        {
                            DirectorId = 4,
                            Nombre = "Damián Szifron"
                        },
                        new
                        {
                            DirectorId = 5,
                            Nombre = "Israel Adrián Caetano"
                        },
                        new
                        {
                            DirectorId = 6,
                            Nombre = "Alejandro Doria"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Funcion", b =>
                {
                    b.Property<int>("IdFuncion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("Hora")
                        .HasColumnType("TEXT");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("IdFuncion");

                    b.HasIndex("PeliculaId");

                    b.ToTable("Funciones");
                });

            modelBuilder.Entity("Domain.Entities.Pelicula", b =>
                {
                    b.Property<int>("IdPelicula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DirectorPeliculaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombrePelicula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrigenPelicula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdPelicula");

                    b.HasIndex("DirectorPeliculaId");

                    b.ToTable("Peliculas");

                    b.HasData(
                        new
                        {
                            IdPelicula = 1,
                            DirectorPeliculaId = 1,
                            NombrePelicula = "Harry Potter y el prisionero de Azkaban",
                            OrigenPelicula = "Internacional"
                        },
                        new
                        {
                            IdPelicula = 2,
                            DirectorPeliculaId = 2,
                            NombrePelicula = "El señor de los anillos",
                            OrigenPelicula = "Internacional"
                        },
                        new
                        {
                            IdPelicula = 3,
                            DirectorPeliculaId = 3,
                            NombrePelicula = "Matrix",
                            OrigenPelicula = "Internacional"
                        },
                        new
                        {
                            IdPelicula = 4,
                            DirectorPeliculaId = 4,
                            NombrePelicula = "Relatos Salvajes",
                            OrigenPelicula = "Nacional"
                        },
                        new
                        {
                            IdPelicula = 5,
                            DirectorPeliculaId = 5,
                            NombrePelicula = "Pizza, birra, faso",
                            OrigenPelicula = "Nacional"
                        },
                        new
                        {
                            IdPelicula = 6,
                            DirectorPeliculaId = 6,
                            NombrePelicula = "Esperando la carroza",
                            OrigenPelicula = "Nacional"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Funcion", b =>
                {
                    b.HasOne("Domain.Entities.Pelicula", "Pelicula")
                        .WithMany()
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("Domain.Entities.Pelicula", b =>
                {
                    b.HasOne("Domain.Entities.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorPeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });
#pragma warning restore 612, 618
        }
    }
}
