using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using LtInfo.Common;
using ProjectFirmaModels.Models;


namespace ProjectFirma.Web.Session
{
    public static class TaurusHttpContextHelper
    {
        // WARNING WARNING - Must be moved to config! Should be changed when you do this if this has ever been committed to public repo!!!

        /// <summary>
        /// This string just needs to be the same for <see cref="MachineKey.Protect"/> and <see cref="MachineKey.Unprotect"/>
        /// </summary>
        private const string EncryptionPurposeString = "mykey";

        /*
        public static void SetSessionCookieTaurusSessionGuid(Guid taurusSessionGuid, HttpCookieCollection httpCookieCollection)
        {
            var sessionGuidEncrypted = MachineKey.Protect(taurusSessionGuid.ToByteArray(), EncryptionPurposeString);
            var sessionGuidEncryptedAsHex = BitConverter.ToString(sessionGuidEncrypted).Replace("-", String.Empty);
            var httpCookie = new HttpCookie(TaurusWebSession.TaurusSessionCookieName, sessionGuidEncryptedAsHex) { HttpOnly = true, Secure = true, SameSite = SameSiteMode.Lax };
            httpCookieCollection.Set(httpCookie);
        }
        */

        public static Guid ParseSessionCookie(HttpCookie httpCookie)
        {
            var sessionGuidEncryptedAsByteArray = GeneralUtility.HexStringToBytes(httpCookie.Value);
            var sessionGuidUnencrypted = MachineKey.Unprotect(sessionGuidEncryptedAsByteArray, EncryptionPurposeString);
            return new Guid(sessionGuidUnencrypted);
        }

        public static bool IsSessionCookiePresentAndValid(Tenant currentTenant, HttpCookieCollection httpCookieCollection)
        {
            var tenantizedFirmaWebSessionCookieName = FirmaWebSession.GetTenantizedFirmaSessionCookieName(currentTenant);
            var httpCookie = httpCookieCollection[tenantizedFirmaWebSessionCookieName];
            var sessionCookieExists = (httpCookie != null);
            if (!sessionCookieExists)
            {
                return false;
            }
            try
            {
                ParseSessionCookie(httpCookie);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        
    }
}