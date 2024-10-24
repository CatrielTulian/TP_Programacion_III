using Contract.Vuelos.Response;
using Contract.Pasajeros.Response;

namespace Contract.Reservas.Response
{
    public class ReservaResponse
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public bool EstadoReserva { get; set; }
        public VueloResponse? Vuelo { get; set; }
        public PasajeroResponse? Pasajero { get; set; }
    }
}
