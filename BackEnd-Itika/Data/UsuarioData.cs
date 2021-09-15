using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public class UsuarioData : IUsuario
    {
        private readonly Biometrico_ItikaContext _itikaContext;

        public UsuarioData(Biometrico_ItikaContext itikaContext)
        {
            _itikaContext = itikaContext;
        }
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> listado = _itikaContext.Usuarios.ToList();
            return listado;
        }

        public Usuario Add_Usuario(Usuario usuario)
        {
            usuario.Estado = true;
            var listado = ListarUsuarios();
            if (listado != null )
            {
                foreach (var item in listado)
                {
                    if (usuario.Nombre != item.Nombre)                    
                    {
                        _itikaContext.Usuarios.Add(usuario);
                        _itikaContext.SaveChanges();
                    }
                    else
                    {
                        usuario = null;
                    }
                }
            }            
            return usuario;
        }

        //
        public Usuario Get_Usuario(int Id)
        {
            var _usuario = _itikaContext.Usuarios.Find(Id);
            return _usuario;
        }

        public Usuario Delete_USUARIO(Usuario usuario)
        {
            var exiteasignar = _itikaContext.Usuarios.Find(usuario.Id);
            if (exiteasignar != null)
            {
                usuario.Estado = false;
                _itikaContext.Usuarios.Update(usuario);
                _itikaContext.SaveChanges();
            }
            return usuario;
        }

        public Usuario Update_USUARIO(Usuario usuario)
        {
            var exiteArea = _itikaContext.Usuarios.Find(usuario.Id);
            if (exiteArea != null)
            {
                _itikaContext.Usuarios.Update(usuario);
                _itikaContext.SaveChanges();
            }
            return usuario;
        }
    }
}
