using Application.Interfaces;
using Contract.Pasajeros.Request;
using Contract.Pasajeros.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("Api/[controller]")]
    public class PasajerosController : Controller
    {
       private readonly IPasajerosService _pasajerosService;

       public PasajerosController(IPasajerosService pasajerosService)
       {
           _pasajerosService = pasajerosService;
       }

       [HttpPost]
       public IActionResult CreatePasajero([FromBody] PasajeroRequest pasajero)
        {
            _pasajerosService.CreatePasajero(pasajero);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllPasajeros()
        {
            return Ok(_pasajerosService.GetAllPasajeros());
        }

        [HttpGet("{id}")]
        public ActionResult<PasajeroResponse?> GetPasajeroById([FromRoute] int id)
        { 
            var response = _pasajerosService.GetPasajeroById(id);

            if (response == null) 
            {
                return NotFound("Ese pasajero no existe");
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult<bool> UpdatePasajero([FromRoute] int id, [FromBody] PasajeroRequest pasajero)
        {
            return Ok(_pasajerosService.UpdatePasajero(id, pasajero));
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeletePasajero([FromRoute] int id)
        {
            return Ok(_pasajerosService.DeletePasajero(id));
        }

    }
}
