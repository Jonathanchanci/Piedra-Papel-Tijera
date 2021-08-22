using Piedra_Papel_Tijera.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Piedra_Papel_Tijera
{
    public partial class JugadorBatallaRondum
    {
        public int IdJugadorBatallaRonda { get; set; }
        public int FkIdJugadorBatalla { get; set; }
        public int FkIdRonda { get; set; }
        public int? FkIdResultadoBatallaRonda { get; set; }
        public int FkIdMovimiento { get; set; }

        public virtual JugadorBatalla FkIdJugadorBatallaNavigation { get; set; }
        public virtual ResultadoBatallaRondum FkIdResultadoBatallaRondaNavigation { get; set; }
        public virtual Rondum FkIdRondaNavigation { get; set; }
        public virtual Movimiento FkIdMovimientoNavigation { get; set; }
    }
}
