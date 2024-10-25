using System;

namespace CapaDeNegocio.Exceptions
{
    public class CustomTokenExpiredException : Exception
    {
        public CustomTokenExpiredException() : base("El token ha expirado.") { }

        public CustomTokenExpiredException(string message) : base(message) { }

        public CustomTokenExpiredException(string message, Exception innerException) : base(message, innerException) { }
    }
}
