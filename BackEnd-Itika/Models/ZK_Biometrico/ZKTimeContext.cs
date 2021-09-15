using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd_Itika.Models.ZK_Biometrico
{
    public partial class ZKTimeContext : DbContext
    {
        public ZKTimeContext()
        {
        }

        public ZKTimeContext(DbContextOptions<ZKTimeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmpleadoZk> EmpleadoZks { get; set; }
        public virtual DbSet<Marcacion> Marcacions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=ZKTime;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EmpleadoZk>(entity =>
            {
                entity.ToTable("EmpleadoZK");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido).HasColumnName("apellido");

                entity.Property(e => e.Nombre).HasColumnName("nombre");
            });

            modelBuilder.Entity<Marcacion>(entity =>
            {
                entity.ToTable("Marcacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

                entity.Property(e => e.Marca).HasColumnName("marca");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Marcacions)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK_Marcacion_Empleado1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
