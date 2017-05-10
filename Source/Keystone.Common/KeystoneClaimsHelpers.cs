using System;
using System.Security.Principal;
using System.Threading;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Web;
using log4net;

namespace Keystone.Common
{
    public class KeystoneClaimsHelpers
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(KeystoneClaimsHelpers));

        public static IKeystoneUserClaims ParseClaims()
        {
            var keystoneUserClaims = new KeystoneUserClaims();

            // core claims always supplied
            keystoneUserClaims.UserGuid = GetGuidClaimValue(ClaimTypes.NameIdentifier);
            keystoneUserClaims.DisplayName = GetStringClaimValue(ClaimTypes.Name);
            keystoneUserClaims.LastName = GetStringClaimValue(ClaimTypes.Surname);
            keystoneUserClaims.FirstName = GetStringClaimValue(ClaimTypes.GivenName);
            keystoneUserClaims.Email = GetStringClaimValue(ClaimTypes.Email);
            keystoneUserClaims.LoginName = GetStringOptionalClaimValue(KeystoneClaimTypes.LoginName);

            // optional claims may or may not be supplied
            keystoneUserClaims.OrganizationGuid = GetGuidOptionalClaimValue(KeystoneClaimTypes.OrganizationIdentifier);
            keystoneUserClaims.OrganizationName = GetStringOptionalClaimValue(KeystoneClaimTypes.OrganizationName);
            keystoneUserClaims.OrganizationShortName = GetStringOptionalClaimValue(KeystoneClaimTypes.OrganizationShortName);
            keystoneUserClaims.Address1 = GetStringOptionalClaimValue(ClaimTypes.StreetAddress);
            keystoneUserClaims.City = GetStringOptionalClaimValue(ClaimTypes.Locality);
            keystoneUserClaims.StateName = GetStringOptionalClaimValue(ClaimTypes.StateOrProvince);
            keystoneUserClaims.PostalCode = GetStringOptionalClaimValue(ClaimTypes.PostalCode);
            keystoneUserClaims.CountryName = GetStringOptionalClaimValue(ClaimTypes.Country);
            keystoneUserClaims.PrimaryPhone = GetStringOptionalClaimValue(ClaimTypes.OtherPhone);
            keystoneUserClaims.PersonalURL = GetStringOptionalClaimValue(ClaimTypes.Webpage);
            keystoneUserClaims.TimeZoneInfo = GetTimeZoneInfoClaimValue(KeystoneClaimTypes.TimeZone);
            keystoneUserClaims.TimeZoneIana = GetStringOptionalClaimValue(KeystoneClaimTypes.TimeZoneIana);

            return keystoneUserClaims;
        }

        public static Guid GetUserGuidClaim()
        {
            return GetGuidClaimValue(ClaimTypes.NameIdentifier);
        }

        public static Guid GetUserGuidClaim(IClaimsIdentity claimsIdentity)
        {
            return GetGuidClaimValue(claimsIdentity, ClaimTypes.NameIdentifier);
        }

        private static string GetStringClaimValue(string claimType)
        {
            var claimValue = string.Empty;

            var claimsIdentity = Thread.CurrentPrincipal.Identity as IClaimsIdentity;
            if (claimsIdentity != null)
            {
                claimValue = claimsIdentity.GetClaimValue(claimType);
            }

            return claimValue;
        }

        private static string GetStringOptionalClaimValue(string claimType)
        {
            var claimValue = string.Empty;

            var claimsIdentity = Thread.CurrentPrincipal.Identity as IClaimsIdentity;
            if (claimsIdentity != null)
            {
                claimsIdentity.TryGetClaimValue(claimType, out claimValue);
            }

            return claimValue;
        }

        private static Guid GetGuidClaimValue(string claimType)
        {
            var claimValue = Guid.Empty;

            var claimsIdentity = Thread.CurrentPrincipal.Identity as IClaimsIdentity;
            if (claimsIdentity != null)
            {
                var claim = claimsIdentity.GetClaimValue(claimType);
                var validClaim = Guid.TryParse(claim, out claimValue);
                if (validClaim)
                    return claimValue;
            }

            return claimValue;
        }

        private static Guid GetGuidClaimValue(IClaimsIdentity claimsIdentity, string claimType)
        {
            var claimValue = Guid.Empty;

            if (claimsIdentity != null)
            {
                var claim = claimsIdentity.GetClaimValue(claimType);
                var validClaim = Guid.TryParse(claim, out claimValue);
                if (validClaim)
                    return claimValue;
            }

            return claimValue;
        }

        private static Guid? GetGuidOptionalClaimValue(string claimType)
        {
            var claimsIdentity = Thread.CurrentPrincipal.Identity as IClaimsIdentity;
            if (claimsIdentity != null)
            {
                string claim;
                var claimFound = claimsIdentity.TryGetClaimValue(claimType, out claim);
                if (claimFound)
                {
                    Guid claimValue;
                    var validClaim = Guid.TryParse(claim, out claimValue);
                    if (validClaim)
                        return claimValue;
                }
            }

            return null;
        }

        private static TimeZoneInfo GetTimeZoneInfoClaimValue(string claimType)
        {
            var claimValue = TimeZoneInfo.Local;

            var claimsIdentity = Thread.CurrentPrincipal.Identity as IClaimsIdentity;
            if (claimsIdentity != null)
            {
                var claim = claimsIdentity.GetClaimValue(claimType);
                try
                {
                    return TimeZoneInfo.FromSerializedString(claim);
                }
                catch
                {
                    return claimValue;
                }
            }

            return claimValue;
        }

        public static T GetUserFromPrincipal<T>(IPrincipal principal, T anonymousSitkaUser, Func<Guid, T> getUserByGuid) where T : IKeystoneUser
        {
            if (!principal.Identity.IsAuthenticated)
            {
                return anonymousSitkaUser;
            }

            // calls to the account provisioning service from keystone are authenticated calls, but not by forms auth tickets.  they come in with the user identity of the
            // application pool that keystone runs under and have an authentication type of "Kerberos". these particular invokations need to be treated the same way as the
            // unauthenticated calls over basic bindings - that is they do not map to a MM user and should be considered "anonymous".

            if (principal.Identity.IsAuthenticated && principal.Identity.AuthenticationType == "Kerberos")
            {
                return anonymousSitkaUser;
            }

            var userGuid = GetUserGuidClaim();
            var user = getUserByGuid(userGuid);

            if (user == null)
            {
                // should never see this... implies that we have an authenticated user where no entry exists in the db...yet SSO flow creates that entry
                // we'll force a signout which will delete the FedAuth cookie... but other RPs and Keystome will still consider the user as authenticated
                // if the user attempts to access a protected resource, they'll be sent thru the SSO flow again...and since they're still authenticated at tKeystone
                // we'll do a local sync again                
                Logger.ErrorFormat("Could not find authenticated user with UserGuid='{0}' in database - reverting to anonymous user", userGuid);
                var fam = FederatedAuthentication.WSFederationAuthenticationModule;
                fam.SignOut(false);
                user = anonymousSitkaUser;
            }

            // otherwise remap claims from principal
            var keystoneUserClaims = ParseClaims();
            user.SetKeystoneUserClaims(keystoneUserClaims);

            return user;
        }
    }
}
