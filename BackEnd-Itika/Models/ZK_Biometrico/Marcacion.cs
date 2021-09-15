using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd_Itika.Models.ZK_Biometrico
{
    public partial class Marcacion
    {
        public int Id { get; set; }
        public int? IdEmpleado { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Marca { get; set; }

        public virtual EmpleadoZk IdEmpleadoNavigation { get; set; }
    }
}
