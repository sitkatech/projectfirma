using System;

namespace LtInfo.Common
{
    public class SitkaGeometryDisplayErrorException : SitkaDisplayErrorException
    {
        public SitkaGeometryDisplayErrorException(string message) : base(message)
        {
            /*
             The real work is done in the other constructor; this just gets us far enough to
             throw the message downhill until we know what the preservedFilenameFullPath is.
             */
        }

        public SitkaGeometryDisplayErrorException(string message, string preservedFilenameFullPath) : base($"{message} A copy of this file has been saved to the ProjectFirma Temp directory here: {preservedFilenameFullPath}")
        {
        }
    }
}