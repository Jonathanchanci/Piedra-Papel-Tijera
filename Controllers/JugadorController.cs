using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Piedra_Papel_Tijera.Models;
using Piedra_Papel_Tijera.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Piedra_Papel_Tijera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        // GET: api/Batallas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jugador>>> GetJugadores()
        {
            var battle = await new JugadorRepository().Getlist();
            return battle.ToList();
        }

        // GET: api/Batallas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jugador>> GetJugador(int id)
        {
            var jugador = await new JugadorRepository().GetById(id);
            if (jugador == null)
                return NotFound(new { message = $"No existe el jugador con id {id}" });

            return jugador;
        }
    }
}
