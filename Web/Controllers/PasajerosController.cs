using Application.Interfaces;
using Contract.Pasajeros.Request;
using Contract.Pasajeros.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers

{
    [ApiController]
    [Route("Api/[controller]")]
    public class PasajerosController : Controller
    {
       private readonly IPasajerosService _pasajerosService;

       public PasajerosController(IPasajerosService pasajerosService)
       {
           _pasajerosService = pasajerosService;
       }

        [HttpPost]
        [Authorize]
        public IActionResult CreatePasajero([FromBody] PasajeroRequest pasajero)
        {
            _pasajerosService.CreatePasajero(pasajero);
            return Ok();
        }

        [HttpGet]
        
        public IActionResult GetAllPasajeros()
        {
            var response = _pasajerosService.GetAllPasajeros();
            
            if (response.Count is 0) 
            {
                return NotFound("No se encontraron pasajeros");
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<PasajeroResponse?> GetPasajeroById([FromRoute] int id)
        { 
            var response = _pasajerosService.GetPasajeroById(id);

            if (response is null) 
            {
                return NotFound("Ese pasajero no existe");
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<bool> UpdatePasajero([FromRoute] int id, [FromBody] PasajeroRequest pasajero)
        {
            return Ok(_pasajerosService.UpdatePasajero(id, pasajero));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<bool> DeletePasajero([FromRoute] int id)
        {
            return Ok(_pasajerosService.DeletePasajero(id));
        }

    }
}
