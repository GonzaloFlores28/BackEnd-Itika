using BackEnd_Itika.Data;
using BackEnd_Itika.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurno _turno;

        public TurnoController(ITurno turno)
        {
            _turno = turno;
        }
        // GET: api/<EmpleadoController>
        [HttpGet]
        [Authorize]
        public IActionResult GetTurnos()
        {
            return Ok(_turno.ListarTurnos());
        }

        [HttpGet]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult Get_Turno(int id)
        {
            var empleados = _turno.Get_Turno(id);
            if (empleados != null)
            {
                return Ok(empleados);
            }
            return NotFound($"Usuario with Id:{id} was not found");
        }

        [HttpPost]
        [Authorize]
        //[Route("api/[controller]")]
        public IActionResult Post_Turno (Turno turno)
        {
            var emp = _turno.Add_Turno(turno);
            if (emp != null)
            {
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
               turno.Id, emp);
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
        public IActionResult DeletTurno(int Id)
        {
            var empleado = _turno.Get_Turno(Id);
            if (empleado != null)
            {
                _turno.Delete_Turno(empleado);

                return Ok();
            }
            return NotFound($"Usuario with Id:{Id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult EditTurno(int Id, Turno turno)
        {
            var result = _turno.Get_Turno(Id);
            if (result != null)
            {
                result.Id = turno.Id;
                _turno.Update_Turno(result);
            }
            return Ok(result);
        }
    }
}
