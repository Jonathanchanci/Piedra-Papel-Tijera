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
                        if (jugadores[i].Length < 4) { resultValidation.Mensaje += $" -El nombre de jugador {jugadores[i]} es debe ser mayor a 3 caracteres"; }
                    }
                }

                resultValidation.Resultado = string.IsNullOrEmpty(resultValidation.Mensaje);
                return resultValidation;

            }
            catch (Exception ex)
            {
                throw;
            }            
        }
    }
}
