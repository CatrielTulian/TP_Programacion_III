using Application.Interfaces;
using Contract.Reservas.Request;
using Contract.Reservas.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ReservasController : Controller
    {
        private readonly IReservaService _reservasService;

        public ReservasController(IReservaService reservaService) 
        {
            _reservasService = reservaService;
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateReserva([FromBody] ReservaRequest reserva)
        {
            _reservasService.CreateReserva(reserva);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllReserva()
        {
            return Ok(_reservasService.GetAllReservas());
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<ReservaResponse> GetReservaById([FromRoute] int id)
        {
            var response = _reservasService.GetReservaById(id);

            if (response == null)
            {
                return NotFound("No existe ese número de reserva");
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<bool> UpdateReserva([FromRoute] int id, [FromBody] ReservaRequest reserva) 
        {
            return Ok(_reservasService.UpdateReserva(id, reserva));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<bool> DeleteReserva([FromRoute] int id) 
        { 
            return Ok(_reservasService.DeleteReserva(id));        
        }
    }
}
