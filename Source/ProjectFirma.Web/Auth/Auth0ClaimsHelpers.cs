using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Auth
{
    public class Auth0ClaimsHelpers
    {
        public static IAuth0UserClaims ParseOpenIDClaims(IIdentity userIdentity)
        {
            if (userIdentity == null)
                throw new NullReferenceException("Should have IIdentity");
            Auth0UserClaims openIdClaims = new Auth0UserClaims();
            if (!(userIdentity is ClaimsIdentity claimsIdentity))
                throw new Auth0ClaimNotFoundException("The IIdentity is not expected type ClaimsIdentity. Name: " + userIdentity.Name);
            
            Dictionary<string, string> dictionary = claimsIdentity.Claims
                .ToList<Claim>()
                .GroupBy<Claim, string>((Func<Claim, string>)(x => x.Type), 
                    (IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase)
                .ToDictionary<IGrouping<string, Claim>, string, string>((Func<IGrouping<string, Claim>, string>)(x => x.Key),
                    (Func<IGrouping<string, Claim>, string>)(x => x.First<Claim>().Value));

            openIdClaims.Subject = Auth0ClaimsHelpers.GetStringClaimValue((IReadOnlyDictionary<string, string>)dictionary, Auth0OpenIDClaimTypes.Subject);
            openIdClaims.UserGuid = Auth0ClaimsHelpers.GetGuidClaimValue((IReadOnlyDictionary<string, string>)dictionary, Auth0OpenIDClaimTypes.LegacyUserId);
            openIdClaims.DisplayName = Auth0ClaimsHelpers.GetStringClaimValue((IReadOnlyDictionary<string, string>)dictionary, Auth0OpenIDClaimTypes.Name);
            openIdClaims.LastName = Auth0ClaimsHelpers.GetStringClaimValue((IReadOnlyDictionary<string, string>)dictionary, Auth0OpenIDClaimTypes.FamilyName);
            openIdClaims.FirstName = Auth0ClaimsHelpers.GetStringClaimValue((IReadOnlyDictionary<string, string>)dictionary, Auth0OpenIDClaimTypes.GivenName);
            openIdClaims.Email = Auth0ClaimsHelpers.GetStringClaimValue((IReadOnlyDictionary<string, string>)dictionary, Auth0OpenIDClaimTypes.Email);
            openIdClaims.LoginName = Auth0ClaimsHelpers.GetStringOptionalClaimValue((IReadOnlyDictionary<string, string>)dictionary, Auth0OpenIDClaimTypes.LoginName);
            return (IAuth0UserClaims)openIdClaims;
        }

        private static void EnsureClaimTypeExists(
            IReadOnlyDictionary<string, string> claimsDictionary,
            string claimType)
        {
            if (!claimsDictionary.ContainsKey(claimType))
                throw new Auth0ClaimNotFoundException(claimType);
        }

        private static Guid GetGuidClaimValue(
            IReadOnlyDictionary<string, string> claimsDictionary,
            string claimType)
        {
            Auth0ClaimsHelpers.EnsureClaimTypeExists(claimsDictionary, claimType);
            Guid result;
            Guid.TryParse(claimsDictionary[claimType], out result);
            return result;
        }

        private static Guid? GetGuidOptionalClaimValue(
            IReadOnlyDictionary<string, string> claimsDictionary,
            string claimType)
        {
            Guid result;
            return claimsDictionary.ContainsKey(claimType) && Guid.TryParse(claimsDictionary[claimType], out result) ? new Guid?(result) : new Guid?();
        }

        private static string GetStringClaimValue(
            IReadOnlyDictionary<string, string> claimsDictionary,
            string claimType)
        {
            Auth0ClaimsHelpers.EnsureClaimTypeExists(claimsDictionary, claimType);
            return claimsDictionary[claimType];
        }

        private static string GetStringOptionalClaimValue(
            IReadOnlyDictionary<string, string> claimsDictionary,
            string claimType)
        {
            return !claimsDictionary.ContainsKey(claimType) ? (string)null : claimsDictionary[claimType];
        }

        private static TimeZoneInfo GetTimeZoneInfoClaimValue(
            IReadOnlyDictionary<string, string> claimsDictionary,
            string claimType)
        {
            TimeZoneInfo local = TimeZoneInfo.Local;
            if (!claimsDictionary.ContainsKey(claimType))
                return local;
            try
            {
                return TimeZoneInfo.FromSerializedString(claimsDictionary[claimType]);
            }
            catch
            {
                return local;
            }
        }

        public static T GetOpenIDUserFromPrincipal<T>(
            IPrincipal principal,
            T anonymousSitkaUser,
            Func<Guid, T> getUserByGuid)
            where T : IAuth0User
        {
            try
            {
                if (principal?.Identity == null || !principal.Identity.IsAuthenticated)
                    return anonymousSitkaUser;
                if (!(principal.Identity.AuthenticationType == "JWT"))
                {
                    if (!(principal.Identity.AuthenticationType == "Cookies"))
                        return anonymousSitkaUser;
                }
                IAuth0UserClaims openIdClaims = Auth0ClaimsHelpers.ParseOpenIDClaims(principal.Identity);
                T userFromPrincipal = getUserByGuid(openIdClaims.UserGuid);
                if ((object)userFromPrincipal == null)
                    return anonymousSitkaUser;
                userFromPrincipal.SetAuth0UserClaims(openIdClaims);
                return userFromPrincipal;
            }
            catch (NullReferenceException)
            {
                return anonymousSitkaUser;
            }
            catch (InvalidOperationException)
            {
                return anonymousSitkaUser;
            }
        }
    }
}