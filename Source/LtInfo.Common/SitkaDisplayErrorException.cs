using System;
using System.Runtime.Serialization;

namespace LtInfo.Common
{
    public class SitkaDisplayErrorException : Exception
    {
        public SitkaDisplayErrorException(string message) : base(message) {}
        public SitkaDisplayErrorException() {}
        public SitkaDisplayErrorException(string message, Exception innerException) : base(message, innerException) {}
        protected SitkaDisplayErrorException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}