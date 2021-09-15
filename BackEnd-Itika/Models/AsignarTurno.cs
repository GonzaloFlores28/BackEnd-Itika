using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd_Itika.Models
{
    [Table("AsignarTurno")]
    public partial class AsignarTurno
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idturno")]
        public int Idturno { get; set; }
        [Column("idempleado")]
        public int Idempleado { get; set; }
        [Column("fecha_asignacion")]
        public DateTime FechaAsignacion { get; set; }
        [Column("hora_asignacion")]
        public DateTime HoraAsignacion { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }

        [ForeignKey(nameof(Idturno))]
        [InverseProperty(nameof(Turno.AsignarTurnos))]
        public virtual Turno IdturnoNavigation { get; set; }
    }
}
