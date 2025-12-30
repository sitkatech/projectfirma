using System;
using System.Runtime.Serialization;

namespace ProjectFirma.Web.Auth
{
    public class Auth0ClaimNotFoundException : Exception
    {
        public Auth0ClaimNotFoundException(string message)
            : base(message)
        {
        }

        public Auth0ClaimNotFoundException()
        {
        }

        public Auth0ClaimNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected Auth0ClaimNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}