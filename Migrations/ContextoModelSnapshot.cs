﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroTecnicos.DAL;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("RegistroTecnicos.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float?>("Sueldohora")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.Property<int>("TipoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TecnicoId");

                    b.HasIndex("TipoId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tipostecnicos", b =>
                {
                    b.Property<int>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TipoId");

                    b.ToTable("Tipostecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.Property<int>("TrabajoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Monto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TrabajoId");

                    b.ToTable("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Tipostecnicos", "Tipostecnicos")
                        .WithMany("Tecnicos")
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipostecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tipostecnicos", b =>
                {
                    b.Navigation("Tecnicos");
                });
#pragma warning restore 612, 618
        }
    }
}
