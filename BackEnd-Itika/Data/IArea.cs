using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public interface IArea
    {
        List<Area> ListarAreas();
        Area Add_AREA(Area area);
        Area Delete_AREA(Area area);
        Area Update_AREA(Area area);
        Area Get_Area(int Id);
    }
}
