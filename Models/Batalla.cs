using System;
using System.Collections.Generic;

#nullable disable

namespace Piedra_Papel_Tijera.Models
{
    public partial class Batalla
    {
        public Batalla()
        {
            JugadorBatallas = new HashSet<JugadorBatalla>();
        }

        public int IdBatalla { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public virtual ICollection<JugadorBatalla> JugadorBatallas { get; set; }
    }
}
