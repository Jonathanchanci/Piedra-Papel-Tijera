using System;
using System.Collections.Generic;

#nullable disable

namespace Piedra_Papel_Tijera.Models
{
    public partial class JugadorBatalla
    {
        public JugadorBatalla()
        {
            JugadorBatallaRonda = new HashSet<JugadorBatallaRondum>();
        }

        public int IdJugadorBatalla { get; set; }
        public int FkIdBatalla { get; set; }
        public int FkIdJugador { get; set; }
        public bool? Gadador { get; set; }

        public virtual Batalla FkIdBatallaNavigation { get; set; }
        public virtual Jugador FkIdJugadorNavigation { get; set; }
        public virtual ICollection<JugadorBatallaRondum> JugadorBatallaRonda { get; set; }
    }
}
