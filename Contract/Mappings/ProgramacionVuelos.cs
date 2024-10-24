using Contract.Vuelos.Request;
using Contract.Vuelos.Response;
using DomainEntity = Domain.Entities;


namespace Contract.Mappings
{
    public static class ProgramacionVuelos
    {
        public static Domain.Entities.Vuelos ToVuelosEntity(VueloRequest request)
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
                Id = vuelo.Id,
                Origen = vuelo.Origen,
                Destino = vuelo.Destino,
                Capacidad = vuelo.Capacidad,
                FechaSalida = vuelo.FechaSalida,
                FechaLlegada= vuelo.FechaLlegada,
            };
        }

        public static void ToVueloEntityUpdate(DomainEntity.Vuelos vuelo, VueloRequest request)
        {

            vuelo.Capacidad = request.Capacidad;
            vuelo.Origen = request.Origen;
            vuelo.Destino = request.Destino;
            vuelo.FechaSalida = request.FechaSalida;
            vuelo.FechaLlegada = request.FechaLlegada;

        }
    }
}
