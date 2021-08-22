using Piedra_Papel_Tijera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Piedra_Papel_Tijera.Repository
{
    public class ResultadoBatallaRondaRepository:Repository<ResultadoBatallaRondum>
    {
        public ResultadoBatallaRondum GetIdByName(string nombre)
        {
            return _context.ResultadoBatallaRonda.Where(j => j.Nombre == nombre).FirstOrDefault();
        }
    }
}
