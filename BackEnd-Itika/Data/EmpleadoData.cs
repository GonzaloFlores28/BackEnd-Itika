using BackEnd_Itika.Models;
using BackEnd_Itika.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public class EmpleadoData : IEmpleado
    {
        private readonly Biometrico_ItikaContext _itikaContext;

        public EmpleadoData(Biometrico_ItikaContext itikaContext)
        {
            _itikaContext = itikaContext;
        }

        public EmpleadoData() { }
        public Empleado Empleado_ID(int ID)
        {
            var _Empleado = _itikaContext.Empleados.Find(ID);
            return _Empleado;
        }

        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> listado = _itikaContext.Empleados.ToList();
            return listado;
        }

        private int IDArea()
        {
            Area area = _itikaContext.Areas.Where(x => x.Nombre == "Administracion").First();
            return area.Id;
        }
        public Empleado Listar_Id(int id)
        {
            var _Empleado = _itikaContext.Empleados.Find(id);
            return _Empleado;
        }

        public Empleado Add_Empleado(Empleado empleado)
        {
            empleado.Estado = true;
            var listado = ListarEmpleados();
            if (listado != null)
            {
                foreach (var item in listado)
                {
                    if ((item.Nombre != empleado.Nombre)&&(item.Apellido!= empleado.Apellido) && (item.CarnetIdentidad != empleado.CarnetIdentidad))
                    {
                        _itikaContext.Empleados.Add(empleado);
                        _itikaContext.SaveChanges();
                    }
                    else
                    {
                        empleado = null;
                    }
                }
            }
            return empleado;
        }

        //

        public Empleado Delete_EMPLEADO(Empleado empleado)
        {
            var exite = _itikaContext.Empleados.Find(empleado.Id);
            if (exite != null)
            {
                empleado.Estado = false;
                _itikaContext.Empleados.Update(empleado);
                _itikaContext.SaveChanges();
            }
            return empleado;
        }

        public Empleado Update_EMPLEADO(Empleado empleado)
        {
            var exite = _itikaContext.Empleados.Find(empleado.Id);
            if (exite != null)
            {
                _itikaContext.Empleados.Update(empleado);
                _itikaContext.SaveChanges();
            }
            return empleado;
        }

        public Empleado EmpleadoBuscar(string nombre, string apellido)
        {
            Empleado empleado = new Empleado();
            List<Empleado> list = _itikaContext.Empleados.ToList();
            foreach (var e in list)
            {
                if ((e.Nombre == nombre)&&(e.Apellido== apellido))
                {
                    empleado = e;
                }
            }
            return empleado;
        }
    }
}
