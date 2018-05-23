using System;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Routing;
using log4net;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Protocols.WSFederation;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Web;

namespace Keystone.Common
{
    public static class KeystoneUtilities
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof(KeystoneUtilities));

        public static string LogOnActionResult(HttpRequest httpRequest, string homeUrl, Func<IKeystoneUserClaims, IKeystoneUser> syncLocalAccountStore)
        {
            Logger.DebugFormat("FAM about to parse SignIn response");

            // use FAM to parse payload & redirect to originally requested URL
            var fam = FederatedAuthentication.WSFederationAuthenticationModule;
            if (fam.CanReadSignInResponse(httpRequest, true))
            {
                var response = fam.GetSignInResponseMessage(httpRequest);

                Logger.DebugFormat("FAM successfully parsed SignIn response");
                try
                {
                    ClaimHandler(syncLocalAccountStore);

                    return response.Context;
                }
                catch (KeystoneClaimNotFoundException ex)
                {
                    Logger.InfoFormat("FAM was able to parse the SignIn reponse but expected claim '{0}' was not found - redirecting to '{1}'", ex.Message, homeUrl);
                    return homeUrl;
                }
            }

            Logger.DebugFormat("FAM could not parse SignIn reponse - redirecting to '{0}'", homeUrl);
            return homeUrl;
        }

        public static void ClaimHandler(Func<IKeystoneUserClaims, IKeystoneUser> syncLocalAccountStore)
        {
            Logger.DebugFormat("Before call to ParseClaims");
            var keystoneUser = KeystoneClaimsHelpers.ParseClaims();
            Logger.DebugFormat("After call to ParseClaims");

            Logger.DebugFormat("Before call to SyncLocalAccountStore");
            var localUserAccount = syncLocalAccountStore(keystoneUser);
            Logger.DebugFormat("After call to SyncLocalAccountStore");

            Logger.DebugFormat("Before mapping of Roles to claims");
            AddLocalUserAccountRolesToClaims(localUserAccount);
            Logger.DebugFormat("After mapping of Roles to claims");
        }
        
        // add local RP-specific roles to the list of claims
        public static void AddLocalUserAccountRolesToClaims(IKeystoneUser user)
        {
            var claimsIdentity = Thread.CurrentPrincipal.Identity as IClaimsIdentity;
            if (claimsIdentity != null)
            {
                user.RoleNames.ToList().ForEach(role => claimsIdentity.Claims.Add(new Claim(ClaimTypes.Role, role)));
            }
        }

        public static string LogOffActionResult(HttpRequest httpRequest, IIdentity identity, string homeUrl)
        {
            var realm = httpRequest.Url.Host;
            var scheme = httpRequest.Url.Scheme;
            var siteAddress = String.Format("{0}://{1}", scheme, realm);

            return LogOffActionResultImpl(identity, homeUrl, siteAddress);
        }

        private static string LogOffActionResultImpl(IIdentity identity, string homeUrl, string siteAddress)
        {
            if (identity.IsAuthenticated)
            {
                Logger.DebugFormat("FAM about to initiate SignOut");
                // use FAM to sign out of the IdP (& other RPs)
                var fam = FederatedAuthentication.WSFederationAuthenticationModule;
                fam.SignOut(false);

                var signOut = new SignOutRequestMessage(new Uri(fam.Issuer), siteAddress);
                Logger.DebugFormat("FAM redirecting to STS to process SignOut");
                return signOut.WriteQueryString();
            }

            return homeUrl;
        }

        public static string LogOffActionResultWithReturnUrl(HttpRequest httpRequest, IIdentity identity, string homeUrl, string returnUrl)
        {
            return LogOffActionResultImpl(identity, homeUrl, returnUrl);
        }


        public static string GetSignInRedirectUrl(RequestContext requestContext, string logOnUrlRelative = null)
        {
            var returnUrl = GetReturnUrl(requestContext);
            return GetSignInRedirectUrlImpl(requestContext, logOnUrlRelative, returnUrl.ToString());
        }

        private static string GetSignInRedirectUrlImpl(RequestContext requestContext, string logOnUrlRelative, string returnUrl)
        {
            Logger.DebugFormat("FAM starting SignIn request to STS - returnUrl='{0}'", returnUrl);

            var fam = FederatedAuthentication.WSFederationAuthenticationModule;

            var realm = requestContext.HttpContext.Request.Url.Host;
            var scheme = requestContext.HttpContext.Request.Url.Scheme;
            var siteAddress = String.Format("{0}://{1}", scheme, realm);

            var loginUrlAbsolute = String.IsNullOrWhiteSpace(logOnUrlRelative) ? fam.Reply : String.Format("{0}{1}", siteAddress, logOnUrlRelative);

            var signIn = new SignInRequestMessage(new Uri(fam.Issuer), siteAddress) {Context = returnUrl.ToString(), HomeRealm = fam.HomeRealm, Reply = loginUrlAbsolute};

            var writeQueryString = signIn.WriteQueryString();
            return writeQueryString;
        }

        public static string GetSignInRedirectUrlWithReturnUrl(RequestContext requestContext, string returnUrl)
        {
            return GetSignInRedirectUrlImpl(requestContext, null, returnUrl);
        }

        public static string GetSignInRedirectUrlWithReturnUrl(RequestContext requestContext, string logOnUrlRelative, string returnUrl)
        {
            return GetSignInRedirectUrlImpl(requestContext, logOnUrlRelative, returnUrl);
        }

        private static Uri GetReturnUrl(RequestContext context, string logOnUrlRelative = null)
        {
            var request = context.HttpContext.Request;
            var reqUrl = request.Url;
            var rawUrl = request.RawUrl;

            var loginURL = String.IsNullOrWhiteSpace(logOnUrlRelative)
                               ? "/Account/LogOn"
                               : logOnUrlRelative;

            if (String.Equals(rawUrl,loginURL, StringComparison.InvariantCultureIgnoreCase) && request.UrlReferrer != null && request.Url.Host == request.UrlReferrer.Host) // No RP specific Context here, have to hardcode string instead of use SitkaRoute or EMRoute or whatever.
            {
                // this is only done if you're referred to from this host. otherwise it'll put you back on the homepage.
                rawUrl = request.UrlReferrer.LocalPath;
            }

            var wreply = new StringBuilder();

            wreply.Append(reqUrl.Scheme);
            wreply.Append("://");
            wreply.Append(request.Headers["Host"] ?? reqUrl.Authority);
            wreply.Append(rawUrl);

            if (!request.ApplicationPath.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                wreply.Append("/");
            }

            return new Uri(wreply.ToString());
        }

        /// <summary>
        /// Pre flight check the Auth cookie before <see cref="HttpApplication.AuthenticateRequest"/> to avoid errors like this at runtime.
        /// 
        /// Blank cookies can get this error:
        ///      System.Xml.XmlException: Unexpected end of file.
        ///     at System.Xml.EncodingStreamWrapper.ProcessBuffer(Byte[] buffer, Int32 offset, Int32 count, Encoding encoding)
        ///     at System.Xml.XmlUTF8TextReader.SetInput(Byte[] buffer, Int32 offset, Int32 count, Encoding encoding, XmlDictionaryReaderQuotas quotas, OnXmlDictionaryReaderClose onClose)
        ///     at System.Xml.XmlDictionaryReader.CreateTextReader(Byte[] buffer, Int32 offset, Int32 count, Encoding encoding, XmlDictionaryReaderQuotas quotas, OnXmlDictionaryReaderClose onClose)
        ///     at System.Xml.XmlDictionaryReader.CreateTextReader(Byte[] buffer, Int32 offset, Int32 count, XmlDictionaryReaderQuotas quotas)
        ///     at Microsoft.IdentityModel.Web.SessionAuthenticationModule.GetKeyId(Byte[] sessionCookie)
        ///     at Microsoft.IdentityModel.Web.SessionAuthenticationModule.ReadSessionTokenFromCookie(Byte[] sessionCookie)
        ///     at Microsoft.IdentityModel.Web.SessionAuthenticationModule.TryReadSessionTokenFromCookie(SessionSecurityToken& sessionToken)
        ///     at Microsoft.IdentityModel.Web.SessionAuthenticationModule.OnAuthenticateRequest(Object sender, EventArgs eventArgs)
        /// 
        /// Malformed cookies can get this error:
        ///  2016-05-09 09:58:48,648;18;ERROR;LtInfo.Common.SitkaLogger;Unhandled Exception: 
        ///   System.FormatException: The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters. 
        ///   at System.Convert.FromBase64_Decode(Char* startInputPtr, Int32 inputLength, Byte* startDestPtr, Int32 destLength)
        ///   at System.Convert.FromBase64CharPtr(Char* inputPtr, Int32 inputLength)
        ///   at System.Convert.FromBase64String(String s)
        ///   at Microsoft.IdentityModel.Web.ChunkedCookieHandler.ReadInternal(String name, HttpCookieCollection requestCookies)
        ///   at Microsoft.IdentityModel.Web.SessionAuthenticationModule.TryReadSessionTokenFromCookie(SessionSecurityToken& sessionToken)
        ///   at Microsoft.IdentityModel.Web.SessionAuthenticationModule.OnAuthenticateRequest(Object sender, EventArgs eventArgs)
        ///   at System.Web.HttpApplication.SyncEventExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
        ///   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)
        /// </summary>
        private static bool CanParseFedAuthCookie(out Exception cookieParsingExceptionIfAny)
        {
            cookieParsingExceptionIfAny = null;
            bool canParseAuthCookie;
            try
            {
                SessionSecurityToken sst;
                canParseAuthCookie = FederatedAuthentication.SessionAuthenticationModule.TryReadSessionTokenFromCookie(out sst);
            }
            catch(Exception ex)
            {
                cookieParsingExceptionIfAny = ex;
                canParseAuthCookie = false;
            }
            return canParseAuthCookie;
        }

        /// <summary>
        /// When the Microsoft Identity FedAuth cookies get into a weird state, i.e blank or not valid Base64 string, this will force remove them
        /// making the user just appear to be logged out.  We are not sure why this happens, but we have had some support cases with blank cookies
        /// and other ones with corrupt cookies. This gives a smoother user experience of just treating the person as logged out and letting user
        /// self-recover versus clearing cookies (by either close and reopen browser to clear cookies in browser).
        /// 
        /// Call this on <see cref="HttpApplication.BeginRequest"/> to pre-flight in time before <see cref="HttpApplication.AuthenticateRequest"/> fires off.
        /// </summary>
        public static void SignOutOnBadCookie(HttpRequest httpRequest, HttpResponse httpResponse)
        {
            var identityCookiePrefix = FederatedAuthentication.SessionAuthenticationModule.CookieHandler.Name;
            var microsoftIdentityCookies = httpRequest.Cookies.AllKeys.Where(x => x.StartsWith(identityCookiePrefix)).ToList();
            if (!microsoftIdentityCookies.Any())
            {
                // no cookies for sign on present, so user can't be in corrupted state - exit early because TryReadSessionTokenFromCookie will fail on missing cookies as well as corrupt cookies
                return;
            }

            Exception cookieParsingExceptionIfAny;
            if (!CanParseFedAuthCookie(out cookieParsingExceptionIfAny))
            {
                // Log full details about what happened in case we discover we've covered up some kind of bad issue
                var cookieDiagnosticInformation = string.Join("\r\n",
                    microsoftIdentityCookies.Select(x => httpRequest.Cookies[x])
                        .Select(x => string.Format("{0}={1}", x.Name, x.Value)));

                var warningMessage = string.Format("FAM about to initiate SignOut due to corrupt {0} cookie(s) while processing url {1}\r\nCookies:\r\n{2}", identityCookiePrefix, httpRequest.Url, cookieDiagnosticInformation);
                if (cookieParsingExceptionIfAny != null)
                {
                    Logger.Warn(warningMessage, cookieParsingExceptionIfAny);
                }
                else
                {
                    Logger.Warn(warningMessage);
                }
                
                // Signed out so user would be prompted to re-login/authenticate as needed, this will remove the HttpResponse cookies
                FederatedAuthentication.WSFederationAuthenticationModule.SignOut(false);

                // Remove the cookie explicitly from HttpRequest so when HttpApplication.AuthenticateRequest fires off later in *this* request cycle these cookies are gone and user is signed out
                microsoftIdentityCookies.ForEach(x => httpRequest.Cookies.Remove(x));
            }
        }
    }
}