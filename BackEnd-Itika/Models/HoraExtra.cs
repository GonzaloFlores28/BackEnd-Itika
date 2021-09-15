using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd_Itika.Models
{
    [Table("HoraExtra")]
    public partial class HoraExtra
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idempleado")]
        public int Idempleado { get; set; }
        [Column("fecha_entrada")]
        public DateTime FechaEntrada { get; set; }
        [Column("fecha_salida")]
        public DateTime FechaSalida { get; set; }
        [Column("hora_entrada")]
        public DateTime HoraEntrada { get; set; }
        [Column("hora_salida")]
        public DateTime HoraSalida { get; set; }
        [Required]
        [Column("motivo")]
        public string Motivo { get; set; }
        [Column("img_horaextra")]
        public byte[] ImgHoraextra { get; set; }
        [Column("img_qr")]
        public byte[] ImgQr { get; set; }
        [Column("codigo_randon")]
        public string CodigoRandon { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }
    }
}
