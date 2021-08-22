using System;

namespace Piedra_Papel_Tijera.Models
{
    public class Exceptions
    {
        private readonly Exception _ex;
        public Exceptions(Exception ex)
        {
            _ex = ex;
        }
        public string Mensaje { get { return _ex.Message; } }
        public string MensajeEspecifico { 
            get 
            {
                Exception realErr = _ex;
                while (realErr.InnerException != null) realErr = realErr.InnerException;
                return realErr.Message;
            }
        }
        public string StackTrace { get { return _ex.StackTrace; } }
    }
}
