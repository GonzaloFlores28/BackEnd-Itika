using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public class TurnoData : ITurno
    {
        private readonly Biometrico_ItikaContext _ItikaContext;

        public TurnoData(Biometrico_ItikaContext itikaContext)
        {
            _ItikaContext = itikaContext;
        }
        public Turno Add_Turno(Turno turno)
        {
            turno.Estado = true;
            _ItikaContext.Turnos.Add(turno);
            _ItikaContext.SaveChanges();
            return turno;
        }

        public Turno Delete_Turno(Turno turno)
        {
            var exiteasignar = _ItikaContext.Turnos.Find(turno.Id);
            if (exiteasignar != null)
            {
                turno.Estado = false;
                _ItikaContext.Turnos.Update(turno);
                _ItikaContext.SaveChanges();
            }
            return turno;
        }

        public Turno Get_Turno(int Id)
        {
            var _Areas = _ItikaContext.Turnos.Find(Id);
            return _Areas;
        }

        public List<Turno> ListarTurnos()
        {
            List<Turno> listado = _ItikaContext.Turnos.ToList();
            return listado;
        }

        public Turno Update_Turno(Turno turno)
        {
            var exiteArea = _ItikaContext.Turnos.Find(turno.Id);
            if (exiteArea != null)
            {
                _ItikaContext.Turnos.Update(turno);
                _ItikaContext.SaveChanges();
            }
            return turno;
        }
    }
}
