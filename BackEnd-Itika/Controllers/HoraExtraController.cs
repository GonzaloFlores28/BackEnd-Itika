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
    public class HoraExtraController : ControllerBase
    {
        private readonly IHoraExtra _hora;

        public HoraExtraController(IHoraExtra hora)
        {
            _hora = hora;
        }
        // GET: api/<AreaController>
        [HttpGet]
        [Authorize]
        public IActionResult GetHoras()
        {
            if (_hora.ListarHoraExtra() != null)
            {
                return Ok(_hora.ListarHoraExtra());

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize]
        //[Route("api/[controller]")]
        public IActionResult PostHoraExtra(HoraExtra hora)
        {
            HoraExtra area1 = _hora.Add_HoraExtra(hora);
            if (area1 != null)
            {
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
               hora.Id, area1);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult DeletHora(int Id)
        {
            var area = _hora.Get_HoraExtra(Id);
            if (area != null)
            {
                _hora.Delete_HoraExtra(area);

                return Ok();
            }
            return NotFound($"Usuario with Id:{Id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult EditHoraExtra(int Id, HoraExtra hora)
        {
            var arearesult = _hora.Get_HoraExtra(Id);
            if (arearesult != null)
            {
                hora.Id = arearesult.Id;
                _hora.Update_HoraExtra(arearesult);
            }
            return Ok(arearesult);
        }
    }
}
