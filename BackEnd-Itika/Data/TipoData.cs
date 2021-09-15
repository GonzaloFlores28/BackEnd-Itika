using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public class TipoData : ITipo
    {
        private readonly Biometrico_ItikaContext _ItikaContext;

        public TipoData(Biometrico_ItikaContext itikaContext)
        {
            _ItikaContext = itikaContext;
        }
        public Tipo Add_Tipo(Tipo tipo)
        {
            tipo.Estado = true;
            _ItikaContext.Tipos.Add(tipo);
            _ItikaContext.SaveChanges();
            return tipo;
        }

        public Tipo Delete_Tipo(Tipo tipo)
        {
            var exiteasignar = _ItikaContext.Tipos.Find(tipo.Id);
            if (exiteasignar != null)
            {
                tipo.Estado = false;
                _ItikaContext.Tipos.Update(tipo);
                _ItikaContext.SaveChanges();
            }
            return tipo;
        }

        public Tipo Get_Tipo(int Id)
        {
            var _Tipo = _ItikaContext.Tipos.Find(Id);
            return _Tipo;
        }

        public List<Tipo> ListarTipos()
        {
            List<Tipo> listado = _ItikaContext.Tipos.ToList();
            return listado;
        }

        public Tipo Update_Tipo(Tipo tipo)
        {
            var exiteArea = _ItikaContext.Tipos.Find(tipo.Id);
            if (exiteArea != null)
            {
                _ItikaContext.Tipos.Update(tipo);
                _ItikaContext.SaveChanges();
            }
            return tipo;
        }
    }
}
