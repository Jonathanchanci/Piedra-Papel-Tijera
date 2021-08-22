
using Piedra_Papel_Tijera.Models;
using System.Collections.Generic;
using System.Linq;

namespace Piedra_Papel_Tijera.Repository
{
    public class JugadorBatallaRepository : Repository<JugadorBatalla>
    {
        public JugadorBatalla GetLastByIdJugador(int idJugador)
        {
            return _context.JugadorBatallas.Where(j => j.FkIdJugador == idJugador).OrderBy(o => o.IdJugadorBatalla).LastOrDefault();
        }

        public List<JugadorBatalla> GetByIdBatalla(int idBatalla)
        {
            return _context.JugadorBatallas.Where(j => j.FkIdBatalla == idBatalla).ToList();
        }
    }
}
