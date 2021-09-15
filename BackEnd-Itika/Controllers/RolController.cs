using BackEnd_Itika.Data;
using BackEnd_Itika.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRol _rol;

        public RolController(IRol rol)
        {
            _rol = rol;
        }
        // GET: api/<RolController>
        [HttpGet]
        [Authorize]
        public IActionResult GetRoles()
        {
            return Ok(_rol.ListarRoless());
        }

        [HttpGet]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult Get_Roles(int id)
        {
            var roles = _rol.Rol_Id(id);
            if (roles != null)
            {
                return Ok(roles);
            }
            return NotFound($"Usuario with Id:{id} was not found");
        }

        [HttpPost]
        [Authorize]
        //[Route("api/[controller]")]
        public IActionResult PostRol(Rol rol)
        {
            Rol area1 = _rol.Add_Rol(rol);
            if (area1 != null)
            {
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
               rol.Id, area1);
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
        public IActionResult DeletRol(int Id)
        {
            var usuario = _rol.Rol_Id(Id);
            if (usuario != null)
            {
                _rol.Delete_ROL(usuario);
                return Ok();
            }
            return NotFound($"Usuario with Id:{Id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult EditRol(int Id, Rol rol)
        {
            var _usuario = _rol.Rol_Id(Id);
            if (_usuario != null)
            {
                _usuario.Id = rol.Id;
                _rol.Update_ROL(_usuario);
            }
            return Ok(_usuario);
        }
    }
}
