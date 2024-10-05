using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Pasajeros
    {
        public int Id { get; set; }
        public int NroDoc { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
    }
}
