using System;

namespace Excepciones
{
    public class PaisException : Exception
    {
        public PaisException()
        {
        }

        public PaisException(string message) : base(message)
        {
        }

        public PaisException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
