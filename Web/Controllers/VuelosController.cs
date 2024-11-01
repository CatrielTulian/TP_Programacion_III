using Application.Interfaces;
using Contract.Vuelos.Request;
using Contract.Vuelos.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class VuelosController : ControllerBase
    {
        private readonly IVueloService _vuelosService;

        public VuelosController(IVueloService vuelosService)
        {
            _vuelosService = vuelosService;
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult CreateVuelo([FromBody] VueloRequest vuelo)
        {
            _vuelosService.CreateVuelo(vuelo);
            return Ok();
        }
        
        [HttpGet]
       
        public IActionResult GetAllVuelos()
        {
            var response = _vuelosService.GetAllVuelos();
            
            if (response.Count is 0) 
            {
                return NotFound("No se encontraron vuelos");
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<VueloResponse?> GetVueloById([FromRoute] int id)
        {
            var response = _vuelosService.GetVueloById(id);

            if (response is null) 
            {
                return NotFound("No existe ese número de vuelo");
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<bool> UpdateVuelo([FromRoute] int id, [FromBody] VueloRequest vuelo)
        {
            return Ok(_vuelosService.UpdateVuelo(id, vuelo));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<bool> DeleteVuelo([FromRoute] int id)
        {
            return Ok(_vuelosService.DeleteVuelo(id));
        }
    }
}
