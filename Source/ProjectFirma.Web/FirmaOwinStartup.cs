﻿using Keystone.Common.OpenID;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Email;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Provider;
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
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using Hangfire;

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
                            branch.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
                            {
                                Authority = FirmaWebConfiguration.KeystoneOpenIDUrl,
                                ResponseType = "id_token token",
                                Scope = "openid all_claims keystone",
                                UseTokenLifetime = false,
                                SignInAsAuthenticationType = CookieAuthenticationType,
                                CallbackPath = new PathString("/Account/LogOn"),
                                ClientId = tenantAttributes.KeystoneOpenIDClientIdentifier,
                                ClientSecret = tenantAttributes.KeystoneOpenIDClientSecret,
                                RedirectUri =
                            $"https://{canonicalHostNameForEnvironment}/Account/LogOn", // this has to match the keystone client redirect uri
                                PostLogoutRedirectUri =
                            $"https://{canonicalHostNameForEnvironment}/", // OpenID is super picky about this; url must match what Keystone has EXACTLY (Trailing slash and all)

                                Notifications = new OpenIdConnectAuthenticationNotifications
                                {
                                    AuthenticationFailed = (context) =>
                                    {
                                        SitkaHttpApplication.Logger.Info($"Owin Startup - Configuration - AuthenticationFailed AuthType:{FirmaWebConfiguration.AuthenticationType}" );
                                        if ((context.Exception.Message.StartsWith("OICE_20004") ||
                                             context.Exception.Message.Contains("IDX10311")))
                                        {
                                            context.SkipToNextMiddleware();
                                            return Task.FromResult(0);
                                        }

                                        return Task.FromResult(0);
                                    },
                                    SecurityTokenValidated = n =>
                                    {
                                        HttpRequestStorage.Tenant = GetTenantFromUrl(n.Request);
                                        SitkaHttpApplication.Logger.Info(
                                            $"In SecurityTokenValidated: TenantID {HttpRequestStorage.Tenant.TenantID}, Url: {n.Request.Uri.ToString()}, AuthType:{FirmaWebConfiguration.AuthenticationType}");

                                        var claimsIdentity = n.AuthenticationTicket.Identity;
                                        claimsIdentity.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));

                                        if (n.ProtocolMessage.Code != null)
                                        {
                                            claimsIdentity.AddClaim(new Claim("code", n.ProtocolMessage.Code));
                                        }

                                        if (n.ProtocolMessage.AccessToken != null)
                                        {
                                            claimsIdentity.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));
                                        }

                                        //map name claim to default name type
                                        claimsIdentity.AddClaim(new Claim(
                                            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name",
                                            claimsIdentity.FindFirst(KeystoneOpenIDClaimTypes.Name).Value.ToString()));

                                        if (claimsIdentity.IsAuthenticated) // we have a token and we can determine the person.
                                        {
                                            KeystoneOpenIDUtilities.OpenIDClaimHandler(SyncLocalAccountStore, claimsIdentity);
                                        }

                                        return Task.FromResult(0);
                                    },
                                    RedirectToIdentityProvider = n =>
                                    {
                                        SitkaHttpApplication.Logger.Info($"Owin Startup - Configuration - RedirectToIdentityProvider AuthType:{FirmaWebConfiguration.AuthenticationType}, RequestType:{n.ProtocolMessage.RequestType}");
                                        //n.ProtocolMessage.RedirectUri = GetHomePage(); // dynamic home page for multiple subdomains
                                        //n.ProtocolMessage.PostLogoutRedirectUri = GetOuterPage(); // dynamic landing page for multiple subdomains
                                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest)
                                        {
                                            var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

                                            if (idTokenHint != null)
                                            {
                                                n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                                            }
                                        }
                                        else if (n.ProtocolMessage.RequestType ==
                                                 OpenIdConnectRequestType.AuthenticationRequest)
                                        {
                                            var httpContextBase = GetHttpContext(n);
                                            var referrer = httpContextBase.Request.UrlReferrer;
                                            if (referrer != null && referrer.Host == canonicalHostNameForEnvironment)
                                            {
                                                n.Response.Cookies.Append("ReturnURL", referrer.PathAndQuery);
                                            }
                                        }

                                        return Task.FromResult(0);
                                    }
                                }
                            });
                            break;
                        case AuthenticationType.LocalAuth:
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

        private static HttpContextBase GetHttpContext(BaseContext<OpenIdConnectAuthenticationOptions> n)
        {
            return (HttpContextBase) n.OwinContext.Environment["System.Web.HttpContextBase"];
        }

        public static IKeystoneUser SyncLocalAccountStore(IKeystoneUserClaims keystoneUserClaims, 
                                                          IIdentity userIdentity)
        {
            SitkaHttpApplication.Logger.DebugFormat("In SyncLocalAccountStore - User '{0}', Authenticated = '{1}'",
                userIdentity.Name,
                userIdentity.IsAuthenticated);

            var sendNewUserNotification = false;
            var sendNewOrganizationNotification = false;
            var person = HttpRequestStorage.DatabaseEntities.People.GetPersonByPersonGuid(keystoneUserClaims.UserGuid);

            // It can be useful to have the EXACT same time when looking for/at records later.
            var currentDateTime = DateTime.Now;

            if (person == null)
            {
                // new user - provision with limited role
                SitkaHttpApplication.Logger.DebugFormat(
                    "In SyncLocalAccountStore - creating local profile for User '{0}'", keystoneUserClaims.UserGuid);
                var unknownOrganization = HttpRequestStorage.DatabaseEntities.Organizations.GetUnknownOrganization();
                person = new Person(keystoneUserClaims.UserGuid,
                    keystoneUserClaims.FirstName,
                    keystoneUserClaims.LastName,
                    keystoneUserClaims.Email,
                    Role.Unassigned.RoleID,
                    currentDateTime,
                    true,
                    unknownOrganization.OrganizationID,
                    false,
                    keystoneUserClaims.LoginName);
                person.TenantID = HttpRequestStorage.Tenant.TenantID;
                HttpRequestStorage.DatabaseEntities.AllPeople.Add(person);
                sendNewUserNotification = true;
            }
            else
            {
                // existing user - sync values
                SitkaHttpApplication.Logger.DebugFormat("In SyncLocalAccountStore - syncing local profile for User '{0}'", keystoneUserClaims.UserGuid);
            }

            person.FirstName = keystoneUserClaims.FirstName;
            person.LastName = keystoneUserClaims.LastName;
            person.Email = keystoneUserClaims.Email;
            person.Phone = keystoneUserClaims.PrimaryPhone?.ToPhoneNumberString();
            person.LoginName = keystoneUserClaims.LoginName;
            Organization organization = null;

            // handle the organization
            if (keystoneUserClaims.OrganizationGuid.HasValue)
            {
                // We are having erratic errors here where we appear not to be able to look up Organizations in the database that definitely should be there. I'm 
                // adding some additional debugging to track down the exact nature of the failure here, which I can't directly replicate. Sorry
                // for the noise here. -- SLG 1/21/2020

                // first look by guid, then by name; 
                var organizationByGuid = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganizationByKeystoneOrganizationGuid(keystoneUserClaims.OrganizationGuid.Value);
                SitkaHttpApplication.Logger.Info($"Tenant \"{HttpRequestStorage.Tenant.TenantName}\" (TenantID: {HttpRequestStorage.Tenant.TenantID}): In SyncLocalAccountStore - organizationByGuid '{keystoneUserClaims.OrganizationGuid}' found: {organizationByGuid != null}");

                var organizationByName = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganizationByOrganizationName(keystoneUserClaims.OrganizationName);
                SitkaHttpApplication.Logger.Info($"Tenant \"{HttpRequestStorage.Tenant.TenantName}\" (TenantID: {HttpRequestStorage.Tenant.TenantID}): In SyncLocalAccountStore - organizationByName '{keystoneUserClaims.OrganizationName}' found: {organizationByName != null}");

                organization = organizationByGuid ?? organizationByName;

                // If Organization not available, create it on the fly since it is a person org
                if (organization == null)
                {
                    SitkaHttpApplication.Logger.Info($"Tenant \"{HttpRequestStorage.Tenant.TenantName}\" (TenantID: {HttpRequestStorage.Tenant.TenantID}): In SyncLocalAccountStore - Could not find Organization with keystoneUserClaims.OrganizationGuid '{keystoneUserClaims.OrganizationGuid}' or keystoneUserClaims.OrganizationName '{keystoneUserClaims.OrganizationName}'. Will attempt to create new Organization.");
                    // Do we have any Organizations at all?? (Have we somehow trashed HttpRequestStorage.DatabaseEntities.Organizations?)
                    SitkaHttpApplication.Logger.Info($"Tenant \"{HttpRequestStorage.Tenant.TenantName}\" HttpRequestStorage.DatabaseEntities.Organizations count: {HttpRequestStorage.DatabaseEntities.Organizations.Count()}");

                    var defaultOrganizationType = HttpRequestStorage.DatabaseEntities.OrganizationTypes.GetDefaultOrganizationType();
                    organization = new Organization(keystoneUserClaims.OrganizationName, true, defaultOrganizationType, Organization.UseOrganizationBoundaryForMatchmakerDefault,false);
                    HttpRequestStorage.DatabaseEntities.AllOrganizations.Add(organization);
                    sendNewOrganizationNotification = true;
                }
                else
                {
                    SitkaHttpApplication.Logger.Info($"Tenant \"{HttpRequestStorage.Tenant.TenantName}\" (TenantID: {HttpRequestStorage.Tenant.TenantID}): In SyncLocalAccountStore - Successfully found existing Organization with keystoneUserClaims.OrganizationGuid '{keystoneUserClaims.OrganizationGuid}' or keystoneUserClaims.OrganizationName '{keystoneUserClaims.OrganizationName}'.");
                }

                organization.OrganizationName = keystoneUserClaims.OrganizationName;

                if (!organization.KeystoneOrganizationGuid.HasValue)
                {
                    organization.KeystoneOrganizationGuid = keystoneUserClaims.OrganizationGuid;
                }

                person.Organization = organization;
                person.OrganizationID = organization.OrganizationID;
            }
            else
            {
                var unknownOrganization = HttpRequestStorage.DatabaseEntities.Organizations.GetUnknownOrganization();
                person.OrganizationID = unknownOrganization.OrganizationID;
                //Assign user to magic Unknown Organization ID
            }

            MakeFirmaSessionForPersonLoggingIn(person, currentDateTime);

            if (sendNewUserNotification)
            {
                SendNewUserCreatedMessage(person, keystoneUserClaims.LoginName);
            }

            if (sendNewOrganizationNotification)
            {
                SendNewOrganizationCreatedMessage(person, keystoneUserClaims.LoginName);
                // Post new Organization to ProjectFirma
                if (person.Tenant.AreOrganizationsExternallySourced)
                {
                    PostOrganizationToExternalSystem(organization).ContinueWith(t => Console.WriteLine(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
                }
            }

            return HttpRequestStorage.Person;
        }

        public static void MakeFirmaSessionForPersonLoggingIn(Person person, DateTime currentDateTime)
        {
            person.UpdateDate = currentDateTime;
            person.LastActivityDate = currentDateTime;

            // Find existing FirmaSession if we can for this user
            var firmaSessionsForPerson =
                HttpRequestStorage.DatabaseEntities.FirmaSessions.GetFirmaSessionsByPersonID(person.PersonID, false);
            // If we find an existing Session..
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

        private static async Task PostOrganizationToExternalSystem(Organization organization)
        {
            var tenant = HttpRequestStorage.Tenant;
            if (tenant.TenantID == Tenant.ActionAgendaForPugetSound.TenantID)
            {
                var organizationPostDto = new OrganizationDto(organization);
                var client = new HttpClient();
                await client.PostAsJsonAsync(
                    $"{FirmaWebConfiguration.PsInfoPostOrganizationUrl}/{FirmaWebConfiguration.PsInfoApiKey}",
                    organizationPostDto);
            }
        }


        private static void SendNewUserCreatedMessage(Person person, string loginName)
        {
            var subject =
                $"{MultiTenantHelpers.GetToolDisplayName()} User added: {person.GetFullNameFirstLast()} ({person.GetOrganizationDescriptor()})";
            var message = $@"
    <div style='font-size: 12px; font-family: Arial'>
        <strong>User added:</strong> {person.GetFullNameFirstLast()}<br />
        <strong>Organization</strong> {person.GetOrganizationDescriptor()} <br />
        <strong>Added on:</strong> {DateTime.Now}<br />
        <strong>Email:</strong> {person.Email}<br />
        <br />
        <p>
            You may want to <a href=""{
                    SitkaRoute<UserController>.BuildAbsoluteUrlFromExpression(x => x.Detail(person.PersonID))
                }"">assign this user roles</a> to allow them to work with specific areas of the site. Or you can leave the user with an unassigned role if they don't need special privileges.
        </p>
        <br />
    <div style='font-size: 10px; color: gray'>
    OTHER DETAILS:<br />
    LOGIN: {loginName}<br />
    <br />
    </div>
    <div>{$"- {MultiTenantHelpers.GetToolDisplayName()} team"}<br/><br/><img src=""cid:tool-logo"" width=""160"" /></div>
    <div>You received this email because you are set up as a point of contact for support - if that's not correct, let us know: {
                    FirmaWebConfiguration.SitkaSupportEmail
                }.</div>
</div>
";

            SendMessageImpl(person, subject, message);
        }

        private static void SendNewOrganizationCreatedMessage(Person person, string loginName)
        {
            var organization = person.Organization;
            var subject =
                $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} added: {person.Organization.GetDisplayName()}";

            var message = $@"
<div style='font-size: 12px; font-family: Arial'>
    <strong>{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} created:</strong> {organization.GetDisplayNameAsUrl()}<br />
    <strong>Created on:</strong> {DateTime.Now}<br />
    <strong>Created because:</strong> New user logged in<br />
    <strong>New user:</strong> {person.GetFullNameFirstLast()} ({person.Email})<br />
    <br />
    <p>
        You may want to <a href=""{
                    SitkaRoute<OrganizationController>.BuildAbsoluteUrlFromExpression(x => x.Detail(organization
                        .OrganizationID, null))
                }"">add detail for this {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}</a> such as its abbreviation, {
                    FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel()
                }, website, logo, etc. This will make its {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} summary page display better.
    </p>
    <br />
    <div style='font-size: 10px; color: gray'>
    OTHER DETAILS:<br />
    LOGIN: {loginName}<br />
    <br />
    </div>
    <div>{$"- {MultiTenantHelpers.GetToolDisplayName()} team"}<br/><br/><img src=""cid:tool-logo"" width=""160"" /></div>

    <div>You received this email because you are set up as a point of contact for support - if that's not correct, let us know: {
                    FirmaWebConfiguration.SitkaSupportEmail
                }.</div>
</div>
";

            SendMessageImpl(person, subject, message);
        }

        private static void SendMessageImpl(Person person, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(FirmaWebConfiguration.DoNotReplyEmail),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var toolLogo = tenantAttribute.TenantSquareLogoFileResourceInfo ??
                           tenantAttribute.TenantBannerLogoFileResourceInfo;
            var htmlView = AlternateView.CreateAlternateViewFromString(message, null, "text/html");
            htmlView.LinkedResources.Add(
                new LinkedResource(new MemoryStream(toolLogo.FileResourceData.Data), "img/jpeg") { ContentId = "tool-logo" });
            mailMessage.AlternateViews.Add(htmlView);

            // Reply-To Header
            mailMessage.ReplyToList.Add(person.Email);

            // TO field
            var supportPersons = HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveSupportEmails();
            foreach (var supportPerson in supportPersons)
            {
                mailMessage.To.Add(supportPerson.Email);
            }

            SitkaSmtpClient.Send(mailMessage);
        }
    }
}