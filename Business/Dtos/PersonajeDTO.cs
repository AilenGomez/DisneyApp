using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class PersonajeDTO
    {
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public long? Peso { get; set; }
        public string Historia { get; set; }
        public int? idRodaje { get; set; }

    }
}
