using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd_Itika.Models
{
    [Table("Area")]
    public partial class Area
    {
        public Area()
        {
            Empleados = new HashSet<Empleado>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }

        [InverseProperty(nameof(Empleado.IdareaNavigation))]
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
