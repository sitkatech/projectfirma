namespace Keystone.Common
{
    public static class KeystoneClaimTypes
    {
        public const string KeystoneClaimTypesBaseUri = "http://keystone.sitkatech.com/2012/04/identity/claims/";
        public static readonly string TimeZone = string.Format("{0}timezone", KeystoneClaimTypesBaseUri);
        public static readonly string TimeZoneIana = string.Format("{0}timezoneiana", KeystoneClaimTypesBaseUri);
        public static readonly string OrganizationIdentifier = string.Format("{0}organizationidentifier", KeystoneClaimTypesBaseUri);
        public static readonly string OrganizationName = string.Format("{0}organizationname", KeystoneClaimTypesBaseUri);
        public static readonly string OrganizationShortName = string.Format("{0}organizationshortname", KeystoneClaimTypesBaseUri);
        public static readonly string LoginName = string.Format("{0}loginname", KeystoneClaimTypesBaseUri);
        public static readonly string AccountVerified = string.Format("{0}accountverified", KeystoneClaimTypesBaseUri);
        public static readonly string EmailDomainMatchesOrganization = string.Format("{0}emaildomainmatchesorganization", KeystoneClaimTypesBaseUri);
    }

}
