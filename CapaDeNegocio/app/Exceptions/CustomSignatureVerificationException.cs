using System;

namespace CapaDeNegocio.Exceptions
{
    public class CustomSignatureVerificationException : Exception
    {
        public CustomSignatureVerificationException() : base("La firma del token no es válida.") { }

        public CustomSignatureVerificationException(string message) : base(message) { }

        public CustomSignatureVerificationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
