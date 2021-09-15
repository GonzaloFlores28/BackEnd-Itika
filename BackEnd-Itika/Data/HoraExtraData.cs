using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public class HoraExtraData : IHoraExtra
    {
        private readonly Biometrico_ItikaContext _ItikaContext;

        public HoraExtraData(Biometrico_ItikaContext itikaContext)
        {
            _ItikaContext = itikaContext;
        }
        public HoraExtra Add_HoraExtra(HoraExtra hora)
        {
            hora.Estado = true;
            _ItikaContext.HoraExtras.Add(hora);
            _ItikaContext.SaveChanges();
            return hora;
        }

        public HoraExtra Delete_HoraExtra(HoraExtra hora)
        {
            var exiteasignar = _ItikaContext.HoraExtras.Find(hora.Id);
            if (exiteasignar != null)
            {
                hora.Estado = false;
                _ItikaContext.HoraExtras.Update(hora);
                _ItikaContext.SaveChanges();
            }
            return hora;
        }

        public HoraExtra Get_HoraExtra(int Id)
        {
            var _extras = _ItikaContext.HoraExtras.Find(Id);
            return _extras;
        }

        public List<HoraExtra> ListarHoraExtra()
        {
            List<HoraExtra> listado = _ItikaContext.HoraExtras.ToList();
            return listado;
        }

        public HoraExtra Update_HoraExtra(HoraExtra hora)
        {
            var exiteArea = _ItikaContext.HoraExtras.Find(hora.Id);
            if (exiteArea != null)
            {
                _ItikaContext.HoraExtras.Update(hora);
                _ItikaContext.SaveChanges();
            }
            return hora;
        }
    }
}
