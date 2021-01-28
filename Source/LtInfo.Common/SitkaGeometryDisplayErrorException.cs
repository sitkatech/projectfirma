using System;

namespace LtInfo.Common
{
    public class SitkaGeometryDisplayErrorException : SitkaDisplayErrorException
    {
        public SitkaGeometryDisplayErrorException(string message) : base(message) { }
        public SitkaGeometryDisplayErrorException() { }
        public SitkaGeometryDisplayErrorException(string message, Exception innerException) : base(message, innerException) { }
    }
}