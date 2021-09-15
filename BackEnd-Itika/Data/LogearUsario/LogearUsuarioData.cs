using BackEnd_Itika.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_Itika.Models;

namespace BackEnd_Itika.Data.LogearUsario
{
    public class LogearUsuarioData : ILogearUsuario
    {
        private readonly Biometrico_ItikaContext _itikaContext;
        private readonly IEmpleado _empleado;
        

        public LogearUsuarioData(Biometrico_ItikaContext itikaContext, IEmpleado empleado)
        {
            _itikaContext = itikaContext;
            _empleado = empleado;
        }
        
        public UsuarioInfo AutenticarUsuario(string usuario, string password)
        {
            //UsuarioInfo info = new UsuarioInfo();
            UsuarioInfo info_1 = new UsuarioInfo();
            Empleado List_empleado = new Empleado();
            Rol listRol = new Rol();
            //


            //
            List<Usuario> existeusuario1 = new List<Usuario>();

            var lst = (from d in _itikaContext.Usuarios
                       where d.Estado == true
                       select d).ToList();
            existeusuario1 = lst;
           

            foreach (var t in existeusuario1)
            {
                if ((t.Email == usuario) && (t.Contraseña == password))
                {
                    info_1.Id = t.Id;
                    info_1.Email = t.Email;
                    int codigoempleado = (int)t.Idempleado;
                    //
                    List<Empleado> lisemp = _itikaContext.Empleados.ToList();
                    if (lisemp != null)
                    {
                        foreach (var item in lisemp)
                        {
                            if (item.Id == codigoempleado)
                            {
                                info_1.Nombre = item.Nombre;
                                info_1.Apellidos = item.Apellido;
                            }
                        }

                    }





                    //Empleado newempleado = _itikaContext.Empleados.Find(codigoempleado);
                    //List<Empleado> lstEmp = (from d in _itikaContext.Empleados
                    //           where d.Id == codigoempleado
                    //           select d).ToList();

                    //foreach (var item in lstEmp)
                    //{
                    //    List_empleado = item;
                    //}

                    //
                    //info_1.Nombre = t.Nombre;
                    //info_1.Apellidos = List_empleado.Apellido;
                    int codigorol = (int)t.Idrol;
                    //
                    List<Rol> lstrol = (from d in _itikaContext.Rols
                               where d.Id == codigorol
                               select d).ToList();

                    foreach (var item in lstrol)
                    {
                        listRol = item;
                    }
                   
                    //
                    info_1.Rol = listRol.Nombre;
                    info_1.imagen_perfil = List_empleado.ImagenPerfil;
                }
            }
            return info_1;
        }
    }
}
