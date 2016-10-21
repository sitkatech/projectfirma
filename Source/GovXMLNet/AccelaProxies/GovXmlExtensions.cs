using System;

namespace GovXMLNet
{
    /// <summary>
    /// Utility class for extension functions
    /// </summary>
    public static class GovXmlExtensions
    {
        public static string GetAllExceptionMessages(this Exception exp)
        {
            var message = exp.Message;
            var innerException = exp.InnerException;
            while (innerException != null)
            {
                message = message + (string.IsNullOrEmpty(innerException.Message) ? string.Empty : " | " + innerException.Message);
                innerException = innerException.InnerException;
            }
            return message;
        }
    }
}