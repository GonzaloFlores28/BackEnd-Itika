using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd_Itika.Models
{
    [Table("Turno")]
    public partial class Turno
    {
        public Turno()
        {
            AsignarTurnos = new HashSet<AsignarTurno>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("hora_entrada")]
        public DateTime HoraEntrada { get; set; }
        [Column("hora_entrada1")]
        public DateTime HoraEntrada1 { get; set; }
        [Column("hora_salida")]
        public DateTime HoraSalida { get; set; }
        [Column("hora_salida1")]
        public DateTime HoraSalida1 { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }

        [InverseProperty(nameof(AsignarTurno.IdturnoNavigation))]
        public virtual ICollection<AsignarTurno> AsignarTurnos { get; set; }
    }
}
