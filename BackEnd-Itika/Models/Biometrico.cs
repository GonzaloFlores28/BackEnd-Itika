using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

#nullable disable

namespace BackEnd_Itika.Models
{
    [Table("Biometrico")]
    public partial class Biometrico
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idempleado")]
        public int Idempleado { get; set; }
        [Column("fecha")]
        public DateTime Fecha { get; set; }
        [Column("hora")]
        public DateTime Hora { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }
    }
}
