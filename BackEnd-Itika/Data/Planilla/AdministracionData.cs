using BackEnd_Itika.Models;
using BackEnd_Itika.Models.ZK_Biometrico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_Itika.Models.Entidades;

namespace BackEnd_Itika.Data.Planilla
{
    public class AdministracionData : IAdministracion
    {
        private readonly Biometrico_ItikaContext _ItikaContext;
        private readonly ZKTimeContext _zkTimeContext;


        public AdministracionData(Biometrico_ItikaContext itikaContext)
        {
            _ItikaContext = itikaContext;
          
        }
      
        public List<PlanillaRecarga> ListaPlanillaXdia()
        {
            List<PlanillaRecarga> pRecarga = _ItikaContext.PlanillaRecargas.Where(x => x.FechaEntrada == DateTime.Now).ToList();
            return pRecarga;
        }

        public List<PlanillaRecarga> ListaPlanillaXdiaX(DateTime? diaX)
        {
            List<PlanillaRecarga> pRecarga = _ItikaContext.PlanillaRecargas.Where(x => x.FechaEntrada == diaX).ToList();
            return pRecarga;
        }

        public List<PlanillaRecarga> ListaPlanillaXRangoFecha(DateTime? fechaAnterior, DateTime? fechaNueva)
        {
            List<PlanillaRecarga> pRecarga = _ItikaContext.PlanillaRecargas.Where(x => x.FechaEntrada == fechaAnterior && x.FechaEntrada == fechaNueva).ToList();
            return pRecarga;
        }
        // esta funcion solo se debe ejecutar al terminar o tener las 4 marcaciones diarias del personal
        private bool AgregarPlanillaADministrativa()
        {
            
            // buscar empleado del area de administracion
            Area area = _ItikaContext.Areas.Where(x => x.Nombre == "Administracion").First();
            List<Empleado> ListaEmpleado = _ItikaContext.Empleados.Where(x => x.Idarea == area.Id).ToList();
            // listar las marcaciones biometricos de los empleados de administracion
            List<Biometrico> BioAdm = new List<Biometrico>();
            List<Biometrico> BioAdmAux = new List<Biometrico>();
            Biometrico biometrico = new Biometrico();
            PlanillaRecarga planillaAdministracion = new PlanillaRecarga();
            PlanillaADM pAdm = new PlanillaADM();

            if (ListaEmpleado != null)
            {
                foreach (var empADM in ListaEmpleado)
                {
                    BioAdmAux = _ItikaContext.Biometricos.Where(x => x.Idempleado == empADM.Id && x.Fecha == DateTime.Now).ToList();
                    foreach (var bio in BioAdmAux)
                    {
                        if (bio != null)
                        {
                            pAdm.Idempleado = bio.Idempleado;
                            pAdm.FechaEntrada = bio.Fecha;
                            int horaEntrada = bio.Hora.Hour;
                            // aqui sabemos si la marcacion esta en la hora de entrada o salida
                            if (horaEntrada == 8)
                            {
                                pAdm.EntradaMañana = bio.Hora;
                                pAdm.RetrasoMañana = this.Retrasos(bio.Hora);
                            }
                            if (horaEntrada == 12)
                            {
                                pAdm.SalidaMañana = bio.Hora;
                            }

                            if (horaEntrada == 15)
                            {
                                pAdm.EntradaTarde = bio.Hora;
                                pAdm.RetrasoTarde = this.Retrasos(bio.Hora);
                            }
                            if (horaEntrada == 19)
                            {
                                pAdm.SalidaTarde = bio.Hora;
                            }
                            pAdm.Estado = true;
                            pAdm.EstadoFalta = false;
                        }
                        else
                        {
                            pAdm.EstadoFalta = true;
                        }
                      //
                        // aqui verificamos en la base de datos existe, solo modificaremos el registro 
                        // sino se agregara                       
                    }

                    planillaAdministracion = _ItikaContext.PlanillaRecargas.Where(x => x.Idempleado == pAdm.Idempleado).First();
                    if (planillaAdministracion != null)
                    {
                        planillaAdministracion.Idempleado = pAdm.Idempleado;
                        planillaAdministracion.HoraEntrada = pAdm.EntradaMañana;
                        planillaAdministracion.HoraEntrada1 = pAdm.EntradaTarde;
                        planillaAdministracion.HoraSalida = pAdm.SalidaMañana;
                        planillaAdministracion.HoraSalida1 = pAdm.SalidaTarde;
                        planillaAdministracion.Retraso = pAdm.RetrasoMañana;
                        planillaAdministracion.Retraso2 = pAdm.RetrasoTarde;
                        planillaAdministracion.Estado = pAdm.Estado;
                        //planillaAdministracion.EstadoFalta = pAdm.EstadoFalta;

                        _ItikaContext.PlanillaRecargas.Add(planillaAdministracion);
                        _ItikaContext.SaveChanges();
                    }
                    else
                    {
                        planillaAdministracion.Id = planillaAdministracion.Id;
                        planillaAdministracion.Idempleado = pAdm.Idempleado;
                        planillaAdministracion.HoraEntrada = pAdm.EntradaMañana;
                        planillaAdministracion.HoraEntrada1 = pAdm.EntradaTarde;
                        planillaAdministracion.HoraSalida = pAdm.SalidaMañana;
                        planillaAdministracion.HoraSalida1 = pAdm.SalidaTarde;
                        planillaAdministracion.Retraso = pAdm.RetrasoMañana;
                        planillaAdministracion.Retraso2 = pAdm.RetrasoTarde;
                        planillaAdministracion.Estado = pAdm.Estado;
                        planillaAdministracion.EstadoFalta = true;
                        planillaAdministracion.Estado = true;
                        _ItikaContext.PlanillaRecargas.Update(planillaAdministracion);
                        _ItikaContext.SaveChanges();
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //
        private DateTime Retrasos(DateTime hora)
        {
            DateTime horaAux = new DateTime();
            int minutos, horaE;
            int EntradaMañana = 8;
            int EntradaTarde = 15;
            int minutosTolerancia = 5;
            if (hora != null)
            {
                minutos = Convert.ToInt32(hora.Minute);
                horaE = Convert.ToInt32(hora.Hour);
                if (horaE == EntradaMañana)
                {
                    if (minutos >= minutosTolerancia)
                    {
                        horaAux = hora;
                    }                   
                }
                else
                {
                    if (horaE == EntradaTarde)
                    {
                        if (minutos >= minutosTolerancia)
                        {
                            horaAux = hora;
                        }                       
                    }
                    else
                    {
                        horaAux = hora;
                    }
                }
            }
            else
            {
               horaAux= hora;
            }
          
            return horaAux;
        }

        private bool Falta(string hora)
        {
            bool falta = new bool();
            if (hora != null)
            {
                falta = false;
            }
            else
            {
                falta = true;

            }
            return falta;
        }

        public void AgregarPlanilaAdministracion()
        {
           List<Marcacion> marcacion = new List<Marcacion>();
            List<EmpleadoZk> empleadoZks = new List<EmpleadoZk>();
           
            // sacar todos los datos de base de datos del zktime
            using (var db = _zkTimeContext)
            {
                //marcacion = db.Marcacions.Where(x => x.Fecha == DateTime.Now).ToList();
                empleadoZks = db.EmpleadoZks.ToList();
            }
            //
            Area area = new Area();
            List<Empleado> EmpAdm = new List<Empleado>();
            using (var db = _ItikaContext)
            {
                area = _ItikaContext.Areas.Where(x => x.Nombre == "Administracion").First();
                EmpAdm = _ItikaContext.Empleados.Where(x => x.Idarea == area.Id).ToList();
            }

            //
            // comprar datos de empleado de zktime a base de datos modelada

            foreach (var ea in EmpAdm)
            {
                // lista de empleado de zktime
                foreach (var ezk in empleadoZks)
                {
                    if ((ea.Nombre == ezk.Nombre) && (ezk.Apellido == ezk.Apellido))
                    {
                        // obtenemos el codigo del empleado
                        // obtenemos la lista de marcaciones del dia de ese empleado
                        using (var db = _zkTimeContext)
                        {
                            marcacion = db.Marcacions.Where(x => x.Fecha == DateTime.Now && x.IdEmpleado == ezk.Id).ToList();
                        }
                        // guardar las marcaciones del empleado en el registro de Administracion




                    }
                }
            }
            //
           
        }

        bool IAdministracion.AgregarPlanilaAdministracion()
        {
            throw new NotImplementedException();
        }



        //private Permiso PermisoXIngresoTardio(int idEmpleado)
        //{ 

        //}
    }
}
