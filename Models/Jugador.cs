using System;
using System.Collections.Generic;

#nullable disable

namespace Piedra_Papel_Tijera.Models
{
    public partial class Jugador
    {
        public Jugador()
        {
            JugadorBatallas = new HashSet<JugadorBatalla>();
        }

        public int IdJugador { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<JugadorBatalla> JugadorBatallas { get; set; }
    }
}
