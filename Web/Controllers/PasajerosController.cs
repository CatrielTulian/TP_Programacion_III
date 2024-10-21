using Application.Interfaces;
using Contract.Pasajeros.Request;
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
       public IActionResult CreatePasajero([FromBody] CreatePasajeroRequest pasajero)
        {
            _pasajerosService.CreatePasajero(pasajero);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllPasajeros()
        {
            return Ok(_pasajerosService.GetAllPasajeros());
        }
    }
}
