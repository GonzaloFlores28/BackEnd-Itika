using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd_Itika.Models
{
    [Table("Permiso")]
    public partial class Permiso
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idtipo")]
        public int Idtipo { get; set; }
        [Column("idempleado")]
        public int Idempleado { get; set; }
        [Required]
        [Column("motivo")]
        public string Motivo { get; set; }
        [Column("fecha")]
        public DateTime Fecha { get; set; }
        [Column("hora_entrada")]
        public DateTime HoraEntrada { get; set; }
        [Column("hora_salida")]
        public DateTime HoraSalida { get; set; }
        [Column("img_permiso")]
        public byte[] ImgPermiso { get; set; }
        [Column("img_qr")]
        public byte[] ImgQr { get; set; }
        [Column("codigo_randon")]
        public string CodigoRandon { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }
        [Column("idplanillarecarga")]
        public int? Idplanillarecarga { get; set; }

        [ForeignKey(nameof(Idplanillarecarga))]
        [InverseProperty(nameof(PlanillaRecarga.Permisos))]
        public virtual PlanillaRecarga IdplanillarecargaNavigation { get; set; }
        [ForeignKey(nameof(Idtipo))]
        [InverseProperty(nameof(Tipo.Permisos))]
        public virtual Tipo IdtipoNavigation { get; set; }
    }
}
