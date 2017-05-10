using System;

namespace Keystone.Common
{
    public class KeystoneUserClaims : IKeystoneUserClaims
    {
        // core
        public Guid UserGuid { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string LoginName { get; set; }

        public Guid? OrganizationGuid { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationShortName { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
        public string TimeZoneIana { get; set; }

        // address info
        public string Address1 { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string PostalCode { get; set; }
        public string CountryName { get; set; }
        public string PrimaryPhone { get; set; }

        // misc
        public string PersonalURL { get; set; }
    }
}
