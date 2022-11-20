using System;
namespace Excepciones
{
    public class SeleccionException : Exception
    {
        public SeleccionException()
        {
        }

        public SeleccionException(string message) : base(message)
        {
        }

        public SeleccionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
