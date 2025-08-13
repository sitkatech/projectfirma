namespace ProjectFirma.Web.Auth
{
    public class Auth0OpenIDClaimTypes
    {
        public static readonly string TimeZoneIana = "timezone_iana";
        public static readonly string LoginName = "login_name";
        public static readonly string PrivateIndividual = "private_individual";
        public static readonly string OrganizationIdentifier = "organization_identifier";
        public static readonly string OrganizationName = "organization_name";
        public static readonly string OrganizationShortName = "organization_shortname";
        public static readonly string OrganizationEmailMatch = "organization_email_match";
        public static readonly string AddressStreet = "address_street";
        public static readonly string AddressCity = "address_city";
        public static readonly string AddressState = "address_state";
        public static readonly string AddressCountry = "address_country";
        public static readonly string AddressPostalcode = "address_postalcode";
        public static readonly string Subject = "sub";
        public static readonly string LegacyUserId = "user_id";
        public static readonly string Name = "name";
        public static readonly string FamilyName = "family_name";
        public static readonly string GivenName = "given_name";
        public static readonly string Email = "email";
        public static readonly string EmailVerified = "email_verified";
        public static readonly string PhoneNumber = "phone_number";
        public static readonly string WebSite = "website";
        public static readonly string ZoneInfo = "zoneinfo";
    }
}