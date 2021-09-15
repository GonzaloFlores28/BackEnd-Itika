using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public interface ITipo
    {
        List<Tipo> ListarTipos();
        Tipo Add_Tipo(Tipo tipo);
        Tipo Delete_Tipo(Tipo tipo);
        Tipo Update_Tipo(Tipo tipo);
        Tipo Get_Tipo(int Id);
    }
}
