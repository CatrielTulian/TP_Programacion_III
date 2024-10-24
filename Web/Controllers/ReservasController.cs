using Application.Interfaces;
using Contract.Reservas.Request;
using Contract.Reservas.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ReservasController : Controller
    {
        private readonly IReservaService _reservasService;

        public ReservasController(IReservaService reservaService) 
        {
            _reservasService = reservaService;
        }
        [HttpPost]
        public IActionResult CreateReserva([FromBody] ReservaRequest reserva)
        {
            _reservasService.CreateReserva(reserva);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllReserva()
        {
            return Ok(_reservasService.GetAllReservas());
        }

        [HttpGet("{id}")]
        public ActionResult<ReservaResponse> GetReservaById([FromRoute] int id)
        {
            var response = _reservasService.GetReservaById(id);

            if (response == null)
            {
                return NotFound("No existe ese número de reserva");
            }

            return Ok(response);
        }
    }
}
