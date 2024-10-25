using Contract.Reservas.Request;
using Contract.Reservas.Response;
using Contract.Vuelos.Request;
using Contract.Pasajeros.Response;
using DomainEntity = Domain.Entities;
using Domain.Interfaces;

namespace Contract.Mappings
{
    public static class ProgramacionReserva
    {
        
        public static Domain.Entities.Reservas ToReservasEntity(
            ReservaRequest request,
            IVueloRepository vueloRepository,
            IPasajeroRepository pasajeroRepository)

        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "La solicitud de creación de reserva no puede ser nula.");

            var vuelo = vueloRepository.GetVueloById(request.VueloId);
            if (vuelo == null)
                throw new ArgumentException($"No existe ningún vuelo con el Id {request.VueloId}");

            var pasajero = pasajeroRepository.GetPasajeroById(request.PasajeroId);
            if (pasajero == null)
                throw new ArgumentException($"No existe ningún pasajero con el Id {request.PasajeroId}");


            return new Domain.Entities.Reservas()
            {
                FechaReserva = request.FechaReserva,
                EstadoReserva = request.EstadoReserva,
                Vuelo = vuelo,
                Pasajero = pasajero,
            };
        }

        public static ReservaResponse ToReservaResponse(Domain.Entities.Reservas reserva)
        {
            return new ReservaResponse()
            {
                Id = reserva.Id,
                FechaReserva = reserva.FechaReserva,
                EstadoReserva = reserva.EstadoReserva,
                Vuelo = ProgramacionVuelos.ToVueloResponse(reserva.Vuelo),
                Pasajero = MapPasajeros.ToPasajeroResponse(reserva.Pasajero),
            };
        }

        public static void ToReservaEntityUpdate(DomainEntity.Reservas reserva, ReservaRequest request)
        {
            reserva.FechaReserva = request.FechaReserva;
            reserva.EstadoReserva = request.EstadoReserva;
            reserva.Vuelo = reserva.Vuelo;       // Esto es provisorio
            reserva.Pasajero = reserva.Pasajero;
        }
    }
}
