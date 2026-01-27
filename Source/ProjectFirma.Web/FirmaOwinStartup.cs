using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ProjectFirma.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.ScheduledJobs;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using Hangfire;
using ProjectFirma.Web.Auth;
using Microsoft.Owin.Security;

// This is how Owin figures out the class to call on startup
[assembly: OwinStartup(typeof(FirmaOwinStartup))]

namespace ProjectFirma.Web
{
    /// <summary>
    ///     Owin Startup for Corral
    /// </summary>
    public class FirmaOwinStartup
    {
        public const string CookieAuthenticationType = "Cookies";
        private static readonly object BranchBuildLock = new object();

        /// <summary>
        ///     Function required by <see cref="OwinStartupAttribute" />
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            SitkaHttpApplication.Logger.Info("Owin Startup - Start Configuration");
            app.Use((ctx, next) =>
            {
                // Trying a lock here to prevent sporadic "Collection was modified; enumeration operation may not execute." error.      
                lock (BranchBuildLock)
                {
                    var branch = app.New();
                    JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

                    // Specify TLS 1.2 for Rest API calls
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    var tenant = GetTenantFromUrl(ctx.Request);
                    HttpRequestStorage.Tenant = tenant;
                    if (!tenant.TenantEnabled)
                    {
                        throw new SitkaDisplayErrorException($"Tenant {tenant.TenantName} is disabled; cannot show site");
                    }

                    var canonicalHostNameForEnvironment = FirmaWebConfiguration.FirmaEnvironment.GetCanonicalHostNameForEnvironment(tenant);
                    var tenantAttributes = MultiTenantHelpers.GetTenantAttributeFromCache();
                    var cookieSecureOption = FirmaWebConfiguration.RedirectToHttps
                        ? CookieSecureOption.Always
                        : CookieSecureOption.Never;
                    branch.UseCookieAuthentication(new CookieAuthenticationOptions
                    {
                        AuthenticationType = CookieAuthenticationType,
                        CookieManager = new SystemWebChunkingCookieManager(),
                        CookieName = ClaimsIdentityHelper.GetAuthenticationApplicationCookieName(tenant),
                        CookieSecure = cookieSecureOption
                    });

                    switch (FirmaWebConfiguration.AuthenticationType)
                    {
                        case AuthenticationType.KeystoneAuth:
                            var keyStoneFactory = new KeystoneAuthenticationConfigurationFactory();
                            branch.UseOpenIdConnectAuthentication(keyStoneFactory.CreateKeystoneOpenIdConnectAuthenticationOptions(
                                CookieAuthenticationType, 
                                tenantAttributes.KeystoneOpenIDClientIdentifier,
                                tenantAttributes.KeystoneOpenIDClientSecret,
                                canonicalHostNameForEnvironment,
                                tenant
                                ));
                            break;
                        case AuthenticationType.LocalAuth:
                            break;
                        case AuthenticationType.Auth0Auth:
                            var auth0Factory = new Auth0AuthenticationConfigurationFactory();
                            // Set Cookies as default authentication type
                            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
                            app.UseCookieAuthentication(auth0Factory.CreateAuth0CookieAuthenticationOptions());
                            branch.UseOpenIdConnectAuthentication(auth0Factory.CreateAuth0OpenIdConnectAuthenticationOptions(canonicalHostNameForEnvironment));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    

                    // we have to do this per tenant so needs to belong here
                    branch.UseHangfireDashboard("/hangfire", new DashboardOptions
                    {
                        Authorization = new[] {new HangfireFirmaWebAuthorizationFilter()}
                    });
                    return branch.Build()(ctx.Environment);
                }
            });

            ScheduledBackgroundJobBootstrapper.ConfigureHangfireAndScheduledBackgroundJobs(app);
        }

        private Tenant GetTenantFromUrl(IOwinRequest argRequest)
        {
            return MultiTenantHelpers.GetTenantFromHostUrl(argRequest.Uri);
        }

        public static void MakeFirmaSessionForPersonLoggingIn(Person person, DateTime currentDateTime)
        {
            person.UpdateDate = currentDateTime;
            person.LastActivityDate = currentDateTime;

            // Find existing FirmaSession if we can for this user
            var firmaSessionsForPerson =
                HttpRequestStorage.DatabaseEntities.FirmaSessions.GetFirmaSessionsByPersonID(person.PersonID, false);
            // If we find an existing Session.
            if (firmaSessionsForPerson.Any())
            {
                // For now, we just give them the last session. This is NOT a long term solution. -- SLG
                HttpRequestStorage.FirmaSession = firmaSessionsForPerson.Last();
                Check.EnsureNotNull(HttpRequestStorage.FirmaSession);
                // Update the FirmaSession to have an update corresponding to the last access by the user
                HttpRequestStorage.FirmaSession.LastActivityDate = currentDateTime;
            }
            else
            {
                // Otherwise, we could not find a FirmaSession for this person. Create one.
                var newFirmaSession = new FirmaSession(HttpRequestStorage.DatabaseEntities, person);
                HttpRequestStorage.FirmaSession = newFirmaSession;
                // Only save if session is being newly created
                HttpRequestStorage.DatabaseEntities.AllFirmaSessions.Add(newFirmaSession);
                HttpRequestStorage.DatabaseEntities.SaveChanges(newFirmaSession.Person);
            }
        }
    }
}