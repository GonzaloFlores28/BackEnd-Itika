using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd_Itika.Models
{
    [Table("Tipo")]
    public partial class Tipo
    {
        public Tipo()
        {
            Permisos = new HashSet<Permiso>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }

        [InverseProperty(nameof(Permiso.IdtipoNavigation))]
        public virtual ICollection<Permiso> Permisos { get; set; }
    }
}
