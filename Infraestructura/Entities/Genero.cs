using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructura.Entities
{
    public partial class Genero : BaseEntity
    {
        public string Nombre { get; set; }
        //public Base64FormattingOptions imagen { get; set; }
        public int? idRodaje { get; set; }
        public virtual Rodaje Rodaje { get; set; }
    }
}
