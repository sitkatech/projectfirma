using System;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TenantSimple
    {
        public string TenantName;
        public string CanonicalUrlLocal;
        public string CanonicalHostNameQa;
        public string CanonicalHostNameProd;
        public string TenantSquareLogoUrl;

        public TenantSimple(string tenantName, string canonicalHostNameLocal, string canonicalHostNameQa, string canonicalHostNameProd, string tenantSquareLogoUrl)
        {
            TenantName = tenantName;
            CanonicalUrlLocal = new UriBuilder() { Scheme = "https", Host = canonicalHostNameLocal }.ToString();
            CanonicalHostNameQa = new UriBuilder() { Scheme = "https", Host = canonicalHostNameQa }.ToString();
            CanonicalHostNameProd = new UriBuilder() { Scheme = "https", Host = canonicalHostNameProd }.ToString();
            TenantSquareLogoUrl = tenantSquareLogoUrl;
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

        public string GetCanonicalUrlForTenantEnvironment(FirmaEnvironmentType environmentType)
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
            return canonicalUrl;
        }
    }
}