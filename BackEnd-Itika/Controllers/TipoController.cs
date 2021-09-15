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
    public class TipoController : ControllerBase
    {
        private readonly ITipo _tipo;

        public TipoController(ITipo tipo)
        {
            _tipo = tipo;
        }
        // GET: api/<AreaController>
        [HttpGet]
        [Authorize]
        public IActionResult GetTipos()
        {
            if (_tipo.ListarTipos() != null)
            {
                return Ok(_tipo.ListarTipos());

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize]
        //[Route("api/[controller]")]
        public IActionResult PostTipo(Tipo tipo)
        {
            Tipo area1 = _tipo.Add_Tipo(tipo);
            if (area1 != null)
            {
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
               tipo.Id, area1);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult DeletTipo(int Id)

        {
            Tipo area = _tipo.Get_Tipo(Id);
            if (area != null)
            {
                _tipo.Delete_Tipo(area);

                return Ok();
            }
            return NotFound($"Usuario with Id:{Id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult Edit(int Id, Area area)
        {
            var arearesult = _tipo.Get_Tipo(Id);
            if (arearesult != null)
            {
                area.Id = arearesult.Id;
                _tipo.Update_Tipo(arearesult);
            }
            return Ok(arearesult);
        }
    }
}
