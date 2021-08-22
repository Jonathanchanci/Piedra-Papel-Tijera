using System;
using System.Collections.Generic;

#nullable disable

namespace Piedra_Papel_Tijera.Models
{
    public partial class Turno
    {
        public int IdTurno { get; set; }
        public int FkIdJugadorBatallaRonda { get; set; }
        public int FkIdMovimiento { get; set; }

        public virtual JugadorBatallaRondum FkIdJugadorBatallaRondaNavigation { get; set; }
        public virtual Movimiento FkIdMovimientoNavigation { get; set; }
    }
}
