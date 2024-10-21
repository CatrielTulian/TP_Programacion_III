using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vuelos 
    {
        
        public int Id { get; set; }
        public int Capacidad { get; set; }
        public List<Reservas>? Reservas { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
    }
}
