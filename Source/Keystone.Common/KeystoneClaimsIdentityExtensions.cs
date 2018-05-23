using Microsoft.IdentityModel.Claims;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Keystone.Common
{
    public static class KeystoneClaimsIdentityExtensions
    {
        /// <summary>
        /// Finds all instances of the specified claim.
        /// </summary>
        /// <param name="identity">The identity.</param><param name="predicate">The search predicate.</param>
        /// <returns>
        /// List of claims that match the search criteria
        /// </returns>
        public static IEnumerable<Claim> FindClaims(this IClaimsIdentity identity, Predicate<Claim> predicate)
        {
            return identity.Claims.Where(claim => predicate(claim));
        }

        /// <summary>
        /// Finds all instances of the specified claim.
        /// </summary>
        /// <param name="identity">The identity.</param><param name="claimType">Type of the claim.</param>
        /// <returns>
        /// List of claims that match the search criteria
        /// </returns>
        public static IEnumerable<Claim> FindClaims(this IClaimsIdentity identity, string claimType)
        {
            return FindClaims(identity, c => c.ClaimType.Equals(claimType, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Finds all instances of the specified claim.
        /// </summary>
        /// <param name="identity">The identity.</param><param name="claimType">Type of the claim.</param><param name="issuer">The issuer.</param>
        /// <returns>
        /// List of claims that match the search criteria
        /// </returns>
        public static IEnumerable<Claim> FindClaims(this IClaimsIdentity identity, string claimType, string issuer)
        {
            return FindClaims(identity, c => c.ClaimType.Equals(claimType, StringComparison.OrdinalIgnoreCase) && c.Issuer.Equals(issuer, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Finds all instances of the specified claim.
        /// </summary>
        /// <param name="identity">The identity.</param><param name="claimType">Type of the claim.</param><param name="issuer">The issuer.</param><param name="value">The value.</param>
        /// <returns>
        /// List of claims that match the search criteria
        /// </returns>
        public static IEnumerable<Claim> FindClaims(this IClaimsIdentity identity, string claimType, string issuer, string value)
        {
            return FindClaims(identity, c => c.ClaimType.Equals(claimType, StringComparison.OrdinalIgnoreCase) && c.Value.Equals(value, StringComparison.OrdinalIgnoreCase) && c.Issuer.Equals(issuer, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Finds all instances of the specified claim.
        /// </summary>
        /// <param name="identity">The identity.</param><param name="claim">Search claim.</param>
        /// <returns>
        /// List of claims that match the search criteria
        /// </returns>
        public static IEnumerable<Claim> FindClaims(this IClaimsIdentity identity, Claim claim)
        {
            return FindClaims(identity, c => c.ClaimType.Equals(claim.ClaimType, StringComparison.OrdinalIgnoreCase) && c.Value.Equals(claim.Value, StringComparison.OrdinalIgnoreCase) && c.Issuer.Equals(claim.Issuer, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Retrieves the issuer name of an IClaimsIdentity. The algorithm checks the name claim first, and if no name is found, the first claim.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <returns>
        /// The issuer name
        /// </returns>
        public static string GetIssuerName(this IClaimsIdentity identity)
        {
            var claim1 = FindClaims(identity, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").FirstOrDefault();
            if (claim1 != null && claim1.Issuer != null)
                return claim1.Issuer;

            if (identity.Claims.Count > 0)
            {
                var claim2 = identity.Claims[0];
                if (claim2 != null && claim2.Issuer != null)
                    return claim2.Issuer;
            }

            return string.Empty;
        }

        /// <summary>
        /// Checks whether a given claim exists
        /// </summary>
        /// <param name="identity">The identity.</param><param name="predicate">The search predicate.</param>
        /// <returns>
        /// true/false
        /// </returns>
        public static bool ClaimExists(this IClaimsIdentity identity, Predicate<Claim> predicate)
        {
            return FindClaims(identity, predicate).FirstOrDefault() != null;
        }

        /// <summary>
        /// Checks whether a given claim exists
        /// </summary>
        /// <param name="identity">The identity.</param><param name="claimType">Type of the claim.</param>
        /// <returns>
        /// true/false
        /// </returns>
        public static bool ClaimExists(this IClaimsIdentity identity, string claimType)
        {
            return ClaimExists(identity, c => c.ClaimType.Equals(claimType, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Checks whether a given claim exists
        /// </summary>
        /// <param name="identity">The identity.</param><param name="claimType">Type of the claim.</param><param name="value">The value.</param>
        /// <returns>
        /// true/false
        /// </returns>
        public static bool ClaimExists(this IClaimsIdentity identity, string claimType, string value)
        {
            return ClaimExists(identity, c => c.ClaimType.Equals(claimType, StringComparison.OrdinalIgnoreCase) && c.Value.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Checks whether a given claim exists
        /// </summary>
        /// <param name="identity">The identity.</param><param name="claimType">Type of the claim.</param><param name="value">The value.</param><param name="issuer">The issuer.</param>
        /// <returns>
        /// true/false
        /// </returns>
        public static bool ClaimExists(this IClaimsIdentity identity, string claimType, string value, string issuer)
        {
            return ClaimExists(identity, c => c.ClaimType.Equals(claimType, StringComparison.OrdinalIgnoreCase) && c.Value.Equals(value, StringComparison.OrdinalIgnoreCase) && c.Issuer.Equals(issuer, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Retrieves the value of a claim.
        /// </summary>
        /// <param name="identity">The identity.</param><param name="claimType">Type of the claim.</param>
        /// <returns>
        /// The value
        /// </returns>
        public static string GetClaimValue(this IClaimsIdentity identity, string claimType)
        {
            string claimValue;
            if (TryGetClaimValue(identity, claimType, out claimValue))
                return claimValue;
            
            throw new KeystoneClaimNotFoundException(claimType);
        }

        /// <summary>
        /// Retrieves the value of a claim.
        /// </summary>
        /// <param name="identity">The identity.</param><param name="claimType">Type of the claim.</param><param name="issuer">The issuer.</param>
        /// <returns>
        /// The value
        /// </returns>
        public static string GetClaimValue(this IClaimsIdentity identity, string claimType, string issuer)
        {
            string claimValue;
            if (TryGetClaimValue(identity, claimType, issuer, out claimValue))
                return claimValue;

            throw new KeystoneClaimNotFoundException(claimType);
        }

        /// <summary>
        /// Tries to retrieve the value of a claim.
        /// </summary>
        /// <param name="identity">The identity.</param><param name="claimType">Type of the claim.</param><param name="claimValue">The claim value.</param>
        /// <returns>
        /// The value
        /// </returns>
        public static bool TryGetClaimValue(this IClaimsIdentity identity, string claimType, out string claimValue)
        {
            claimValue = null;
            
            var claim = FindClaims(identity, claimType).FirstOrDefault();
            if (claim == null)
                return false;

            claimValue = claim.Value;
            
            return true;
        }

        /// <summary>
        /// Tries to retrieve the value of a claim.
        /// </summary>
        /// <param name="identity">The identity.</param><param name="claimType">Type of the claim.</param><param name="issuer">The issuer.</param><param name="claimValue">The claim value.</param>
        /// <returns>
        /// The value
        /// </returns>
        public static bool TryGetClaimValue(this IClaimsIdentity identity, string claimType, string issuer, out string claimValue)
        {
            claimValue = null;

            var claim = FindClaims(identity, claimType, issuer).FirstOrDefault();
            if (claim == null)
                return false;
            
            claimValue = claim.Value;
            
            return true;
        }
    }
}
