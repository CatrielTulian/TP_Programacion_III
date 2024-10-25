using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pasajeros : Persona
    {
        public List<Reservas>? Reservas {  get; set; }
    }
}
