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
    }
}
