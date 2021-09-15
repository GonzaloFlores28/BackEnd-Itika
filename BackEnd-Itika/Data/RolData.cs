using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public class RolData : IRol
    {
        private readonly Biometrico_ItikaContext _itikaContext;

        public RolData(Biometrico_ItikaContext ItikaContext)
        {
            _itikaContext = ItikaContext;
        }
        public List<Rol> ListarRoless()
        {
            List<Rol> listado = _itikaContext.Rols.ToList();
            return listado;
        }

        public Rol Add_Rol(Rol rol)
        {
            rol.Estado = true;
            var listado = ListarRoless();
            if (listado != null)
            {
                foreach (var item in listado)
                {
                    if (item.Nombre != rol.Nombre)
                    {
                        _itikaContext.Rols.Add(rol);
                        _itikaContext.SaveChanges();
                    }
                    else
                    {
                        rol = null;
                    }
                }
            }      
            return rol;
        }

        //
        public Rol Rol_Id(int ID)
        {
            var rol = _itikaContext.Rols.Find(ID);
            return rol;
        }

        public Rol Delete_ROL(Rol rol)
        {
            var exite = _itikaContext.Rols.Find(rol.Id);
            if (exite != null)
            {
                rol.Estado = false;
                _itikaContext.Rols.Update(rol);
                _itikaContext.SaveChanges();
            }
            return rol;
        }

        public Rol Update_ROL(Rol rol)
        {
            var exite = _itikaContext.Rols.Find(rol.Id);
            if (exite != null)
            {
                _itikaContext.Rols.Update(rol);
                _itikaContext.SaveChanges();
            }
            return rol;
        }
    }
}
