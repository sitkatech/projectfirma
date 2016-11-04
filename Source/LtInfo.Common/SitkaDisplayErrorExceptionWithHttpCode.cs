using System;
using System.Net;
using System.Runtime.Serialization;

namespace LtInfo.Common
{
    public class SitkaDisplayErrorExceptionWithHttpCode : SitkaDisplayErrorException
    {
        public HttpStatusCode HttpStatusCode;

        public SitkaDisplayErrorExceptionWithHttpCode(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
        //public SitkaDisplayErrorExceptionWithHttpCode() { }
        public SitkaDisplayErrorExceptionWithHttpCode(HttpStatusCode httpStatusCode, string message, Exception innerException) : base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
        }
        protected SitkaDisplayErrorExceptionWithHttpCode(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}