using Piedra_Papel_Tijera.Models;
using Piedra_Papel_Tijera.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Piedra_Papel_Tijera.Negocio
{
    public class ResultValidation
    {
        public string EventoValidado { get; set; }
        public bool Resultado { get; set; }
        public string Mensaje { get; set; }
    }
    public static class Validations
    {
        public static ResultValidation ValidarIniciarBatalla(string[] jugadores)
        {
            try
            {
                ResultValidation resultValidation = new ResultValidation()
                {
                    EventoValidado = "IniciarBatalla"
                };
                //Validar Nombres vacios
                for (int i = 0; i < jugadores.Length ; i++)
                {
                    if (string.IsNullOrEmpty(jugadores[i])) { resultValidation.Mensaje += $" -El nombre del jugador {i+1} es requerido"; }
                }
                if (string.IsNullOrEmpty(resultValidation.Mensaje))
                {
                    //Validar logitud de nombres
                    for (int i = 0; i < jugadores.Length ; i++)
                    {
                        if (jugadores[i].Length < 4) { resultValidation.Mensaje += $" -El nombre de jugador {jugadores[i]} debe ser mayor a 3 caracteres"; }
                    }
                }

                resultValidation.Resultado = string.IsNullOrEmpty(resultValidation.Mensaje);
                return resultValidation;

            }
            catch (Exception)
            {
                throw;
            }            
        }

        public static ResultValidation ValidarRegistrarMovimiento(int idJugador, int idMovimiento)
        {
            try
            {
                ResultValidation resultValidation = new ResultValidation()
                {
                    EventoValidado = "RegistrarMovimiento"
                };
                //Validar si existe el jugador
                if(new JugadorRepository().GetById(idJugador).Result == null)
                    resultValidation.Mensaje += $" -El  jugador con ID {idJugador} no existe";
                //Validar si existe el movimiento
                if (new MovimientoRepository().GetById(idMovimiento).Result == null)
                    resultValidation.Mensaje += $" -El  Movimiento con ID {idMovimiento} no existe";

                resultValidation.Resultado = string.IsNullOrEmpty(resultValidation.Mensaje);
                return resultValidation;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ResultValidation ValidarExisteBatalla(int idBatalla)
        {
            try
            {
                ResultValidation resultValidation = new ResultValidation()
                {
                    EventoValidado = "ResultadoParcial"
                };
                if(new BatallaRepository().GetById(idBatalla).Result == null)
                    resultValidation.Mensaje += $" -La batalla con ID {idBatalla} no existe";

                resultValidation.Resultado = string.IsNullOrEmpty(resultValidation.Mensaje);
                return resultValidation;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ResultValidation ValidarIniciarRevancha(int[] jugadores)
        {
            try
            {
                ResultValidation resultValidation = new ResultValidation()
                {
                    EventoValidado = "IniciarRevancha"
                };
                //Validar jugadores existen
                foreach (var item in jugadores)
                {
                    Jugador jugador = new JugadorRepository().GetById(item).Result;
                    if (jugador == null)
                        resultValidation.Mensaje += $" -El jugador con ID {item} no existe";
                }

                resultValidation.Resultado = string.IsNullOrEmpty(resultValidation.Mensaje);
                return resultValidation;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
