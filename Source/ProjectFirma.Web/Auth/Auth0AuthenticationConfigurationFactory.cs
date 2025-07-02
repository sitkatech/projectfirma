using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace ProjectFirma.Web.Auth
{
    using Microsoft.Owin.Security;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;

    //public class AllowAllCertificatesValidator : ICertificateValidator
    //{
    //    public bool Validate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    //    {
    //        return true; // ⚠️ Never use this in production!
    //    }
    //}

    //public class ThumbprintValidator : ICertificateValidator
    //{
    //    private readonly string _trustedThumbprint = "ABC123...";

    //    public bool Validate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    //    {
    //        return certificate != null && certificate.GetCertHashString().Equals(_trustedThumbprint, StringComparison.OrdinalIgnoreCase);
    //    }
    //}

    public class Auth0AuthenticationConfigurationFactory
    {
        public CookieAuthenticationOptions CreateAuth0CookieAuthenticationOptions()
        {
            return new CookieAuthenticationOptions
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                LoginPath = new PathString("/LogOn"),

                // Configure SameSite as needed for your app. Lax works well for most scenarios here but
                // you may want to set SameSiteMode.None for HTTPS
                CookieSameSite = SameSiteMode.Lax,

                // More information on why the CookieManager needs to be set can be found here: 
                // https://github.com/aspnet/AspNetKatana/wiki/System.Web-response-cookie-integration-issues
                CookieManager = new SameSiteCookieManager(new SystemWebCookieManager())
            };
        }

        public OpenIdConnectAuthenticationOptions CreateAuth0OpenIdConnectAuthenticationOptions()
        {
            // Configure Auth0 parameters
            string auth0Domain = ConfigurationManager.AppSettings["auth0:Domain"];
            string auth0ClientId = ConfigurationManager.AppSettings["auth0:ClientId"];
            string auth0RedirectUri = ConfigurationManager.AppSettings["auth0:RedirectUri"];
            string auth0PostLogoutRedirectUri = ConfigurationManager.AppSettings["auth0:PostLogoutRedirectUri"];

            return new OpenIdConnectAuthenticationOptions
            {

                AuthenticationType = "Auth0",
                Authority = $"https://{auth0Domain}",
                ClientId = auth0ClientId,
                RedirectUri = auth0RedirectUri,
                PostLogoutRedirectUri = auth0PostLogoutRedirectUri,
                Scope = "openid profile email",
                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name"
                },

                // More information on why the CookieManager needs to be set can be found here: 
                // https://docs.microsoft.com/en-us/aspnet/samesite/owin-samesite
                CookieManager = new SameSiteCookieManager(new SystemWebCookieManager()),
                //BackchannelCertificateValidator = new AllowAllCertificatesValidator(),
                // Configure Auth0's Logout URL by hooking into the RedirectToIdentityProvider notification, 
                // which is getting triggered before any redirect to Auth0 happens.
                Notifications = CreateAuth0OpenIdConnectAuthenticationNotifications(auth0Domain, auth0ClientId)
            };
        }

        private OpenIdConnectAuthenticationNotifications CreateAuth0OpenIdConnectAuthenticationNotifications(string auth0Domain, string auth0ClientId)
        {
            return new OpenIdConnectAuthenticationNotifications
            {
                RedirectToIdentityProvider = notification =>
                {
                    // Only when the RequestType is OpenIdConnectRequestType.Logout should we configure the logout URL.
                    // Any other RequestType means a different kind of interaction with Auth0 that isn't logging out.
                    if (notification.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
                    {
                        var logoutUri = $"https://{auth0Domain}/v2/logout?client_id={auth0ClientId}";

                        var postLogoutUri = notification.ProtocolMessage.PostLogoutRedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
                                // transform to absolute
                                var request = notification.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase +
                                                postLogoutUri;
                            }

                            logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
                        }

                        notification.Response.Redirect(logoutUri);
                        notification.HandleResponse();
                    }

                    return Task.FromResult(0);
                }
            };
        }
    }
}