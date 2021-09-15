using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Models.DTOs
{
    public class UsuarioInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public Byte[] imagen_perfil { get; set; }
    }
}
