using System;
using System.Runtime.Serialization;

namespace Keystone.Common
{
    public class KeystoneClaimNotFoundException : Exception
    {
        public KeystoneClaimNotFoundException(string message) : base(message) {}
        public KeystoneClaimNotFoundException() {}
        public KeystoneClaimNotFoundException(string message, Exception innerException) : base(message, innerException) {}
        protected KeystoneClaimNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}