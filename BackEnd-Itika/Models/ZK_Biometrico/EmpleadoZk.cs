using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd_Itika.Models.ZK_Biometrico
{
    public partial class EmpleadoZk
    {
        public EmpleadoZk()
        {
            Marcacions = new HashSet<Marcacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<Marcacion> Marcacions { get; set; }
    }
}
