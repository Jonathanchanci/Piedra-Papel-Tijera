using Microsoft.EntityFrameworkCore;
using Piedra_Papel_Tijera.Models;
using System.Collections.Generic;
using System.Linq;

namespace Piedra_Papel_Tijera.Repository
{
    public class BatallaRepository: Repository<Batalla>
    {
        public List<Batalla> GetListCompleteBatalla()
        {
            return _context.Batallas.Include(jb => jb.JugadorBatallas).ToList();
        }
    }
}
