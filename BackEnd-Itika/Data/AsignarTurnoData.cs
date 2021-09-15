using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public class AsignarTurnoData : IAsignarTurno
    {
        private readonly Biometrico_ItikaContext _ItikaContext;

        public AsignarTurnoData(Biometrico_ItikaContext itikaContext)
        {
            _ItikaContext = itikaContext;
        }
        public AsignarTurno Add_AsignarTurno(AsignarTurno asignar)
        {
            asignar.Estado = true;
            _ItikaContext.AsignarTurnos.Add(asignar);
            _ItikaContext.SaveChanges();
            return asignar;
        }

        public AsignarTurno Delete_AsignarTurno(AsignarTurno asignar)
        {
            var exiteasignar = _ItikaContext.AsignarTurnos.Find(asignar.Id);
            if (exiteasignar != null)
            {
                asignar.Estado = false;
                _ItikaContext.AsignarTurnos.Update(asignar);
                _ItikaContext.SaveChanges();
            }
            return asignar;
        }

        public AsignarTurno Get_AsignarTurno(int Id)
        {
            var _asignar = _ItikaContext.AsignarTurnos.Find(Id);
            return _asignar;
        }

        public List<AsignarTurno> ListarAsignarTurno()
        {
            List<AsignarTurno> listado = _ItikaContext.AsignarTurnos.ToList();
            return listado;
        }

        public AsignarTurno Update_AsignarTurno(AsignarTurno asignar)
        {
            var exite = _ItikaContext.AsignarTurnos.Find(asignar.Id);
            if (exite != null)
            {
                _ItikaContext.AsignarTurnos.Update(asignar);
                _ItikaContext.SaveChanges();
            }
            return asignar;
        }
    }
}
