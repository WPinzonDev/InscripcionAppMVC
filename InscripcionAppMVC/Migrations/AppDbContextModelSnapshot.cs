﻿// <auto-generated />
using System;
using InscripcionAppMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InscripcionAppMVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InscripcionAppMVC.Models.Aspirante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aspirantes");
                });

            modelBuilder.Entity("InscripcionAppMVC.Models.Inscripcion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AspiranteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProgramaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoAspiranteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AspiranteId");

                    b.HasIndex("ProgramaId");

                    b.HasIndex("TipoAspiranteId");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("InscripcionAppMVC.Models.Programa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Programas");
                });

            modelBuilder.Entity("InscripcionAppMVC.Models.TipoAspirante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TiposAspirante");
                });

            modelBuilder.Entity("InscripcionAppMVC.Models.Inscripcion", b =>
                {
                    b.HasOne("InscripcionAppMVC.Models.Aspirante", "Aspirante")
                        .WithMany()
                        .HasForeignKey("AspiranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InscripcionAppMVC.Models.Programa", "Programa")
                        .WithMany()
                        .HasForeignKey("ProgramaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InscripcionAppMVC.Models.TipoAspirante", "TipoAspirante")
                        .WithMany()
                        .HasForeignKey("TipoAspiranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aspirante");

                    b.Navigation("Programa");

                    b.Navigation("TipoAspirante");
                });
#pragma warning restore 612, 618
        }
    }
}