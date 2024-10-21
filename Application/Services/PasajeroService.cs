using Application.Interfaces;
using Contract.Mappings;
using Contract.Pasajeros.Request;
using Contract.Pasajeros.Response;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PasajeroService : IPasajerosService
    {
        private readonly IPasajeroRepository _pasajerorepository;

        public PasajeroService(IPasajeroRepository pasajerorepository)
        {
            _pasajerorepository = pasajerorepository;
        }

        public void CreatePasajero(CreatePasajeroRequest pasajero)
        {
            var pasajeroEntity = MapPasajeros.ToPasajerosEntity(pasajero);

            _pasajerorepository.AddPasajero(pasajeroEntity);
        }

        public List<PasajeroResponse> GetAllPasajeros()
        {
            var pasajeros = _pasajerorepository.GetPasajeros();
            var pasajerosResponse = new List<PasajeroResponse>();

            foreach (var pasajero in pasajeros)
            {
                var pasajeroResp = MapPasajeros.ToPasajeroResponse(pasajero);

                pasajerosResponse.Add(pasajeroResp);
            }

            return pasajerosResponse;
        }

    }
}
