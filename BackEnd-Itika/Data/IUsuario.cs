using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public interface IUsuario
    {
        List<Usuario> ListarUsuarios();
        Usuario Add_Usuario(Usuario usuario);
        Usuario Get_Usuario(int Id);
        Usuario Delete_USUARIO(Usuario usuario);
        Usuario Update_USUARIO(Usuario usuario);
    }
}
