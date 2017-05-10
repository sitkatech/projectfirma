using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Keystone.Common
{
    /// <summary>
    /// Helper to find certificates in key store
    /// NOTE: this class is duplicated in NAnt custom tasks and in Keystone
    /// </summary>
    public static class CertificateHelper
    {
        private static readonly Regex CnRegex = new Regex(@"^\s*CN\s*=");

        public static X509Certificate2 GetCertificateBySimpleName(StoreName storeName, StoreLocation storeLocation, string simpleName)
        {
            if (CnRegex.IsMatch(simpleName))
                throw new Exception(string.Format("You put \"{0}\" for the simple name; omit the CN= -- give just the simple name, not a full subject.", simpleName));

            var store = new X509Store(storeName, storeLocation);
            X509Certificate2Collection certificates = null;
            store.Open(OpenFlags.ReadOnly);
            try
            {
                certificates = store.Certificates;

                var matchingCerts = certificates.Cast<X509Certificate2>().Where(cert => String.Equals(cert.GetNameInfo(X509NameType.SimpleName, false), simpleName, StringComparison.InvariantCultureIgnoreCase)).ToList();
                if (!matchingCerts.Any())
                {
                    throw new ApplicationException(string.Format("No certificate was found for simple name \"{0}\"", simpleName));
                }
                if (matchingCerts.Count > 1)
                {
                    throw new ApplicationException(string.Format("There are multiple certificates for simple name \"{0}\"", simpleName));
                }

                // Important - make a *copy* of the certificate so that when we clean up and close the store the properties are still accessible
                var result = new X509Certificate2(matchingCerts.Single());
                return result;
            }
            finally
            {
                if (certificates != null)
                {
                    foreach (var cert in certificates)
                    {
                        cert.Reset();
                    }
                }
                store.Close();
            }
        }
    }
}
