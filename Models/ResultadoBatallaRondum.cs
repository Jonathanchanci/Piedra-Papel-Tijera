using System;
using System.Collections.Generic;

#nullable disable

namespace Piedra_Papel_Tijera.Models
{
    public partial class ResultadoBatallaRondum
    {
        public ResultadoBatallaRondum()
        {
            JugadorBatallaRonda = new HashSet<JugadorBatallaRondum>();
        }

        public int IdResultadoBatallaRonda { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<JugadorBatallaRondum> JugadorBatallaRonda { get; set; }
    }
}
