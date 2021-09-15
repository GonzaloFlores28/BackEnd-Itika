using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

#nullable disable

namespace BackEnd_Itika.Models
{
    [Table("Empleado")]
    public partial class Empleado
    {
        public Empleado()
        {
            PlanillaRecargas = new HashSet<PlanillaRecarga>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("idarea")]
        public int Idarea { get; set; }
        [Required]
        [Column("nombre")]
        public string Nombre { get; set; }
        [Required]
        [Column("apellido")]
        public string Apellido { get; set; }
        [Required]
        [Column("carnet_identidad")]
        public string CarnetIdentidad { get; set; }
        [Column("fecha_nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Column("imagen_perfil")]
        public byte[] ImagenPerfil { get; set; }
        [Column("imagen_biometrico")]
        public byte[] ImagenBiometrico { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Idarea))]
        [InverseProperty(nameof(Area.Empleados))]
        public virtual Area IdareaNavigation { get; set; }
        [JsonIgnore]
        [InverseProperty(nameof(PlanillaRecarga.IdempleadoNavigation))]
        public virtual ICollection<PlanillaRecarga> PlanillaRecargas { get; set; }
    }
}
