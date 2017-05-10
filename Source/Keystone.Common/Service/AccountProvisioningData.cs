using System;
using System.Runtime.Serialization;

namespace Keystone.Common.Service
{
    public enum ProvisionResult
    {
        None = 0,
        Ignored = 1,
        Processed = 2,
        Error = 3
    }

    [DataContract]
    public class AccountProvisioningData
    {
        [DataMember]
        public Guid UserIdentifier { get; set; }

        [DataMember]
        public Guid? OrganizationIdentifier { get; set; }

        [DataMember]
        public string OrganizationName { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string LoginName { get; set; }
    }
}
