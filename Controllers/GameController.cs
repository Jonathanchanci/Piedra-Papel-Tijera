using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Piedra_Papel_Tijera.Models;
using Piedra_Papel_Tijera.Negocio;
using Piedra_Papel_Tijera.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Piedra_Papel_Tijera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpPost]
        [Route("IniciarBatalla")]
        public async Task<IActionResult> PostIniciarBatalla(string[] jugadores)
        {
            try
            {
                var valid = Validations.ValidarIniciarBatalla(jugadores);
                if (valid.Resultado)
                {
                    return Ok(await Logic.IniciarBatallaAsync(jugadores));
                }
                else
                {
                    return BadRequest(valid);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Exceptions(ex));
            }
        }
    }
}
