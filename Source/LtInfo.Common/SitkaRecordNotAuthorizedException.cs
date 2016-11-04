namespace LtInfo.Common
{
    public class SitkaRecordNotAuthorizedException : SitkaDisplayErrorException
    {
        public SitkaRecordNotAuthorizedException(string objectTypeName, int id) : base(string.Format("You are not authorized to view {0} ID# {1}", objectTypeName, id)) {}
        public SitkaRecordNotAuthorizedException(string objectTypeName, string stringID) : base(string.Format("You are not authorized to view {0} {1}", objectTypeName, stringID)) { }
        public SitkaRecordNotAuthorizedException(string message) : base(message) { }
    }
}