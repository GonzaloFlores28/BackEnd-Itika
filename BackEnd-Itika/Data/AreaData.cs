using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public class AreaData : IArea
    {
        private readonly Biometrico_ItikaContext _ItikaContext;

        public AreaData(Biometrico_ItikaContext itikaContext)
        {
            _ItikaContext = itikaContext;
        }

        public List<Area> ListarAreas()
        {
            List<Area> listado = _ItikaContext.Areas.ToList();
            return listado;
        }
        public Area Get_Area(int Id)
        {
            var _Areas = _ItikaContext.Areas.Find(Id);
            return _Areas;
        }
        public Area Add_AREA(Area area)
        {
            area.Estado = true;
            //
            var Areas = ListarAreas();
            foreach (var item in Areas)
            {
                if (item.Nombre != area.Nombre)
                {
                    _ItikaContext.Areas.Add(area);
                    _ItikaContext.SaveChanges();
                }
                else
                {
                    area = null;
                }
            }
            //          
            return area;
        }

        public Area Delete_AREA(Area area)
        {
            var exiteasignar = _ItikaContext.Areas.Find(area.Id);
            if (exiteasignar != null)
            {
                area.Estado = false;
                _ItikaContext.Areas.Update(area);
                _ItikaContext.SaveChanges();
            }
            return area;
        }

        public Area Update_AREA(Area area)
        {
            var exiteArea = _ItikaContext.Areas.Find(area.Id);
            if (exiteArea != null)
            {
                _ItikaContext.Areas.Update(area);
                _ItikaContext.SaveChanges();
            }
            return area;
        }
    }
}
