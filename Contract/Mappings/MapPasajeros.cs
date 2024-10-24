using Contract.Pasajeros.Request;
using Contract.Pasajeros.Response;
using DomainEntity = Domain.Entities;

namespace Contract.Mappings
{
    public class MapPasajeros
    {
        public static Domain.Entities.Pasajeros ToPasajerosEntity(PasajeroRequest request)
        {
            return new Domain.Entities.Pasajeros()
            {
                NroDoc = request.NroDoc,
                Nombre = request.Nombre,
                Apellido = request.Apellido
            };
        }

        public static PasajeroResponse ToPasajeroResponse(Domain.Entities.Pasajeros pasajero)
        {
            return new PasajeroResponse()
            {
                Id = pasajero.Id,
                NroDoc = pasajero.NroDoc,
                Nombre = pasajero.Nombre,
                Apellido = pasajero.Apellido,
            };
        }

        public static void ToPasajeroEntityUpdate(DomainEntity.Pasajeros pasajero, PasajeroRequest request)
        {
            pasajero.NroDoc = request.NroDoc;
            pasajero.Nombre = request.Nombre;
            pasajero.Apellido = request.Apellido;
        }
    }
}
