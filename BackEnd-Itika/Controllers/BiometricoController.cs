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
    public class BiometricoController : ControllerBase
    {

        private readonly IBiometrico _biometrico;

        public BiometricoController(IBiometrico biometrico)
        {
            _biometrico = biometrico;
        }
        // GET: api/<AreaController>
        [HttpGet]
        [Authorize]
        public IActionResult GetBiometricos()
        {
            if (_biometrico.GetBiometrico() != null)
            {
                return Ok(_biometrico.GetBiometrico());

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize]
        //[Route("api/[controller]")]
        public IActionResult PostBiometrico(Biometrico biometrico)
        {
            //Biometrico area1 = _biometrico.Add_Biometrico(biometrico);

            //if (area1 != null)
            //{
            //    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
            //   biometrico.Id, area1);
            //}
            //else
            //{
            //    return NotFound();
            //}

            bool estado = _biometrico.Add_RegistroBiometrico();
            if (estado == true)
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
