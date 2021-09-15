using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public class PermisoData : IPermiso
    {
        private readonly Biometrico_ItikaContext _ItikaContext;

        public PermisoData(Biometrico_ItikaContext itikaContext)
        {
            _ItikaContext = itikaContext;
        }

        public Permiso Add_Permiso(Permiso permiso)
        {
            permiso.Estado = true;
            _ItikaContext.Permisos.Add(permiso);
            _ItikaContext.SaveChanges();
            return permiso;
        }

        public Permiso Delete_Permiso(Permiso permiso)
        {
            var exiteasignar = _ItikaContext.Permisos.Find(permiso.Id);
            if (exiteasignar != null)
            {
                permiso.Estado = false;
                _ItikaContext.Permisos.Update(permiso);
                _ItikaContext.SaveChanges();
            }
            return permiso;
        }

        public Permiso Get_Permiso(int Id)
        {
            var permiso = _ItikaContext.Permisos.Find(Id);
            return permiso;
        }

        public List<Permiso> ListarPermisos()
        {
            List<Permiso> listado = _ItikaContext.Permisos.ToList();
            return listado;
        }

        public Permiso Update_Permiso(Permiso permiso)
        {
            var exiteArea = _ItikaContext.Permisos.Find(permiso.Id);
            if (exiteArea != null)
            {
                _ItikaContext.Permisos.Update(permiso);
                _ItikaContext.SaveChanges();
            }
            return permiso;
        }
    }
}
