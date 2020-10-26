using System;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TenantSimple
    {
        public int TenantID;
        public string TenantName;
        public string CanonicalUrlLocal;
        public string CanonicalHostNameQa;
        public string CanonicalHostNameProd;
        public string TenantSquareLogoUrl;
        public bool ShowTenantInSwitcherDropdown;

        public TenantSimple(int tenantID, string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, string tenantSquareLogoUrl, bool showTenantInSwitcherDropdown)
        {
            TenantID = tenantID;
            TenantName = tenantName;
            CanonicalUrlLocal = new UriBuilder() { Scheme = "https", Host = canonicalHostNameLocal }.ToString();
            CanonicalHostNameQa = new UriBuilder() { Scheme = "https", Host = canonicalHostNameQa }.ToString();
            CanonicalHostNameProd = new UriBuilder() { Scheme = "https", Host = canonicalHostNameProd }.ToString();
            TenantSquareLogoUrl = tenantSquareLogoUrl;
            ShowTenantInSwitcherDropdown = showTenantInSwitcherDropdown;
        }
        
        public string GetTenantSquareLogoUrlForEnvironment(FirmaEnvironmentType environmentType)
        {
            switch (environmentType)
            {
                case FirmaEnvironmentType.Local:
                    return new UriBuilder(CanonicalUrlLocal) { Path = TenantSquareLogoUrl }.ToString();
                case FirmaEnvironmentType.Qa:
                    return new UriBuilder(CanonicalHostNameQa) { Path = TenantSquareLogoUrl }.ToString();
                case FirmaEnvironmentType.Prod:
                    return new UriBuilder(CanonicalHostNameProd) { Path = TenantSquareLogoUrl }.ToString();
                default:
                    throw new ArgumentOutOfRangeException(nameof(environmentType), environmentType, null);
            }
        }

        public UriBuilder GetCanonicalUrlUriBuilderForCurrentEnvironment()
        {
            var environment = FirmaWebConfiguration.FirmaEnvironment.FirmaEnvironmentType;
            string canonicalUrl;
            switch (environment)
            {
                case FirmaEnvironmentType.Local:
                    canonicalUrl = CanonicalUrlLocal;
                    break;
                case FirmaEnvironmentType.Qa:
                    canonicalUrl = CanonicalHostNameQa;
                    break;
                case FirmaEnvironmentType.Prod:
                    canonicalUrl = CanonicalHostNameProd;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(environment), environment, null);
            }

            // setting port to -1 will exclude it from the UriBuilder ToString() method. No one likes to see :443 in their links.
            return new UriBuilder(canonicalUrl) { Port = -1 };
        }

        public string GetRelativeCanonicalUrlForTenantEnvironment(FirmaEnvironmentType environmentType, Uri currentUrl)
        {
            string canonicalUrl;
            switch (environmentType)
            {
                case FirmaEnvironmentType.Local:
                    canonicalUrl = CanonicalUrlLocal;
                    break;
                case FirmaEnvironmentType.Qa:
                    canonicalUrl = CanonicalHostNameQa;
                    break;
                case FirmaEnvironmentType.Prod:
                    canonicalUrl = CanonicalHostNameProd;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(environmentType), environmentType, null);
            }
            return new UriBuilder(canonicalUrl) { Path = currentUrl.PathAndQuery}.ToString();
        }
    }
}