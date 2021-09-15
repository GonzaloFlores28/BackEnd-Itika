using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_Itika.Models;

namespace BackEnd_Itika.Data
{
    public interface IPermiso
    {
        List<Permiso> ListarPermisos();
        Permiso Add_Permiso(Permiso permiso);
        Permiso Delete_Permiso(Permiso permiso);
        Permiso Update_Permiso(Permiso permiso);
        Permiso Get_Permiso(int Id);
    }
}
