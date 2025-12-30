namespace ProjectFirma.Web.Auth
{
    public class Auth0OpenIDClaimTypes
    {
        public static readonly string LoginName = "nickname";
        public static readonly string OrganizationName = "organization_name";
        public static readonly string OrganizationShortName = "organization_shortname";
        public static readonly string Subject = "sub";
        public static readonly string Name = "name";
        public static readonly string FamilyName = "family_name";
        public static readonly string GivenName = "given_name";
        public static readonly string Email = "email";
    }
}