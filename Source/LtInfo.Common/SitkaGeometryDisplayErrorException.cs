using System;

namespace LtInfo.Common
{
    public class SitkaGeometryDisplayErrorException : SitkaDisplayErrorException
    {
        public SitkaGeometryDisplayErrorException(string message) : base($"{message} A copy of this file has been saved to the ProjectFirma Temp directory") { }
    }
}