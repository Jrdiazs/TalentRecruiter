using System;

namespace Models
{
    /// <summary>
    /// Excepcion controlada para validar objetos o validaciones de negocio
    /// </summary>
    public class ValidModelException : Exception
    {
        public ValidModelException() : base()
        {
        }

        public ValidModelException(string message) : base(message)
        {
        }

        public ValidModelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}