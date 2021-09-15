
using BackEnd_Itika.Data.Planilla;
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
    public class AdministracionController : ControllerBase
    {
        private readonly IAdministracion _administracion;

        public AdministracionController(IAdministracion administracion)
        {
            _administracion = administracion;
        }
        // GET: api/<AreaController>
        [HttpGet]
        [Authorize]
        public IActionResult ListaPlanillasActuales()
        {
            if (_administracion.ListaPlanillaXdia() != null)
            {
                return Ok(_administracion.ListaPlanillaXdia());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult ListaPlanillaXdiaX(DateTime diaX)
        {
            if (_administracion.ListaPlanillaXdiaX(diaX) != null)
            {
                return Ok(_administracion.ListaPlanillaXdiaX(diaX));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult ListaPlanillaXRangoFecha(DateTime fechaAnterior, DateTime fechaNueva)
        {
            if (_administracion.ListaPlanillaXRangoFecha(fechaAnterior,fechaNueva) != null)
            {
                return Ok(_administracion.ListaPlanillaXRangoFecha(fechaAnterior,fechaNueva));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize]
        //[Route("api/[controller]")]
        public IActionResult PostPlanillaAdministracion()
        {
            bool area1 = _administracion.AgregarPlanilaAdministracion();
            if (area1 == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
