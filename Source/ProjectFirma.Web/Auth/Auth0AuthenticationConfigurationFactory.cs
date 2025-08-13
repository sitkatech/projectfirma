using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Keystone.Common.OpenID;
using LtInfo.Common;
using LtInfo.Common.Email;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Auth
{
   
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
                CookieSameSite = SameSiteMode.None,

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
                AuthenticationFailed = (context) =>
                {
                    SitkaHttpApplication.Logger.Info(
                        $"Owin Startup - Configuration - AuthenticationFailed AuthType:{FirmaWebConfiguration.AuthenticationType}");
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
                    //TODO
                    //HttpRequestStorage.Tenant = tenant;
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
                        claimsIdentity.FindFirst(Auth0OpenIDClaimTypes.Name).Value.ToString()));

                    if (claimsIdentity.IsAuthenticated) // we have a token and we can determine the person.
                    {
                        Auth0OpenIDUtilities.OpenIDClaimHandler(SyncLocalAccountStore, claimsIdentity);
                    }

                    return Task.FromResult(0);
                },
                RedirectToIdentityProvider = notification =>
                {
                    // Inject the organization ID into the Auth0 login request
                    string auth0OrganizationID = ConfigurationManager.AppSettings["auth0:OrganizationID"];
                    //notification.ProtocolMessage.SetParameter("organization", auth0OrganizationID);

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

        public static IAuth0User SyncLocalAccountStore(IAuth0UserClaims auth0UserClaims,
            IIdentity userIdentity)
        {
            SitkaHttpApplication.Logger.DebugFormat("In SyncLocalAccountStore - User '{0}', Authenticated = '{1}'",
                userIdentity.Name,
                userIdentity.IsAuthenticated);

            var sendNewUserNotification = false;
            var sendNewOrganizationNotification = false;
            var person = HttpRequestStorage.DatabaseEntities.People.GetPersonByPersonGuid(auth0UserClaims.UserGuid);

            // It can be useful to have the EXACT same time when looking for/at records later.
            var currentDateTime = DateTime.Now;

            if (person == null)
            {
                person = handleNewUser(auth0UserClaims, currentDateTime, out sendNewUserNotification);
            }
            else
            {
                // existing user - sync values
                SitkaHttpApplication.Logger.DebugFormat("In SyncLocalAccountStore - syncing local profile for User '{0}'", auth0UserClaims.UserGuid);
            }

            person.FirstName = auth0UserClaims.FirstName;
            person.LastName = auth0UserClaims.LastName;
            person.Email = auth0UserClaims.Email;
            person.Phone = auth0UserClaims.PrimaryPhone?.ToPhoneNumberString();
            person.LoginName = auth0UserClaims.LoginName;

            Organization organization = null;

            // handle the organization
            if (auth0UserClaims.OrganizationGuid.HasValue)
            {
                organization = HandleOrganization(auth0UserClaims, person, ref sendNewOrganizationNotification);
            }
            else
            {
                HandleUnknownOrganization(person);
            }

            FirmaOwinStartup.MakeFirmaSessionForPersonLoggingIn(person, currentDateTime);

            if (sendNewUserNotification)
            {
                SendNewUserCreatedMessage(person, auth0UserClaims.LoginName);
            }

            if (sendNewOrganizationNotification)
            {
                SendNewOrganizationCreatedMessage(person, auth0UserClaims.LoginName);
                // Post new Organization to ProjectFirma
                if (person.Tenant.AreOrganizationsExternallySourced)
                {
                    PostOrganizationToExternalSystem(organization).ContinueWith(t => Console.WriteLine(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
                }
            }

            return HttpRequestStorage.Person;
        }

        private static void HandleUnknownOrganization(Person person)
        {
            var unknownOrganization = HttpRequestStorage.DatabaseEntities.Organizations.GetUnknownOrganization();
            person.OrganizationID = unknownOrganization.OrganizationID;
            //Assign user to magic Unknown Organization ID
        }

        private static Organization HandleOrganization(IAuth0UserClaims auth0UserClaims, Person person,
            ref bool sendNewOrganizationNotification)
        {
            Organization organization;
            // We are having erratic errors here where we appear not to be able to look up Organizations in the database that definitely should be there. I'm 
            // adding some additional debugging to track down the exact nature of the failure here, which I can't directly replicate. Sorry
            // for the noise here. -- SLG 1/21/2020

            // first look by guid, then by name; 
            var organizationByGuid = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganizationByKeystoneOrganizationGuid(auth0UserClaims.OrganizationGuid.Value);
            SitkaHttpApplication.Logger.Info($"Tenant \"{HttpRequestStorage.Tenant.TenantName}\" (TenantID: {HttpRequestStorage.Tenant.TenantID}): In SyncLocalAccountStore - organizationByGuid '{auth0UserClaims.OrganizationGuid}' found: {organizationByGuid != null}");

            var organizationByName = HttpRequestStorage.DatabaseEntities.Organizations.GetOrganizationByOrganizationName(auth0UserClaims.OrganizationName);
            SitkaHttpApplication.Logger.Info($"Tenant \"{HttpRequestStorage.Tenant.TenantName}\" (TenantID: {HttpRequestStorage.Tenant.TenantID}): In SyncLocalAccountStore - organizationByName '{auth0UserClaims.OrganizationName}' found: {organizationByName != null}");

            organization = organizationByGuid ?? organizationByName;

            // If Organization not available, create it on the fly since it is a person org
            if (organization == null)
            {
                SitkaHttpApplication.Logger.Info($"Tenant \"{HttpRequestStorage.Tenant.TenantName}\" (TenantID: {HttpRequestStorage.Tenant.TenantID}): In SyncLocalAccountStore - Could not find Organization with auth0UserClaims.OrganizationGuid '{auth0UserClaims.OrganizationGuid}' or auth0UserClaims.OrganizationName '{auth0UserClaims.OrganizationName}'. Will attempt to create new Organization.");
                // Do we have any Organizations at all?? (Have we somehow trashed HttpRequestStorage.DatabaseEntities.Organizations?)
                SitkaHttpApplication.Logger.Info($"Tenant \"{HttpRequestStorage.Tenant.TenantName}\" HttpRequestStorage.DatabaseEntities.Organizations count: {HttpRequestStorage.DatabaseEntities.Organizations.Count()}");

                var defaultOrganizationType = HttpRequestStorage.DatabaseEntities.OrganizationTypes.GetDefaultOrganizationType();
                organization = new Organization(auth0UserClaims.OrganizationName, true, defaultOrganizationType, Organization.UseOrganizationBoundaryForMatchmakerDefault, false);
                HttpRequestStorage.DatabaseEntities.AllOrganizations.Add(organization);
                sendNewOrganizationNotification = true;
            }
            else
            {
                SitkaHttpApplication.Logger.Info($"Tenant \"{HttpRequestStorage.Tenant.TenantName}\" (TenantID: {HttpRequestStorage.Tenant.TenantID}): In SyncLocalAccountStore - Successfully found existing Organization with auth0UserClaims.OrganizationGuid '{auth0UserClaims.OrganizationGuid}' or auth0UserClaims.OrganizationName '{auth0UserClaims.OrganizationName}'.");
            }

            organization.OrganizationName = auth0UserClaims.OrganizationName;

            if (!organization.KeystoneOrganizationGuid.HasValue)
            {
                organization.KeystoneOrganizationGuid = auth0UserClaims.OrganizationGuid;
            }

            person.Organization = organization;
            person.OrganizationID = organization.OrganizationID;
            return organization;
        }

        private static Person handleNewUser(IAuth0UserClaims auth0UserClaims, DateTime currentDateTime,
            out bool sendNewUserNotification)
        {
            Person person;
            // new user - provision with limited role
            SitkaHttpApplication.Logger.DebugFormat(
                "In SyncLocalAccountStore - creating local profile for User '{0}'", auth0UserClaims.UserGuid);
            var unknownOrganization = HttpRequestStorage.DatabaseEntities.Organizations.GetUnknownOrganization();
            person = new Person(
                auth0UserClaims.UserGuid,
                auth0UserClaims.FirstName,
                auth0UserClaims.LastName,
                auth0UserClaims.Email,
                Role.Unassigned.RoleID,
                currentDateTime,
                true,
                unknownOrganization.OrganizationID,
                false,
                auth0UserClaims.LoginName);
            person.TenantID = HttpRequestStorage.Tenant.TenantID;
            HttpRequestStorage.DatabaseEntities.AllPeople.Add(person);
            sendNewUserNotification = true;
            return person;
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
                        You may want to <a href=""{SitkaRoute<OrganizationController>.BuildAbsoluteUrlFromExpression(x => x.Detail(organization
                            .OrganizationID, null))}"">add detail for this {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}</a> such as its abbreviation, {FieldDefinitionEnum.OrganizationType.ToType().GetFieldDefinitionLabel()}, website, logo, etc. This will make its {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} summary page display better.
                    </p>
                    <br />
                    <div style='font-size: 10px; color: gray'>
                    OTHER DETAILS:<br />
                    LOGIN: {loginName}<br />
                    <br />
                    </div>
                    <div>{$"- {MultiTenantHelpers.GetToolDisplayName()} team"}<br/><br/><img src=""cid:tool-logo"" width=""160"" /></div>

                    <div>You received this email because you are set up as a point of contact for support - if that's not correct, let us know: {FirmaWebConfiguration.SitkaSupportEmail}.</div>
                </div>
                ";

            SendMessageImpl(person, subject, message);
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
                            You may want to <a href=""{SitkaRoute<UserController>.BuildAbsoluteUrlFromExpression(x => x.Detail(person.PersonID))}"">assign this user roles</a> to allow them to work with specific areas of the site. Or you can leave the user with an unassigned role if they don't need special privileges.
                        </p>
                        <br />
                    <div style='font-size: 10px; color: gray'>
                    OTHER DETAILS:<br />
                    LOGIN: {loginName}<br />
                    <br />
                    </div>
                    <div>{$"- {MultiTenantHelpers.GetToolDisplayName()} team"}<br/><br/><img src=""cid:tool-logo"" width=""160"" /></div>
                    <div>You received this email because you are set up as a point of contact for support - if that's not correct, let us know: {FirmaWebConfiguration.SitkaSupportEmail}.</div>
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