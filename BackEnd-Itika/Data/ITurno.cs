using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public interface ITurno
    {
        List<Turno> ListarTurnos();
        Turno Add_Turno(Turno turno);
        Turno Delete_Turno(Turno turno);
        Turno Update_Turno(Turno turno);
        Turno Get_Turno(int Id);
    }
}
