using System;

namespace LtInfo.Common
{
    public class SitkaRecordNotFoundException : SitkaDisplayErrorException
    {
        public SitkaRecordNotFoundException(string objectName, int id)
            : base(string.Format("Could not find {0} with ID# {1}", objectName, id)) {}

        public SitkaRecordNotFoundException(string objectName, Guid guid)
            : base(string.Format("Could not find {0} with GUID {1}", objectName, guid)) { }

        public SitkaRecordNotFoundException(string objectName, string matchingCriteria)
            : base(string.Format("Could not find {0} with criteria \"{1}\"", objectName, matchingCriteria)) { }

        public SitkaRecordNotFoundException(string errorMessage) : base(errorMessage) { }
    }
}