using Microsoft.AspNetCore.Mvc;
using Piedra_Papel_Tijera.Models;
using Piedra_Papel_Tijera.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Piedra_Papel_Tijera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        // GET: api/Batallas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimiento>>> GetBatallas()
        {
            var mov = await new MovimientoRepository().Getlist();
            return mov.ToList();
        }
    }
}
