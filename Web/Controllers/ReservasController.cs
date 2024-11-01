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
    [Authorize]
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
            var response = _reservasService.GetAllReservas();

            if (response.Count is 0) 
            {
                return NotFound("No se encontraron reservas");
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        
        public ActionResult<ReservaResponse> GetReservaById([FromRoute] int id)
        {
            var response = _reservasService.GetReservaById(id);

            if (response is null)
            {
                return NotFound("No existe ese número de reserva");
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        
        public ActionResult<bool> UpdateReserva([FromRoute] int id, [FromBody] ReservaRequest reserva) 
        {
            return Ok(_reservasService.UpdateReserva(id, reserva));
        }

        [HttpDelete("{id}")]
        
        public ActionResult<bool> DeleteReserva([FromRoute] int id) 
        { 
            return Ok(_reservasService.DeleteReserva(id));        
        }
    }
}
