using Application.Interfaces;
using Contract.Vuelos.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private readonly IVueloService _vuelosService;

        public VuelosController(IVueloService vuelosService)
        {
            _vuelosService = vuelosService;
        }
        [HttpPost]
        public IActionResult CreateVuelo([FromBody] CreateVueloRequest vuelo)
        {
            _vuelosService.CreateVuelo(vuelo);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllVuelos()
        {
            return Ok(_vuelosService.GetAllVuelos());
        }
    }
}
