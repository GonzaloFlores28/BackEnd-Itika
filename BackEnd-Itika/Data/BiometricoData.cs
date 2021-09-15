using BackEnd_Itika.Models;
using BackEnd_Itika.Models.ZK_Biometrico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackEnd_Itika.Data
{
    public class BiometricoData : IBiometrico
    {
        private readonly Biometrico_ItikaContext _ItikaContext;
        private readonly ZKTimeContext _zKTimeContext;
        private readonly IEmpleado empleadoI;

        public BiometricoData(Biometrico_ItikaContext itikaContext)
        {
            _ItikaContext = itikaContext;
            //_zKTimeContext = zKTimeContext;
        }

        public Biometrico Add_Biometrico(Biometrico biometrico)
        {
            biometrico.Estado = true;
            _ItikaContext.Biometricos.Add(biometrico);
            _ItikaContext.SaveChanges();
            return biometrico;
        }

        public Biometrico Get_Biometrico(int Id)
        {
            var _Biometricos = _ItikaContext.Biometricos.Find(Id);
            return _Biometricos;
        }

        public List<Biometrico> Listar()
        {
            Area area = _ItikaContext.Areas.Where(x => x.Nombre == "Administracion").First();
            List<Empleado> ListaEmpleado = _ItikaContext.Empleados.Where(x => x.Idarea == area.Id).ToList();

            List<Biometrico> ListaEmpBiometrico = new List<Biometrico>();
            foreach (var i in ListaEmpleado)
            {
                ListaEmpBiometrico = _ItikaContext.Biometricos.Where(x => x.Idempleado == i.Id && x.Fecha == DateTime.Now).ToList();
            }
            return ListaEmpBiometrico;
        }
        public List<Biometrico> ListarBiometrico()
        {
            List<Biometrico> listado = _ItikaContext.Biometricos.ToList();
            return listado;
        }

        public List<Biometrico> BiometricoActual(DateTime fechaActual)
        {
            List<Biometrico> biometricos =  (from d in _ItikaContext.Biometricos
                                                         where d.Fecha == fechaActual
                                                         select d).ToList();
            return biometricos;
        }



        //Listar Todos los registros del sql_Registro del SDKTimeTEcka
        private EmpleadoZk IdentificacionEmpleado(int? id)
        {
            EmpleadoZk empleado = _zKTimeContext.EmpleadoZks.Find(id);
            return empleado;
        }
        private List<Marcacion> GetMarcaciones()
        {
            DateTime FechaACtual = DateTime.Now;
            var _marcaciones = from a in _zKTimeContext.Marcacions
                               where a.Fecha == FechaACtual
                               select a;
            return (List<Marcacion>)_marcaciones;
        }
        //fin
        public bool Add_RegistroBiometrico()
        {
            List<Marcacion> marcacion = new List<Marcacion>();
            List<EmpleadoZk> empleadoZks = new List<EmpleadoZk>();
            bool estado = false;

            // sacar todos los datos de base de datos del zktime
            using (var db = _zKTimeContext)
            {
               
                empleadoZks = db.EmpleadoZks.ToList();
            }
            //
            Area area = new Area();
            List<Empleado> EmpAdm = new List<Empleado>();
            using (var db = _ItikaContext)
            {               
                EmpAdm = _ItikaContext.Empleados.ToList();
            }

            //
            // comprar datos de empleado de zktime a base de datos modelada
            List<Biometrico> BiometricoActual = new List<Biometrico>();
            Biometrico bioTotal = new Biometrico();
            foreach (var ea in EmpAdm)
            {
                // lista de empleado de zktime
                foreach (var ezk in empleadoZks)
                {
                    if ((ea.Nombre == ezk.Nombre) && (ezk.Apellido == ezk.Apellido))
                    {
                        // obtenemos el codigo del empleado
                        // obtenemos la lista de marcaciones del dia de ese empleado
                        using (var db = _zKTimeContext)
                        {
                            DateTime diaanterior = DateTime.Today.AddDays(-1);
                            //&& x.Fecha == diaanterior
                            marcacion = db.Marcacions.Where(x => x.Fecha == DateTime.Now 
                            && x.IdEmpleado == ezk.Id).ToList();
                        }

                        // guardar las marcaciones del empleado en el registro de Administracion
                        BiometricoActual = _ItikaContext.Biometricos.Where(x => x.Fecha == DateTime.Now
                        && x.Fecha == DateTime.Today.AddDays(-1) && x.Idempleado == ea.Id).ToList();

                        foreach (var lb in BiometricoActual)
                        {
                            foreach (var lm in marcacion)
                            {
                                if ((lb.Fecha != lm.Fecha))
                                {
                                    bioTotal.Idempleado = ea.Id;
                                    bioTotal.Fecha = (DateTime)lm.Fecha;
                                    bioTotal.Hora = Convert.ToDateTime(lm.Marca);
                                    bioTotal.Estado = true;
                                    _ItikaContext.Biometricos.Add(bioTotal);
                                    _ItikaContext.SaveChanges();
                                    estado = true;
                                }
                            }
                        }
                    }
                }
            }
            return estado;
        }

        public List<Biometrico> GetBiometrico()
        {
            List<Biometrico> listado = _ItikaContext.Biometricos.ToList();
            return listado;
        }
    }
}
