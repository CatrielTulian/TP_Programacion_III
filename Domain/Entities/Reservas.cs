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
        public Vuelos? Vuelo { get; set; } = new Vuelos();
        public Pasajeros? Pasajero { get; set; }  = new Pasajeros();
        public DateTime FechaReserva { get; set; }
        public bool EstadoReserva { get; set; } = false;

        public string User { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

    }
}
