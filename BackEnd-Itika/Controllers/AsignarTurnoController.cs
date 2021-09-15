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
    public class AsignarTurnoController : ControllerBase
    {
        private readonly IAsignarTurno _asignar;

        public AsignarTurnoController(IAsignarTurno asignar)
        {
            _asignar = asignar;
        }
        // GET: api/<AreaController>
        [HttpGet]
        [Authorize]
        public IActionResult GetAsignarTurnos()
        {
            if (_asignar.ListarAsignarTurno()!= null)
            {
                return Ok(_asignar.ListarAsignarTurno());

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize]
        //[Route("api/[controller]")]
        public IActionResult PostAsignarTurno(AsignarTurno asignar)
        {
           AsignarTurno asignar1 = _asignar.Add_AsignarTurno(asignar);
            if (asignar1 != null)
            {
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
               asignar.Id, asignar1);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult DeletAsignarTurno(int Id)
        {
            var area = _asignar.Get_AsignarTurno(Id);
            if (area != null)
            {
                _asignar.Delete_AsignarTurno(area);

                return Ok();
            }
            return NotFound($"Usuario with Id:{Id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult EditAsginarTurno(int Id, AsignarTurno asignar)
        {
            var arearesult = _asignar.Get_AsignarTurno(Id);
            if (arearesult != null)
            {
                asignar.Id = arearesult.Id;
                _asignar.Update_AsignarTurno(arearesult);
            }
            return Ok(arearesult);
        }
    }
}
