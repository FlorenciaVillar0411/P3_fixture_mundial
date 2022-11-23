using System;
namespace Excepciones
{
    public class PartidoException :Exception
    {
        public PartidoException()
        {
        }

        public PartidoException(string message) : base(message)
        {
        }

        public PartidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
