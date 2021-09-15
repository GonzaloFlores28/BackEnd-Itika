using BackEnd_Itika.Data;
using BackEnd_Itika.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_Itika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleado _empleado;

        public EmpleadoController(IEmpleado empleado)
        {
            _empleado = empleado;
        }
        // GET: api/<EmpleadoController>
        [HttpGet]
        [Authorize]
        public IActionResult GetEmpleados()
        {
            return Ok(_empleado.ListarEmpleados());
        }

        [HttpGet]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult Get_Empleado(int id)
        {
            var empleados = _empleado.Empleado_ID(id);
            if (empleados != null)
            {
                return Ok(empleados);
            }
            return NotFound($"Usuario with Id:{id} was not found");
        }

        [HttpPost]
        [Authorize]
        //[Route("api/[controller]")]
        public IActionResult Post_Empleado(Empleado empleado)
        {
            Empleado emp = _empleado.Add_Empleado(empleado);
            if (emp != null)
            {
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
               empleado.Id, emp);
            }
            else
            {
                return NotFound();
            }           
        }

        //
        [HttpDelete]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult DeletEmpleado(int Id)
        {
            var empleado = _empleado.Empleado_ID(Id);
            if (empleado != null)
            {
                _empleado.Delete_EMPLEADO(empleado);

                return Ok();
            }
            return NotFound($"Usuario with Id:{Id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult EditEmpleado(int Id, Empleado empleado)
        {
            var result = _empleado.Empleado_ID(Id);
            if (result != null)
            {
                result.Id = empleado.Id;
                _empleado.Update_EMPLEADO(result);
            }
            return Ok(result);
        }
    }
}
