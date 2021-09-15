using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd_Itika.Models
{
    [Table("Rol")]
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }

        [InverseProperty(nameof(Usuario.IdrolNavigation))]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
