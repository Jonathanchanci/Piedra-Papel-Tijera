using System;
using System.Collections.Generic;

#nullable disable

namespace Piedra_Papel_Tijera.Models
{
    public partial class Movimiento
    {
        public Movimiento()
        {
            Turnos = new HashSet<Turno>();
        }

        public int IdMovimiento { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Turno> Turnos { get; set; }
    }
}
