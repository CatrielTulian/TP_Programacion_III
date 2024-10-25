using Application.Interfaces;
using Contract.Mappings;
using Contract.Reservas.Request;
using Contract.Reservas.Response;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservarepository;
        private readonly IVueloRepository _vuelorepository;
        private readonly IPasajeroRepository _pasajerorepository;

        public ReservaService(IReservaRepository reservarepository, IVueloRepository vuelorepository, IPasajeroRepository pasajerorepository)
        {
            _reservarepository = reservarepository;
            _vuelorepository = vuelorepository;
            _pasajerorepository = pasajerorepository;
        }

        public void CreateReserva(ReservaRequest reserva)
        {
            var reservaEntity = ProgramacionReserva.ToReservasEntity(reserva, _vuelorepository, _pasajerorepository);

            _reservarepository.AddReserva(reservaEntity);
        }
        
        public List<ReservaResponse> GetAllReservas()
        {
            var reservas = _reservarepository.GetReservas();
            var reservasResponse = new List<ReservaResponse>();

            foreach(var reserva in reservas)
            {
                var reservaResp = ProgramacionReserva.ToReservaResponse(reserva);

                reservasResponse.Add(reservaResp);
            }
            return reservasResponse;
        }

        public ReservaResponse? GetReservaById(int id)
        {
            var reserva = _reservarepository.GetReservaById(id);

            if (reserva != null)
            {
                return ProgramacionReserva.ToReservaResponse(reserva);
            }

            return null;
        }

        public bool UpdateReserva(int id, ReservaRequest reserva)
        {
            var reservaEntity = _reservarepository.GetReservaById(id);

            if (reservaEntity != null)
            {
                ProgramacionReserva.ToReservaEntityUpdate(reservaEntity, reserva);
                _reservarepository.UpdateReserva(reservaEntity);
                return true;
            }
            return false;
            
        }

        public bool DeleteReserva(int id) 
        {
            var reserva = _reservarepository.GetReservaById(id);

            if(reserva != null)
            {
                _reservarepository.DeleteReserva(reserva);
                return true;
            }
            return false;
        }
    }
}
