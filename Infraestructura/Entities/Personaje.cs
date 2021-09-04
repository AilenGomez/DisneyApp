using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Infraestructura.Entities
{
    public partial class Personaje
    {
        public Personaje()
        {
            Rodajes = new HashSet<Rodaje>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public long? Peso { get; set; }
        public string Historia { get; set; }
        public int? idRodaje { get; set; }

        public virtual Rodaje Rodaje { get; set; }
        public virtual ICollection<Rodaje> Rodajes { get; set; }
    }
}
