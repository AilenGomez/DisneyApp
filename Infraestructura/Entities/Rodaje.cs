using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Infraestructura.Entities
{
    public partial class Rodaje
    {
        public Rodaje()
        {
            Generos = new HashSet<Genero>();
            Personajes = new HashSet<Personaje>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idRodaje { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Calificacion { get; set; }
        public int? idPersonaje { get; set; }
        public virtual Personaje Personaje { get; set; }
        public virtual ICollection<Genero> Generos { get; set; }
        public virtual ICollection<Personaje> Personajes { get; set; }
    }
}
