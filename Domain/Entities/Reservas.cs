using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservas
    {
        public int Id { get; set; }
        public List<Vuelos>? Vuelos { get; set; } 
        public List<Pasajeros>? Pasajeros { get; set; } 
        public DateTime FechaReserva { get; set; } 
        public bool EstadoReserva { get; set; }
    }
}
/* Hacer lo mismo que hice con vuelos pero con pasajeros y reservas y tambíen hacerles la inyección de
   dependencia y por ultimo autenticar todo */