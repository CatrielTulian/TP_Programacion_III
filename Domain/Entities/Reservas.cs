using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservas 
    {
        public int IdReserva { get; set; }
        public Vuelos Vuelos { get; set; } 
        public Pasajeros Paciente { get; set; } 
        public DateTime FechaReserva { get; set; } 
       
        public bool EstadoReserva { get; set; }
    }
}
