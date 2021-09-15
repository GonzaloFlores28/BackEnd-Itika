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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        [Authorize]
        public IActionResult GetUsuarios()
        {
            return Ok(_usuario.ListarUsuarios());
        }

        [HttpGet]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult Get_Usuario(int id)
        {
            var usuario = _usuario.Get_Usuario(id);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            return NotFound($"Usuario with Id:{id} was not found");
        }

        [HttpPost]
        [Authorize]
        //[Route("api/[controller]")]
        public IActionResult RegisterUsuario(Usuario usuario)
        {
            Usuario area1 = _usuario.Add_Usuario(usuario);
            if (area1 != null)
            {
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
               usuario.Id, area1);
            }
            else
            {
                return NotFound();
            }
         }


        [HttpDelete]
        [Route("api/[controller]/(id)")]
        public IActionResult DeletUsuario(int Id)
        {
            var empleado = _usuario.Get_Usuario(Id);
            if (empleado != null)
            {
                _usuario.Delete_USUARIO(empleado);

                return Ok();
            }
            return NotFound($"Usuario with Id:{Id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/(id)")]
        public IActionResult EditUsuario(int Id, Usuario usuario)
        {
            var result = _usuario.Get_Usuario(Id);
            if (result != null)
            {
                result.Id = usuario.Id;
                _usuario.Update_USUARIO(result);
            }
            return Ok(result);
        }
    }
}
