﻿// <auto-generated />
using System;
using LogicaAccesoDatos.BaseDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    partial class LibreriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LogicaNegocio.Dominio.Fase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaIncio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Fases");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FaseId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FaseId");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoISOAlfa3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<double>("Pbi")
                        .HasColumnType("float");

                    b.Property<int>("Poblacion")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadGolesEquipoDos")
                        .HasColumnType("int");

                    b.Property<int>("CantidadGolesEquipoUno")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hora")
                        .HasColumnType("int");

                    b.Property<int>("IdEquipoDos")
                        .HasColumnType("int");

                    b.Property<int>("IdEquipoUno")
                        .HasColumnType("int");

                    b.Property<int>("PuntajeEquipoDos")
                        .HasColumnType("int");

                    b.Property<int>("PuntajeEquipoUno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipoDos");

                    b.HasIndex("IdEquipoUno");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regiones");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Seleccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadApostadores")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdGrupo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int?>("PaisId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdGrupo");

                    b.HasIndex("PaisId");

                    b.ToTable("Selecciones");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Tarjeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("PartidoId")
                        .HasColumnType("int");

                    b.Property<int>("SeleccionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId");

                    b.HasIndex("SeleccionId");

                    b.ToTable("Tarjetas");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Grupo", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Fase", "Fase")
                        .WithMany()
                        .HasForeignKey("FaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Pais", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Partido", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Seleccion", "EquipoDos")
                        .WithMany()
                        .HasForeignKey("IdEquipoDos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Seleccion", "EquipoUno")
                        .WithMany()
                        .HasForeignKey("IdEquipoUno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Seleccion", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("IdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Tarjeta", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Partido", "Partido")
                        .WithMany()
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Seleccion", "Seleccion")
                        .WithMany()
                        .HasForeignKey("SeleccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
