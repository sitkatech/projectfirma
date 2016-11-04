using System;

namespace LtInfo.Common
{
    public class SitkaDuplicateRecordException : SitkaDisplayErrorException
    {
        public SitkaDuplicateRecordException(string objectName, int id)
            : base(string.Format("{0} with ID# {1} already exists", objectName, id)) { }

        public SitkaDuplicateRecordException(string objectName, Guid guid)
            : base(string.Format("{0} with GUID {1} already exists", objectName, guid)) { }

        public SitkaDuplicateRecordException(string objectName, string matchingCriteria)
            : base(string.Format("{0} with with criteria \"{1}\" already exists", objectName, matchingCriteria)) { }
    }
}