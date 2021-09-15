﻿// <auto-generated />
using System;
using BackEnd_Itika.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd_Itika.Migrations
{
    [DbContext(typeof(Biometrico_ItikaContext))]
    [Migration("20210828014915_initial-migrtion")]
    partial class initialmigrtion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd_Itika.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.AsignarTurno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaAsignacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_asignacion");

                    b.Property<DateTime>("HoraAsignacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_asignacion");

                    b.Property<int>("Idempleado")
                        .HasColumnType("int")
                        .HasColumnName("idempleado");

                    b.Property<int>("Idturno")
                        .HasColumnType("int")
                        .HasColumnName("idturno");

                    b.HasKey("Id");

                    b.HasIndex("Idturno");

                    b.ToTable("AsignarTurno");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Biometrico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora");

                    b.Property<int>("Idempleado")
                        .HasColumnType("int")
                        .HasColumnName("idempleado");

                    b.HasKey("Id");

                    b.ToTable("Biometrico");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("apellido");

                    b.Property<string>("CarnetIdentidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("carnet_identidad");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_nacimiento");

                    b.Property<int>("Idarea")
                        .HasColumnType("int")
                        .HasColumnName("idarea");

                    b.Property<byte[]>("ImagenBiometrico")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("imagen_biometrico");

                    b.Property<byte[]>("ImagenPerfil")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("imagen_perfil");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.HasIndex("Idarea");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.HoraExtra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoRandon")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("codigo_randon");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_entrada");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_salida");

                    b.Property<DateTime>("HoraEntrada")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_entrada");

                    b.Property<DateTime>("HoraSalida")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_salida");

                    b.Property<int>("Idempleado")
                        .HasColumnType("int")
                        .HasColumnName("idempleado");

                    b.Property<byte[]>("ImgHoraextra")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("img_horaextra");

                    b.Property<byte[]>("ImgQr")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("img_qr");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("motivo");

                    b.HasKey("Id");

                    b.ToTable("HoraExtra");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Permiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoRandon")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("codigo_randon");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha");

                    b.Property<DateTime>("HoraEntrada")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_entrada");

                    b.Property<DateTime>("HoraSalida")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_salida");

                    b.Property<int>("Idempleado")
                        .HasColumnType("int")
                        .HasColumnName("idempleado");

                    b.Property<int>("Idtipo")
                        .HasColumnType("int")
                        .HasColumnName("idtipo");

                    b.Property<byte[]>("ImgPermiso")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("img_permiso");

                    b.Property<byte[]>("ImgQr")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("img_qr");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("motivo");

                    b.HasKey("Id");

                    b.HasIndex("Idtipo");

                    b.ToTable("Permiso");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.PlanillaRecarga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Dominical")
                        .HasColumnType("datetime2")
                        .HasColumnName("dominical");

                    b.Property<bool?>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<bool?>("EstadoDominical")
                        .HasColumnType("bit")
                        .HasColumnName("estado_dominical");

                    b.Property<bool?>("EstadoFalta")
                        .HasColumnType("bit")
                        .HasColumnName("estado_falta");

                    b.Property<bool?>("EstadoFeriado")
                        .HasColumnType("bit")
                        .HasColumnName("estado_feriado");

                    b.Property<bool?>("EstadoRecargaNocturna")
                        .HasColumnType("bit")
                        .HasColumnName("estado_recarga_nocturna");

                    b.Property<bool?>("EstadoRetraso")
                        .HasColumnType("bit")
                        .HasColumnName("estado_retraso");

                    b.Property<DateTime?>("FechaEntrada")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_entrada");

                    b.Property<DateTime?>("FechaSalida")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_salida");

                    b.Property<DateTime?>("Feriado")
                        .HasColumnType("datetime2")
                        .HasColumnName("feriado");

                    b.Property<DateTime?>("HoraEntrada")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_entrada");

                    b.Property<DateTime?>("HoraEntrada1")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_entrada1");

                    b.Property<DateTime?>("HoraSalida")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_salida");

                    b.Property<DateTime?>("HoraSalida1")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_salida1");

                    b.Property<int>("Idempleado")
                        .HasColumnType("int")
                        .HasColumnName("idempleado");

                    b.Property<int?>("Idpermiso")
                        .HasColumnType("int")
                        .HasColumnName("idpermiso");

                    b.Property<DateTime?>("RecargaNocturna")
                        .HasColumnType("datetime2")
                        .HasColumnName("recarga_nocturna");

                    b.Property<DateTime?>("Retraso")
                        .HasColumnType("datetime2")
                        .HasColumnName("retraso");

                    b.Property<DateTime?>("Retraso2")
                        .HasColumnType("datetime2")
                        .HasColumnName("retraso2");

                    b.HasKey("Id");

                    b.HasIndex("Idpermiso");

                    b.ToTable("PlanillaRecarga");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Tipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<DateTime>("HoraEntrada")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_entrada");

                    b.Property<DateTime>("HoraEntrada1")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_entrada1");

                    b.Property<DateTime>("HoraSalida")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_salida");

                    b.Property<DateTime>("HoraSalida1")
                        .HasColumnType("datetime2")
                        .HasColumnName("hora_salida1");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Turno");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contraseña");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<int>("Idempleado")
                        .HasColumnType("int")
                        .HasColumnName("idempleado");

                    b.Property<int>("Idrol")
                        .HasColumnType("int")
                        .HasColumnName("idrol");

                    b.Property<int?>("Intentos")
                        .HasColumnType("int")
                        .HasColumnName("intentos");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.Property<string>("Pregunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("pregunta");

                    b.Property<string>("Respuesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("respuesta");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("token");

                    b.HasKey("Id");

                    b.HasIndex("Idrol");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.AsignarTurno", b =>
                {
                    b.HasOne("BackEnd_Itika.Models.Turno", "IdturnoNavigation")
                        .WithMany("AsignarTurnos")
                        .HasForeignKey("Idturno")
                        .HasConstraintName("FK_AsignarTurno_Turno")
                        .IsRequired();

                    b.Navigation("IdturnoNavigation");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Empleado", b =>
                {
                    b.HasOne("BackEnd_Itika.Models.Area", "IdareaNavigation")
                        .WithMany("Empleados")
                        .HasForeignKey("Idarea")
                        .HasConstraintName("FK_Empleado_Area")
                        .IsRequired();

                    b.Navigation("IdareaNavigation");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Permiso", b =>
                {
                    b.HasOne("BackEnd_Itika.Models.Tipo", "IdtipoNavigation")
                        .WithMany("Permisos")
                        .HasForeignKey("Idtipo")
                        .HasConstraintName("FK_Permiso_Tipo")
                        .IsRequired();

                    b.Navigation("IdtipoNavigation");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.PlanillaRecarga", b =>
                {
                    b.HasOne("BackEnd_Itika.Models.Permiso", "IdpermisoNavigation")
                        .WithMany("PlanillaRecargas")
                        .HasForeignKey("Idpermiso")
                        .HasConstraintName("FK_PlanillaRecarga_Permiso");

                    b.Navigation("IdpermisoNavigation");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Usuario", b =>
                {
                    b.HasOne("BackEnd_Itika.Models.Rol", "IdrolNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("Idrol")
                        .HasConstraintName("FK_Usuario_Rol")
                        .IsRequired();

                    b.Navigation("IdrolNavigation");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Area", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Permiso", b =>
                {
                    b.Navigation("PlanillaRecargas");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Tipo", b =>
                {
                    b.Navigation("Permisos");
                });

            modelBuilder.Entity("BackEnd_Itika.Models.Turno", b =>
                {
                    b.Navigation("AsignarTurnos");
                });
#pragma warning restore 612, 618
        }
    }
}
