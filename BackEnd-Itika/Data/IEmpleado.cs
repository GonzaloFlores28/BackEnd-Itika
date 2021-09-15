using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public interface IEmpleado
    {  
        List<Empleado> ListarEmpleados();
        Empleado Empleado_ID(int ID);
        Empleado Listar_Id(int id);
        Empleado Add_Empleado(Empleado empleado);
        Empleado Update_EMPLEADO(Empleado empleado);
        Empleado Delete_EMPLEADO(Empleado empleado);
        Empleado EmpleadoBuscar(string nombre, string apellido);
    }
}
