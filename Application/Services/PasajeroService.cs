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

        public void CreatePasajero(PasajeroRequest pasajero) 
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

        public PasajeroResponse? GetPasajeroById(int id)
        {
            var pasajero = _pasajerorepository.GetPasajeroById(id);

            if(pasajero != null)
            {
                return MapPasajeros.ToPasajeroResponse(pasajero);
            }

            return null;
        }

        public bool UpdatePasajero(int id, PasajeroRequest pasajero)
        {
            var pasajeroEntity = _pasajerorepository.GetPasajeroById(id);

            if (pasajeroEntity != null)
            {
                MapPasajeros.ToPasajeroEntityUpdate(pasajeroEntity, pasajero);
                _pasajerorepository.UpdatePasajero(pasajeroEntity);

                return true;
            }

            return false;
        }

        public bool DeletePasajero(int id) 
        {
            var pasajero = _pasajerorepository.GetPasajeroById(id);

            if( pasajero != null )
            {
                _pasajerorepository.DeletePasajero(pasajero);
                return true;
            }
            return false;
        }
    }
}
