using System;
using System.Collections.Generic;

#nullable disable

namespace Piedra_Papel_Tijera.Models
{
    public partial class Movimiento
    {
        public Movimiento()
        {
            JugadorBatallaRonda = new HashSet<JugadorBatallaRondum>();
        }

        public int IdMovimiento { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<JugadorBatallaRondum> JugadorBatallaRonda { get; set; }
    }
}
