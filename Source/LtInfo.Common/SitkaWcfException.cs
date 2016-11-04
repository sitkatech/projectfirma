using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LtInfo.Common
{
    public class SitkaWcfException : Exception
    {
        public SitkaWcfException(OperationContext wcfOperationContext, Exception exception) : base(_MakeMessage(wcfOperationContext), exception)
        {
        }

        protected SitkaWcfException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private static string _MakeMessage(OperationContext wcfOperationContext)
        {
            var requestMessage = wcfOperationContext.RequestContext.RequestMessage;
            var message = string.Format("An error occurred in a WCF call, wrapping in order to log it.\r\nWCF Incoming Message:\r\n{0}\r\n", requestMessage);
            return message;
        }
    }
}