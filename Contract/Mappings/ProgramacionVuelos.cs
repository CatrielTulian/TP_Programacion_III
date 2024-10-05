using Contract.Vuelos.Request;
using Contract.Vuelos.Response;

namespace Contract.Mappings
{
    public static class ProgramacionVuelos
    {
        public static Domain.Entities.Vuelos ToVuelosEntity(CreateVueloRequest request)
        {
            return new Domain.Entities.Vuelos()
            {
                Capacidad = request.Capacidad,
                Origen = request.Origen,
                Destino = request.Destino,
                FechaSalida = request.FechaSalida,
                FechaLlegada = request.FechaLlegada,

            };
        }

        public static VueloResponse ToVueloResponse(Domain.Entities.Vuelos vuelo)
        {
            return new VueloResponse()
            {
                Origen = vuelo.Origen,
                Destino = vuelo.Destino,
                FechaSalida = vuelo.FechaSalida,
            };
        }
    }
}
