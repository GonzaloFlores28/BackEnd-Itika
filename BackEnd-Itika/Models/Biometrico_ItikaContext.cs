using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd_Itika.Models
{
    public partial class Biometrico_ItikaContext : DbContext
    {
        public Biometrico_ItikaContext(DbContextOptions<Biometrico_ItikaContext> options)
            : base(options)
        {
        }

        //public Biometrico_ItikaContext()
        //{

        //}

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<AsignarTurno> AsignarTurnos { get; set; }
        public virtual DbSet<Biometrico> Biometricos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<HoraExtra> HoraExtras { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<PlanillaRecarga> PlanillaRecargas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=Biometrico_Itika;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AsignarTurno>(entity =>
            {
                entity.HasOne(d => d.IdturnoNavigation)
                    .WithMany(p => p.AsignarTurnos)
                    .HasForeignKey(d => d.Idturno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AsignarTurno_Turno");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasOne(d => d.IdareaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Idarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Area");
            });

            modelBuilder.Entity<HoraExtra>(entity =>
            {
                entity.Property(e => e.CodigoRandon).IsUnicode(false);
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasOne(d => d.IdplanillarecargaNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.Idplanillarecarga)
                    .HasConstraintName("FK_Permiso_PlanillaRecarga");

                entity.HasOne(d => d.IdtipoNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.Idtipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permiso_Tipo");
            });

            modelBuilder.Entity<PlanillaRecarga>(entity =>
            {
                entity.HasOne(d => d.IdempleadoNavigation)
                    .WithMany(p => p.PlanillaRecargas)
                    .HasForeignKey(d => d.Idempleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanillaRecarga_Empleado");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
