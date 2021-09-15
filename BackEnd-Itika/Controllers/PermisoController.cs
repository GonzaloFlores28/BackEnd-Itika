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
    public class PermisoController : ControllerBase
    {
        private readonly IPermiso _permiso;

        public PermisoController(IPermiso permiso)
        {
            _permiso = permiso;
        }
        // GET: api/<AreaController>
        [HttpGet]
        [Authorize]
        public IActionResult GetPermisos()
        {
            if (_permiso.ListarPermisos() != null)
            {
                return Ok(_permiso.ListarPermisos());

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        //[Route("api/[controller]")]
        [Authorize]
        public IActionResult PostPermiso(Permiso permiso)
        {
            Permiso area1 = _permiso.Add_Permiso(permiso);
            if (area1 != null)
            {
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
               permiso.Id, area1);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult DeletPermiso(int Id)
        {
            var area = _permiso.Get_Permiso(Id);
            if (area != null)
            {
                _permiso.Delete_Permiso(area);

                return Ok();
            }
            return NotFound($"Usuario with Id:{Id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult EditPermiso(int Id, Permiso permiso)
        {
            var arearesult = _permiso.Get_Permiso(Id);
            if (arearesult != null)
            {
                permiso.Id = arearesult.Id;
                _permiso.Update_Permiso(arearesult);
            }
            return Ok(arearesult);
        }
    }
}
