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
    public class AreaController : ControllerBase
    {
        private readonly IArea _area;

        public AreaController(IArea area)
        {
            _area = area;
        }
        // GET: api/<AreaController>
        [HttpGet]
        [Authorize]
        public IActionResult GetAreas()
        {
            if (_area.ListarAreas() != null)
            {
                return Ok(_area.ListarAreas());

            }
            else
            {
                return NotFound();
            }
         }

        [HttpPost]
        [Authorize]
        //[Route("api/[controller]")]
        public IActionResult PostArea(Area area)
        {
            Area area1 = _area.Add_AREA(area);
            if (area1 != null)
            {
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
               area.Id, area1);
            }
            else
            {
                return NotFound();
            }           
        }

        [HttpDelete]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult DeletArea(int Id)
        {
            var area = _area.Get_Area(Id);
            if (area != null)
            {
                _area.Delete_AREA(area);
                
                return Ok();
            }
            return NotFound($"Usuario with Id:{Id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/(id)")]
        [Authorize]
        public IActionResult EditArea(int Id, Area area)
        {
            var arearesult = _area.Get_Area(Id);
            if (arearesult != null)
            {
                area.Id = arearesult.Id;
                _area.Update_AREA(arearesult);
            }
            return Ok(arearesult);
        }

    }
}
