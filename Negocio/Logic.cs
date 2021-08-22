using Piedra_Papel_Tijera.Models;
using Piedra_Papel_Tijera.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Piedra_Papel_Tijera.Negocio
{
    public static class Logic
    {
        public static async Task<List<Jugador>> IniciarBatallaAsync(string[] jugadores)
        {
            try
            {
                string nombreBatalla = string.Empty;
                List<Jugador> jugadoresList = new();
                Batalla batalla = new();
                List<JugadorBatalla> jugadorBatallaList = new();
                int cont = 0;

                foreach (string nomJugador in jugadores)
                {
                    cont++;
                    nombreBatalla += nomJugador + (cont == jugadores.Length ? "" : " VS ");
                    Jugador j = new() { Nombre = nomJugador };                    
                    jugadoresList.Add(await new JugadorRepository().Create(j));
                }
                batalla.Nombre = nombreBatalla;
                batalla = await new BatallaRepository().Create(batalla);
                foreach (Jugador jugador in jugadoresList)
                {
                    JugadorBatalla jb = new()
                    {
                        FkIdBatalla = batalla.IdBatalla,
                        FkIdJugador = jugador.IdJugador,
                    };
                    jugadorBatallaList.Add(await new JugadorBatallaRepository().Create(jb));
                }
                return jugadoresList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<JugadorBatalla> RegistrarMovimiento(int idJugador, int idMovimiento)
        {
            try
            {
                JugadorBatalla jugadorBatalla = new JugadorBatallaRepository().GetLastByIdJugador(idJugador);
                JugadorBatallaRondum jugadorBatallaRonda = new JugadorBatallaRondaRepository().GetLastJugadorBatallaRondaByBatalla(jugadorBatalla.FkIdBatalla);
                var listJugadorBatalla = new JugadorBatallaRepository().GetByIdBatalla(jugadorBatalla.FkIdBatalla);
                List<JugadorBatallaRondum> jbrListTotal = new JugadorBatallaRondaRepository().GetListJugadorBatallaRondaByBatalla(jugadorBatalla.FkIdBatalla);

                if (jugadorBatallaRonda == null)//Primer turno
                {
                    int numeroRonda = 0;
                    if (jbrListTotal.Count != 0) numeroRonda = jbrListTotal.Count / listJugadorBatalla.Count; 
                    Rondum rondum = await new RondaRepository().Create(new Rondum() { Nombre = $"Ronda # {numeroRonda + 1}"});
                    JugadorBatallaRondum jbr = new()
                    {
                        FkIdJugadorBatalla = jugadorBatalla.IdJugadorBatalla,
                        FkIdRonda = rondum.IdRonda,
                        FkIdMovimiento = idMovimiento
                    };
                    JugadorBatallaRondum jugadorBatallaRondum = await new JugadorBatallaRondaRepository().Create(jbr);
                    return jugadorBatalla;
                }
                else //Segundo turno
                {
                    JugadorBatallaRondum jbr = new()
                    {
                        FkIdJugadorBatalla = jugadorBatalla.IdJugadorBatalla,
                        FkIdRonda = jugadorBatallaRonda.FkIdRonda,
                        FkIdMovimiento = idMovimiento
                    };
                    JugadorBatallaRondum jugadorBatallaRondum = await new JugadorBatallaRondaRepository().Create(jbr);
                    //Registrar ganador de ronda y de juego si aplica
                    jugadorBatalla = await PiedraPapelTijera(jugadorBatallaRonda, jugadorBatallaRondum, jugadorBatalla.FkIdBatalla);
                }

                return jugadorBatalla;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task<JugadorBatalla> PiedraPapelTijera(JugadorBatallaRondum jugador1, JugadorBatallaRondum jugador2, int idBatalla)
        {
            try
            {
                #region variables
                const string empate = "EMPATE";
                const string ganador = "GANADOR";
                const string perdedor = "PERDEDOR";
                const string piedra = "PIEDRA";
                const string papel = "PAPEL";
                const string tijera = "TIJERA";
                JugadorBatalla jugadorGanador = new();
                var resultList = await new ResultadoBatallaRondaRepository().Getlist();
                int idEmpate = resultList.Where(x => x.Nombre == empate).FirstOrDefault().IdResultadoBatallaRonda;
                int idGanador = resultList.Where(x => x.Nombre == ganador).FirstOrDefault().IdResultadoBatallaRonda;
                int idPerdedor = resultList.Where(x => x.Nombre == perdedor).FirstOrDefault().IdResultadoBatallaRonda;
                var movJugador1 = await new MovimientoRepository().GetById(jugador1.FkIdMovimiento);
                var movJugador2 = await new MovimientoRepository().GetById(jugador2.FkIdMovimiento);
                #endregion

                #region Logica de juego
                if (movJugador1.Nombre == movJugador2.Nombre)
                {
                    jugador1.FkIdResultadoBatallaRonda = idEmpate;
                    jugador2.FkIdResultadoBatallaRonda = idEmpate;
                }
                else if (movJugador1.Nombre == piedra && movJugador2.Nombre == papel)
                {
                    jugador1.FkIdResultadoBatallaRonda = idPerdedor;
                    jugador2.FkIdResultadoBatallaRonda = idGanador;
                }
                else if (movJugador1.Nombre == piedra && movJugador2.Nombre == tijera)
                {
                    jugador1.FkIdResultadoBatallaRonda = idGanador;
                    jugador2.FkIdResultadoBatallaRonda = idPerdedor;
                }
                else if (movJugador1.Nombre == papel && movJugador2.Nombre == piedra)
                {
                    jugador1.FkIdResultadoBatallaRonda = idGanador;
                    jugador2.FkIdResultadoBatallaRonda = idPerdedor;
                }
                else if (movJugador1.Nombre == papel && movJugador2.Nombre == tijera)
                {
                    jugador1.FkIdResultadoBatallaRonda = idPerdedor;
                    jugador2.FkIdResultadoBatallaRonda = idGanador;
                }
                else if (movJugador1.Nombre == tijera && movJugador2.Nombre == piedra)
                {
                    jugador1.FkIdResultadoBatallaRonda = idPerdedor;
                    jugador2.FkIdResultadoBatallaRonda = idGanador;
                }
                else if (movJugador1.Nombre == tijera && movJugador2.Nombre == papel)
                {
                    jugador1.FkIdResultadoBatallaRonda = idGanador;
                    jugador2.FkIdResultadoBatallaRonda = idPerdedor;
                }
                #endregion

                List<JugadorBatallaRondum> jbrList = new()
                {
                    jugador1,
                    jugador2
                };

                if (await new JugadorBatallaRondaRepository().UpdateRange(jbrList))
                {
                    jugadorGanador = await DeclararGanador(idBatalla, idGanador);
                }
                else
                {
                    throw new Exception("No se pudo actualizar la información del resultado");
                }
                return jugadorGanador;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task<JugadorBatalla> DeclararGanador(int idBatalla, int idGanador)
        {
            try
            {
                JugadorBatalla jugadorGanador = new();
                var listjb = new JugadorBatallaRepository().GetByIdBatalla(idBatalla);
                List<JugadorBatallaRondum> jbrList = new JugadorBatallaRondaRepository().GetWinsJugadorBatallaRondaByBatalla(idBatalla, idGanador);
                foreach (JugadorBatalla jb in listjb)
                {
                    int contador = 0;
                    foreach (JugadorBatallaRondum jbr in jbrList)
                    {
                        if (jb.FkIdJugador == jbr.FkIdJugadorBatallaNavigation.FkIdJugador)
                            contador++;
                    }
                    if (contador > 2)
                    {
                        jugadorGanador = jb;
                        break;
                    }
                }
                
                if (jugadorGanador.IdJugadorBatalla != 0)
                {
                    jugadorGanador.Gadador = true;
                    var guardo = await new JugadorBatallaRepository().Update(jugadorGanador);
                    foreach (var item in listjb)
                    {
                        if (jugadorGanador.FkIdJugador != item.FkIdJugador)
                        { 
                            item.Gadador = false;
                            var guardo2 = await new JugadorBatallaRepository().Update(item);
                        }
                    }
                }

                return jugadorGanador;
            }
            catch (Exception)
            {
                throw;
            }
        } 
    }
}
