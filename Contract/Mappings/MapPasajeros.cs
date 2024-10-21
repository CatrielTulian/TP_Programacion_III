using Contract.Pasajeros.Request;
using Contract.Pasajeros.Response;

namespace Contract.Mappings
{
    public class MapPasajeros
    {
        public static Domain.Entities.Pasajeros ToPasajerosEntity(CreatePasajeroRequest request)
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
                NroDoc = pasajero.NroDoc,
                Nombre = pasajero.Nombre,
                Apellido = pasajero.Apellido,
            };
        }
    }
}
