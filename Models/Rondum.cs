using System;
using System.Collections.Generic;

#nullable disable

namespace Piedra_Papel_Tijera.Models
{
    public partial class Rondum
    {
        public Rondum()
        {
            JugadorBatallaRonda = new HashSet<JugadorBatallaRondum>();
        }

        public int IdRonda { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<JugadorBatallaRondum> JugadorBatallaRonda { get; set; }
    }
}
