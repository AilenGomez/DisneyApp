using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Entities
{
    public class Seguridad : BaseEntity
    {
        public string User { get; set; }
        public string email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
