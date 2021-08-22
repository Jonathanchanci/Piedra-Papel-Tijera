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
    public class BatallaController : ControllerBase
    {
        // GET: api/Batallas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batalla>>> GetBatallas()
        {
            var battle = await new BatallaRepository().Getlist();
            return battle.ToList();
        }

        // GET: api/Batallas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Batalla>> GetBatalla(int id)
        {
            var battle = await new BatallaRepository().GetById(id);
            if (battle == null)
                return NotFound(new { message = $"No existe la batalla con id {id}" });

            return battle;
        }

        // PUT: api/Batallas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatalla(int id, Batalla batalla)
        {
            if (id != batalla.IdBatalla)
                return BadRequest();

            var battle = await new BatallaRepository().Update(batalla);
            if (!battle)
                return NotFound();

            return Ok(new { message = "Batalla actualizada con exito" });
        }

        // POST: api/Batallas
        [HttpPost]
        public async Task<ActionResult<Batalla>> PostBatalla(Batalla batalla)
        {
            return await new BatallaRepository().Create(batalla);
        }

        // DELETE: api/Batallas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatalla(int id)
        {
            var battle = await new BatallaRepository().Delete(id);
            if (!battle)
                return NotFound();

            return Ok(new { message = "Batalla eliminada con exito" });
        }
    }
}
