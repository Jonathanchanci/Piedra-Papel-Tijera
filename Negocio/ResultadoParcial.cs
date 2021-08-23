using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Piedra_Papel_Tijera.Negocio
{
    public class ResultadoParcial
    {
        public int IdRonda { get; set; }
        public string NombreRonda { get; set; }
        public string NombreJugador { get; set; }
        public string Resultado { get; set; }
    }
}
