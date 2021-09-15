using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public interface IRol
    {
        List<Rol> ListarRoless();
        Rol Add_Rol(Rol rol);
        Rol Update_ROL(Rol rol);
        Rol Delete_ROL(Rol rol);
        Rol Rol_Id(int ID);
    }
}
