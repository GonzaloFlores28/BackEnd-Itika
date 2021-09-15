using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd_Itika.Models
{
    [Table("PlanillaRecarga")]
    public partial class PlanillaRecarga
    {
        public PlanillaRecarga()
        {
            Permisos = new HashSet<Permiso>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idempleado")]
        public int Idempleado { get; set; }
        [Column("fecha_entrada")]
        public DateTime? FechaEntrada { get; set; }
        [Column("fecha_salida")]
        public DateTime? FechaSalida { get; set; }
        [Column("hora_entrada")]
        public DateTime? HoraEntrada { get; set; }
        [Column("hora_entrada1")]
        public DateTime? HoraEntrada1 { get; set; }
        [Column("hora_salida")]
        public DateTime? HoraSalida { get; set; }
        [Column("hora_salida1")]
        public DateTime? HoraSalida1 { get; set; }
        [Column("retraso")]
        public DateTime? Retraso { get; set; }
        [Column("retraso2")]
        public DateTime? Retraso2 { get; set; }
        [Column("estado_retraso")]
        public bool? EstadoRetraso { get; set; }
        [Column("recarga_nocturna")]
        public DateTime? RecargaNocturna { get; set; }
        [Column("estado_recarga_nocturna")]
        public bool? EstadoRecargaNocturna { get; set; }
        [Column("feriado")]
        public DateTime? Feriado { get; set; }
        [Column("estado_feriado")]
        public bool? EstadoFeriado { get; set; }
        [Column("dominical")]
        public DateTime? Dominical { get; set; }
        [Column("estado_dominical")]
        public bool? EstadoDominical { get; set; }
        [Column("estado_falta")]
        public bool? EstadoFalta { get; set; }
        [Column("estado")]
        public bool? Estado { get; set; }

        [ForeignKey(nameof(Idempleado))]
        [InverseProperty(nameof(Empleado.PlanillaRecargas))]
        public virtual Empleado IdempleadoNavigation { get; set; }
        [InverseProperty(nameof(Permiso.IdplanillarecargaNavigation))]
        public virtual ICollection<Permiso> Permisos { get; set; }
    }
}
