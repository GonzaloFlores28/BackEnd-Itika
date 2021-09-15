using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data.Planilla
{
    public interface IAdministracion
    {
        List<PlanillaRecarga> ListaPlanillaXdia();
        List<PlanillaRecarga> ListaPlanillaXdiaX(DateTime? diaX);
        List<PlanillaRecarga> ListaPlanillaXRangoFecha(DateTime? fechaAnterior, DateTime? fechaNueva);

        bool AgregarPlanilaAdministracion();


    }
}
