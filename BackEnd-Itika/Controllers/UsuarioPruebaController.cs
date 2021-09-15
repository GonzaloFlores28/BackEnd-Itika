using BackEnd_Itika.Models;
using BackEnd_Itika.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BackEnd_Itika.Data.LogearUsario;
using BackEnd_Itika.Tools;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_Itika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPruebaController : ControllerBase
    {
        
        private readonly IConfiguration _configuration;
        private readonly ILogearUsuario _logearUsuario;
        private readonly Jwt _jwt;

        public UsuarioPruebaController(IConfiguration configuration,ILogearUsuario logearUsuario)
        {
            _configuration = configuration;
            _logearUsuario = logearUsuario;
          
        }

        //GET: api/<UsuarioPruebaController>
        //[HttpGet]
        //public ActionResult GetPrueba()
        //{
        //    return Ok();
        //}

        [HttpPost]
        [AllowAnonymous]

        public IActionResult Logear(UsuarioLogin usuarioLogin)
        {

            //https://www.rafaelacosta.net/Blog/2019/5/20/json-web-token-seguridad-en-servicios-web-api-de-net-core

           
            var _userInfo =  _logearUsuario.AutenticarUsuario(usuarioLogin.Usuario, usuarioLogin.Password);
          
            if (_userInfo != null)
            {
                return Ok(new { token = GenerarTokenJWT(_userInfo) });
            }
            else
            {
                return Unauthorized();
            }
        }


        public string GenerarTokenJWT(UsuarioInfo usuarioInfo)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:Key"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim("nombre", usuarioInfo.Nombre),
                //new Claim("apellidos", usuarioInfo.Apellidos),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                new Claim(ClaimTypes.Role, usuarioInfo.Rol)
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
