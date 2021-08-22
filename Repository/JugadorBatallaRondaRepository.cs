using Microsoft.EntityFrameworkCore;
using Piedra_Papel_Tijera.Models;
using System.Collections.Generic;
using System.Linq;

namespace Piedra_Papel_Tijera.Repository
{
    public class JugadorBatallaRondaRepository: Repository<JugadorBatallaRondum>
    {
        public JugadorBatallaRondum GetLastJugadorBatallaRondaByBatalla(int idBatalla)
        {
            return _context.JugadorBatallaRonda.Include(i => i.FkIdJugadorBatallaNavigation)
                .Where(jbr => jbr.FkIdJugadorBatallaNavigation.FkIdBatalla == idBatalla && jbr.FkIdResultadoBatallaRonda == null)
                .OrderBy(o => o.IdJugadorBatallaRonda).LastOrDefault();
        }

        public List<JugadorBatallaRondum> GetWinsJugadorBatallaRondaByBatalla(int idBatalla, int idGanador)
        {
            return _context.JugadorBatallaRonda.Include(jb => jb.FkIdJugadorBatallaNavigation)
                .Where(jbr => jbr.FkIdJugadorBatallaNavigation.FkIdBatalla == idBatalla && jbr.FkIdResultadoBatallaRonda == idGanador).ToList();
        }

        public List<JugadorBatallaRondum> GetListJugadorBatallaRondaByBatalla(int idBatalla)
        {
            return _context.JugadorBatallaRonda.Where(jbr => jbr.FkIdJugadorBatallaNavigation.FkIdBatalla == idBatalla).ToList();
        }
    }
}
