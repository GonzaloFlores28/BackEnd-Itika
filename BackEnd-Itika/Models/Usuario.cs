using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd_Itika.Models
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idempleado")]
        public int Idempleado { get; set; }
        [Column("idrol")]
        public int Idrol { get; set; }
        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
        [Required]
        [Column("email")]
        public string Email { get; set; }
        [Required]
        [Column("contraseña")]
        public string Contraseña { get; set; }
        [Required]
        [Column("pregunta")]
        public string Pregunta { get; set; }
        [Required]
        [Column("respuesta")]
        public string Respuesta { get; set; }
        [Column("intentos")]
        public int? Intentos { get; set; }
        [Column("token")]
        public string Token { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }

        [ForeignKey(nameof(Idrol))]
        [InverseProperty(nameof(Rol.Usuarios))]
        public virtual Rol IdrolNavigation { get; set; }
    }
}
