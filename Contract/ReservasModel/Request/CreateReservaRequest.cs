using System.Data;
using System.Numerics;

namespace Contract.Reservas.Request
{
    public class ReservaRequest
    {
        public DateTime FechaReserva { get; set; }
        public bool EstadoReserva { get; set; } = false;
        public int VueloId { get; set; }
        public int PasajeroId { get; set; }
    }
}
