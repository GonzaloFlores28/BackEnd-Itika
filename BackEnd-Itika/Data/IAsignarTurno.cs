using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_Itika.Models;

namespace BackEnd_Itika.Data
{
    public interface IAsignarTurno
    {
        List<AsignarTurno> ListarAsignarTurno();
        AsignarTurno Add_AsignarTurno(AsignarTurno asignar);
        AsignarTurno Delete_AsignarTurno(AsignarTurno asignar);
         AsignarTurno Update_AsignarTurno(AsignarTurno asignar);
        AsignarTurno Get_AsignarTurno(int Id);
    }
}
