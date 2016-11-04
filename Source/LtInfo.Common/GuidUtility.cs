using System;

namespace LtInfo.Common
{
    public class GuidUtility
    {
        public static bool TryParseGuid(string stringToParse, out Guid parsedGuid)
        {
            parsedGuid = Guid.Empty;
            try
            {
                parsedGuid = new Guid(stringToParse);
            }
            catch
            {
                // Deliberately suppress exception and return false for "bad parse"
                return false;
            }
            return true;
        }
    }
}