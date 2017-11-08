/*-----------------------------------------------------------------------
<copyright file="AccountController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using Keystone.Common;
using LtInfo.Common;
using LtInfo.Common.Email;
using Person = ProjectFirma.Web.Models.Person;

namespace ProjectFirma.Web.Controllers
{
    public class AccountController : RelyingPartyAccountController
    {
        protected override string LoginUrl
        {
            get { return SitkaRoute<AccountController>.BuildAbsoluteUrlHttpsFromExpression(c => c.LogOn()); }
        }

        protected override ISitkaDbContext SitkaDbContext => HttpRequestStorage.DatabaseEntities;

        protected override string HomeUrl
        {
            get { return SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.Index()); }
        }

        // also need to decide how to handle account verification status and also implement hash on db row to avoid unnecessary updates
        protected override IKeystoneUser SyncLocalAccountStore(IKeystoneUserClaims keystoneUserClaims)
        {
            SitkaHttpApplication.Logger.DebugFormat("In SyncLocalAccountStore - User '{0}', Authenticated = '{1}'",
                Thread.CurrentPrincipal.Identity.Name,
                Thread.CurrentPrincipal.Identity.IsAuthenticated);

            var sendNewUserNotification = false;
            var sendNewOrganizationNotification = false;
            var person = HttpRequestStorage.DatabaseEntities.People.GetPersonByPersonGuid(keystoneUserClaims.UserGuid);

            if (person == null)
            {
                // new user - provision with limited role
                SitkaHttpApplication.Logger.DebugFormat("In SyncLocalAccountStore - creating local profile for User '{0}'", keystoneUserClaims.UserGuid);
                var unknownOrganization = HttpRequestStorage.DatabaseEntities.Organizations.Single(x => x.OrganizationName == Organization.OrganizationUnknown);
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
                var unknownOrganization = HttpRequestStorage.DatabaseEntities.Organizations.Single(x => x.OrganizationName == Organization.OrganizationUnknown);
                person.OrganizationID = unknownOrganization.OrganizationID;
                //Assign user to magic Unkown Organization ID
            }

            person.UpdateDate = DateTime.Now;
            HttpRequestStorage.Person = person;
            HttpRequestStorage.DatabaseEntities.SaveChanges(person);

            var ipAddress = Request.UserHostAddress;
            var userAgent = Request.UserAgent;
            if (sendNewUserNotification)
            {
                SendNewUserCreatedMessage(person, ipAddress, userAgent, keystoneUserClaims.LoginName);
            }

            if (sendNewOrganizationNotification)
            {
                SendNewOrganizationCreatedMessage(person, ipAddress, userAgent, keystoneUserClaims.LoginName);
            }

            return HttpRequestStorage.Person;
        }

        [AnonymousUnclassifiedFeature]
        public ContentResult NotAuthorized()
        {
            return Content("Not Authorized");
        }

        private static void SendNewUserCreatedMessage(Person person, string ipAddress, string userAgent, string loginName)
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
    IP ADDRESS: {ipAddress}<br />
    USERAGENT: {userAgent}<br />
    <br />
    </div>
    <div>You received this email because you are set up as a point of contact for support - if that's not correct, let us know: {
                    FirmaWebConfiguration.SitkaSupportEmail
                }.</div>
</div>
";
            
            var mailMessage = new MailMessage { From = new MailAddress(FirmaWebConfiguration.DoNotReplyEmail), Subject = subject, Body = message, IsBodyHtml = true };
            mailMessage.To.Add(FirmaWebConfiguration.SitkaSupportEmail);

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

        private static void SendNewOrganizationCreatedMessage(Person person, string ipAddress, string userAgent, string loginName)
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
    IP ADDRESS: {ipAddress}<br />
    USERAGENT: {userAgent}<br />
    <br />
    </div>
    <div>You received this email because you are set up as a point of contact for support - if that's not correct, let us know: {
                    FirmaWebConfiguration.SitkaSupportEmail
                }</div>.
</div>
";
            
            var mailMessage = new MailMessage { From = new MailAddress(FirmaWebConfiguration.DoNotReplyEmail), Subject = subject, Body = message, IsBodyHtml = true };
            mailMessage.To.Add(FirmaWebConfiguration.SitkaSupportEmail);

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
