using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Web;
using log4net;

namespace Keystone.Common
{
    public class KeystoneClaimsHelpers
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(KeystoneClaimsHelpers));

        public static IKeystoneUserClaims ParseClaims(IIdentity userIdentity)
        {
            if (userIdentity == null)
            {
                throw new NullReferenceException($"Should have {nameof(IIdentity)}");
            }

            var keystoneUserClaims = new KeystoneUserClaims();
            if (userIdentity is ClaimsIdentity claimsIdentity)
            {
                var claimsDictionary = claimsIdentity.Claims.ToList().GroupBy(x => x.ClaimType, StringComparer.InvariantCultureIgnoreCase).ToDictionary(x => x.Key, x => x.First().Value);
                // core claims always supplied
                keystoneUserClaims.UserGuid = GetGuidClaimValue(claimsDictionary, ClaimTypes.NameIdentifier);
                keystoneUserClaims.DisplayName = GetStringClaimValue(claimsDictionary, ClaimTypes.Name);
                keystoneUserClaims.LastName = GetStringClaimValue(claimsDictionary, ClaimTypes.Surname);
                keystoneUserClaims.FirstName = GetStringClaimValue(claimsDictionary, ClaimTypes.GivenName);
                keystoneUserClaims.Email = GetStringClaimValue(claimsDictionary, ClaimTypes.Email);
                // optional claims may or may not be supplied
                keystoneUserClaims.LoginName = GetStringOptionalClaimValue(claimsDictionary, KeystoneClaimTypes.LoginName);
                keystoneUserClaims.OrganizationGuid = GetGuidOptionalClaimValue(claimsDictionary, KeystoneClaimTypes.OrganizationIdentifier);
                keystoneUserClaims.OrganizationName = GetStringOptionalClaimValue(claimsDictionary, KeystoneClaimTypes.OrganizationName);
                keystoneUserClaims.OrganizationShortName = GetStringOptionalClaimValue(claimsDictionary, KeystoneClaimTypes.OrganizationShortName);
                keystoneUserClaims.Address1 = GetStringOptionalClaimValue(claimsDictionary, ClaimTypes.StreetAddress);
                keystoneUserClaims.City = GetStringOptionalClaimValue(claimsDictionary, ClaimTypes.Locality);
                keystoneUserClaims.StateName = GetStringOptionalClaimValue(claimsDictionary, ClaimTypes.StateOrProvince);
                keystoneUserClaims.PostalCode = GetStringOptionalClaimValue(claimsDictionary, ClaimTypes.PostalCode);
                keystoneUserClaims.CountryName = GetStringOptionalClaimValue(claimsDictionary, ClaimTypes.Country);
                keystoneUserClaims.PrimaryPhone = GetStringOptionalClaimValue(claimsDictionary, ClaimTypes.OtherPhone);
                keystoneUserClaims.PersonalURL = GetStringOptionalClaimValue(claimsDictionary, ClaimTypes.Webpage);
                keystoneUserClaims.TimeZoneInfo = GetTimeZoneInfoClaimValue(claimsDictionary, KeystoneClaimTypes.TimeZone);
                keystoneUserClaims.TimeZoneIana = GetStringOptionalClaimValue(claimsDictionary, KeystoneClaimTypes.TimeZoneIana);
            }
            else
            {
                throw new KeystoneClaimNotFoundException($"The {nameof(IIdentity)} is not expected type {nameof(ClaimsIdentity)}. {nameof(IIdentity.Name)}: {userIdentity.Name}");
            }

            return keystoneUserClaims;
        }

        private static void EnsureClaimTypeExists(System.Collections.Generic.IReadOnlyDictionary<string, string> claimsDictionary, string claimType)
        {
            if (!claimsDictionary.ContainsKey(claimType))
            {
                throw new KeystoneClaimNotFoundException(claimType);
            }
        }

        private static Guid GetGuidClaimValue(IReadOnlyDictionary<string, string> claimsDictionary, string claimType)
        {
            EnsureClaimTypeExists(claimsDictionary, claimType);
            Guid.TryParse(claimsDictionary[claimType], out var claimValue);
            return claimValue;
        }

        private static Guid? GetGuidOptionalClaimValue(IReadOnlyDictionary<string, string> claimsDictionary, string claimType)
        {
            if (claimsDictionary.ContainsKey(claimType) && Guid.TryParse(claimsDictionary[claimType], out var claimValue))
            {
                return claimValue;
            }
            return null;
        }

        private static string GetStringClaimValue(IReadOnlyDictionary<string, string> claimsDictionary, string claimType)
        {
            EnsureClaimTypeExists(claimsDictionary, claimType);
            return claimsDictionary[claimType];
        }

        private static string GetStringOptionalClaimValue(IReadOnlyDictionary<string, string> claimsDictionary, string claimType)
        {
            return claimsDictionary.ContainsKey(claimType) ? claimsDictionary[claimType] : null;
        }

        private static TimeZoneInfo GetTimeZoneInfoClaimValue(IReadOnlyDictionary<string, string> claimsDictionary, string claimType)
        {
            var claimValue = TimeZoneInfo.Local;
            if (claimsDictionary.ContainsKey(claimType))
            {
                try
                {
                    return TimeZoneInfo.FromSerializedString(claimsDictionary[claimType]);
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

            var keystoneUserClaims = ParseClaims(principal.Identity);
            var user = getUserByGuid(keystoneUserClaims.UserGuid);

            if (user == null)
            {
                // should never see this... implies that we have an authenticated user where no entry exists in the db...yet SSO flow creates that entry
                // we'll force a signout which will delete the FedAuth cookie... but other RPs and Keystome will still consider the user as authenticated
                // if the user attempts to access a protected resource, they'll be sent thru the SSO flow again...and since they're still authenticated at tKeystone
                // we'll do a local sync again                
                Logger.ErrorFormat("Could not find authenticated user with UserGuid='{0}' in database - reverting to anonymous user", keystoneUserClaims.UserGuid);
                var fam = FederatedAuthentication.WSFederationAuthenticationModule;
                fam.SignOut(false);
                user = anonymousSitkaUser;
            }

            // otherwise remap claims from principal
            user.SetKeystoneUserClaims(keystoneUserClaims);

            return user;
        }
    }
}
