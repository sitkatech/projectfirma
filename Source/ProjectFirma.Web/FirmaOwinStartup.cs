

// This is how Owin figures out the class to call on startup

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using Keystone.Common.OpenID;
using LtInfo.Common;
using LtInfo.Common.Email;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Provider;
using Owin;
using ProjectFirma.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

[assembly: OwinStartup(typeof(FirmaOwinStartup))]

namespace ProjectFirma.Web
{
    /// <summary>
    /// Owin Startup for Firma
    /// </summary>
    public class FirmaOwinStartup
    {
        /// <summary>
        /// Function required by <see cref="OwinStartupAttribute"/>
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            SitkaHttpApplication.Logger.Info("Owin Startup");

            app.Use((ctx, next) =>
            {
                var branch = app.New();
                System.IdentityModel.Tokens.JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

                var tenant = Tenant.All.First(p => ctx.Request.Uri.Host.EndsWith(p.TenantDomain, StringComparison.InvariantCultureIgnoreCase));

                branch.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = "Cookies",
                    CookieManager = new Microsoft.Owin.Host.SystemWeb.SystemWebChunkingCookieManager(),
                    CookieDomain = $".{tenant.TenantDomain}",
                    CookieName = $"{tenant.KeystoneOpenIDClientIdentifier}_{FirmaWebConfiguration.FirmaEnvironment.FirmaEnvironmentType}"
                });


                branch.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
                {
                    ClientId = tenant.KeystoneOpenIDClientIdentifier,
                    Authority = FirmaWebConfiguration.KeystoneOpenIDUrl,
                    RedirectUri = SitkaRoute<AccountController>.BuildAbsoluteUrlHttpsFromExpression(c => c.LogOn()), // this has to match the keystone client redirect uri
                    PostLogoutRedirectUri = $"https://{FirmaWebConfiguration.FirmaEnvironment.GetCanonicalHostNameForEnvironment(tenant)}/", // OpenID is super picky about this; url must match what Keystone has EXACTLY (Trailing slash and all)
                    ResponseType = "id_token token",
                    Scope = "openid all_claims keystone",
                    UseTokenLifetime = false,
                    SignInAsAuthenticationType = "Cookies",
                    ClientSecret = tenant.KeystoneOpenIDClientSecret,
                    CallbackPath = new PathString("/Account/LogOn"),

                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        SecurityTokenValidated = n =>
                        {
                            var claimsIdentity = n.AuthenticationTicket.Identity;
                            claimsIdentity.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));

                            if (n.ProtocolMessage.Code != null)
                                claimsIdentity.AddClaim(new Claim("code", n.ProtocolMessage.Code));

                            if (n.ProtocolMessage.AccessToken != null)
                                claimsIdentity.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));

                            //map name claim to default name type
                            claimsIdentity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", claimsIdentity.FindFirst(KeystoneOpenIDClaimTypes.Name).Value.ToString()));

                            if (claimsIdentity.IsAuthenticated) // we have a token and we can determine the person.
                            {
                                KeystoneOpenIDUtilities.OpenIDClaimHandler(SyncLocalAccountStore, claimsIdentity);
                            }

                            return Task.FromResult(0);
                        },
                        RedirectToIdentityProvider = n =>
                        {
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
                            else if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.AuthenticationRequest)
                            {
                                var httpContextBase = GetHttpContext(n);
                                var referrer = httpContextBase.Request.UrlReferrer;
                                if (referrer != null && referrer.Host == FirmaWebConfiguration.CanonicalHostName)
                                {
                                    n.Response.Cookies.Append("ReturnURL", referrer.PathAndQuery);
                                }
                            }


                            return Task.FromResult(0);
                        }
                    }
                });

                return branch.Build()(ctx.Environment);
            });
        }

        private static HttpContextBase GetHttpContext(BaseContext<OpenIdConnectAuthenticationOptions> n)
        {
            return (HttpContextBase)n.OwinContext.Environment["System.Web.HttpContextBase"];
        }

        public static IKeystoneUser SyncLocalAccountStore(IKeystoneUserClaims keystoneUserClaims, IIdentity userIdentity)
        {
            SitkaHttpApplication.Logger.DebugFormat("In SyncLocalAccountStore - User '{0}', Authenticated = '{1}'",
                userIdentity.Name,
                userIdentity.IsAuthenticated);

            var sendNewUserNotification = false;
            var sendNewOrganizationNotification = false;
            var person = HttpRequestStorage.DatabaseEntities.People.GetPersonByPersonGuid(keystoneUserClaims.UserGuid);

            if (person == null)
            {
                // new user - provision with limited role
                SitkaHttpApplication.Logger.DebugFormat("In SyncLocalAccountStore - creating local profile for User '{0}'", keystoneUserClaims.UserGuid);
                var unknownOrganization = HttpRequestStorage.DatabaseEntities.Organizations.GetUnknownOrganization();
                person = new Person(keystoneUserClaims.UserGuid,
                    keystoneUserClaims.FirstName,
                    keystoneUserClaims.LastName,
                    keystoneUserClaims.Email,
                    Role.Unassigned.RoleID,
                    DateTime.Now,
                    true,
                    unknownOrganization.OrganizationID,
                    false,
                    keystoneUserClaims.LoginName);
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

            // handle the organization
            if (keystoneUserClaims.OrganizationGuid.HasValue)
            {
                // first look by guid, then by name; if not available, create it on the fly since it is a person org
                var organization = (HttpRequestStorage.DatabaseEntities.Organizations.GetOrganizationByOrganizationGuid(keystoneUserClaims.OrganizationGuid.Value) ??
                                    HttpRequestStorage.DatabaseEntities.Organizations.GetOrganizationByOrganizationName(keystoneUserClaims.OrganizationName));

                if (organization == null)
                {
                    var defaultOrganizationType = HttpRequestStorage.DatabaseEntities.OrganizationTypes.GetDefaultOrganizationType();
                    organization = new Organization(keystoneUserClaims.OrganizationName, true, defaultOrganizationType);
                    HttpRequestStorage.DatabaseEntities.AllOrganizations.Add(organization);
                    sendNewOrganizationNotification = true;
                }

                organization.OrganizationName = keystoneUserClaims.OrganizationName;

                if (!organization.OrganizationGuid.HasValue)
                {
                    organization.OrganizationGuid = keystoneUserClaims.OrganizationGuid;
                }
                person.Organization = organization;
                person.OrganizationID = organization.OrganizationID;
            }
            else
            {
                var unknownOrganization = HttpRequestStorage.DatabaseEntities.Organizations.GetUnknownOrganization();
                person.OrganizationID = unknownOrganization.OrganizationID;
                //Assign user to magic Unkown Organization ID
            }

            person.UpdateDate = DateTime.Now;
            HttpRequestStorage.Person = person;
            HttpRequestStorage.DatabaseEntities.SaveChanges(person);

            if (sendNewUserNotification)
            {
                SendNewUserCreatedMessage(person, keystoneUserClaims.LoginName);
            }

            if (sendNewOrganizationNotification)
            {
                SendNewOrganizationCreatedMessage(person, keystoneUserClaims.LoginName);
            }

            return HttpRequestStorage.Person;

        }


        private static void SendNewUserCreatedMessage(Person person, string loginName)
        {
            var subject = $"User added: {person.FullNameFirstLastAndOrg}";
            var message = $@"
    <div style='font-size: 12px; font-family: Arial'>
        <strong>Project Firma User added:</strong> {person.FullNameFirstLast}<br />
        <strong>Added on:</strong> {DateTime.Now}<br />
        <strong>Email:</strong> {person.Email}<br />
        <strong>Phone:</strong> {person.Phone.ToPhoneNumberString()}<br />
        <br />
        <p>
            You may want to <a href=""{
                SitkaRoute<UserController>.BuildAbsoluteUrlFromExpression(x => x.Detail(person.PersonID))
            }"">assign this user roles</a> to allow them to work with specific areas of the site. Or you can leave the user with an unassigned role if they don't need special privileges.
        </p>
        <br />
        <br />
    <div style='font-size: 10px; color: gray'>
    OTHER DETAILS:<br />
    LOGIN: {loginName}<br />
    <br />
    </div>
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
            var subject = $"{FieldDefinition.Organization.GetFieldDefinitionLabel()} added: {person.Organization.DisplayName}";

            var message = $@"
<div style='font-size: 12px; font-family: Arial'>
    <strong>{FieldDefinition.Organization.GetFieldDefinitionLabel()} created:</strong> {organization.GetDisplayNameAsUrl()}<br />
    <strong>Created on:</strong> {DateTime.Now}<br />
    <strong>Created because:</strong> New user logged in<br />
    <strong>New user:</strong> {person.FullNameFirstLast} ({person.Email})<br />
    <br />
    <p>
        You may want to <a href=""{
            SitkaRoute<OrganizationController>.BuildAbsoluteUrlFromExpression(x => x.Detail(organization
                .OrganizationID))
        }"">add detail for this {FieldDefinition.Organization.GetFieldDefinitionLabel()}</a> such as its abbreviation, {
            FieldDefinition.OrganizationType.GetFieldDefinitionLabel()
        }, website, logo, etc. This will make its {FieldDefinition.Organization.GetFieldDefinitionLabel()} summary page display better.
    </p>
    <br />
    <br />
    <div style='font-size: 10px; color: gray'>
    OTHER DETAILS:<br />
    LOGIN: {loginName}<br />
    <br />
    </div>
    <div>You received this email because you are set up as a point of contact for support - if that's not correct, let us know: {
                    FirmaWebConfiguration.SitkaSupportEmail
                }</div>.
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