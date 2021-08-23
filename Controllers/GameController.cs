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
                    return Ok(await Logic.IniciarBatallaAsync(jugadores));
                else
                    return BadRequest(valid);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Exceptions(ex));
            }
        }

        [HttpGet()]
        [Route("RegistrarMovimiento/{idJugador:int}/{idMovimiento:int}")]
        public async Task<IActionResult> GetRegistrarMovimiento(int idJugador, int idMovimiento)
        {
            try
            {
                var valid = Validations.ValidarRegistrarMovimiento(idJugador, idMovimiento);
                if (valid.Resultado)
                    return Ok(await Logic.RegistrarMovimiento(idJugador,idMovimiento));
                else
                    return BadRequest(valid);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Exceptions(ex));
            }
        }

        [HttpGet]
        [Route("ResultadoParcial/{idBatalla:int}")]
        public async Task<IActionResult> GetResultadoParcial(int idBatalla)
        {
            try
            {
                var valid = Validations.ValidarExisteBatalla(idBatalla);
                if (valid.Resultado)
                    return Ok(await Logic.ResultadoParcial(idBatalla));
                else
                    return BadRequest(valid);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Exceptions(ex));
            }
        }

        [HttpPost]
        [Route("IniciarRevancha")]
        public async Task<IActionResult> PostIniciarRevancha(int[] jugadores)
        {
            try
            {
                var valid = Validations.ValidarIniciarRevancha(jugadores);
                if (valid.Resultado)
                    return Ok(await Logic.IniciarBatallaRevancha(jugadores));
                else
                    return BadRequest(valid);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Exceptions(ex));
            }
        }
    }
}
