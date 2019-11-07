/*-----------------------------------------------------------------------
<copyright file="UserController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Office2013.Word;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.User;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Email;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.KeystoneDataService;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.UserStewardshipAreas;
using Organization = ProjectFirmaModels.Models.Organization;
using Person = ProjectFirmaModels.Models.Person;

namespace ProjectFirma.Web.Controllers
{
    public class UserController : FirmaBaseController
    {

        [UserEditFeature]
        public ViewResult Index()
        {
            const IndexGridSpec.UsersStatusFilterTypeEnum filterTypeEnum =
                IndexGridSpec.UsersStatusFilterTypeEnum.ActiveUsers;
            return ViewIndex(SitkaRoute<UserController>.BuildUrlFromExpression(x => x.IndexGridJsonData(filterTypeEnum)));
        }

        [UserEditFeature]
        public ViewResult ViewIndex(string gridDataUrl)
        {
            var firmaPage = FirmaPageTypeEnum.UsersList.GetFirmaPage();

            List<SelectListItem> activeOnlyOrAllUserSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Active Users Only",
                    Value = SitkaRoute<UserController>.BuildUrlFromExpression(x =>
                        x.IndexGridJsonData(IndexGridSpec.UsersStatusFilterTypeEnum.ActiveUsers))
                },
                new SelectListItem()
                {
                    Text = "All Users",
                    Value = SitkaRoute<UserController>.BuildUrlFromExpression(x =>
                        x.IndexGridJsonData(IndexGridSpec.UsersStatusFilterTypeEnum.AllUsers))
                }
            };

            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage, gridDataUrl, activeOnlyOrAllUserSelectListItems);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [UserEditFeature]
        public GridJsonNetJObjectResult<Person> IndexGridJsonData(IndexGridSpec.UsersStatusFilterTypeEnum usersStatusFilterType)
        {
            var gridSpec = new IndexGridSpec(CurrentFirmaSession);
            var persons = HttpRequestStorage.DatabaseEntities.People.Include(x => x.Organization)
                .Include(x => x.OrganizationsWhereYouAreThePrimaryContactPerson).ToList().Where(x =>
                    new UserViewFeature().HasPermission(CurrentFirmaSession, x).HasPermission);
            switch (usersStatusFilterType)
            {
                case IndexGridSpec.UsersStatusFilterTypeEnum.ActiveUsers:
                    persons = persons.Where(x => x.IsActive);
                    break;
                case IndexGridSpec.UsersStatusFilterTypeEnum.AllUsers:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("usersStatusFilterType", usersStatusFilterType,
                        null);
            }

            var gridJsonNetJObjectResult =
                new GridJsonNetJObjectResult<Person>(persons.OrderBy(x => x.GetFullNameLastFirst()).ToList(), gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [UserEditFeature]
        public PartialViewResult EditRoles(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var viewModel = new EditRolesViewModel(person);
            return ViewEditRoles(viewModel);
        }

        [HttpPost]
        [UserEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditRoles(PersonPrimaryKey personPrimaryKey, EditRolesViewModel viewModel)
        {
            var personBeingEdited = personPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditRoles(viewModel);
            }

            viewModel.UpdateModel(personBeingEdited, CurrentFirmaSession);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditRoles(EditRolesViewModel viewModel)
        {
            var roles = CurrentPerson.IsSitkaAdministrator() ? Role.All : Role.All.Except(new[] {Role.SitkaAdmin});
            var rolesAsSelectListItems =
                roles.ToSelectListWithEmptyFirstRow(x => x.RoleID.ToString(CultureInfo.InvariantCulture),
                    x => x.GetRoleDisplayName());
            var viewData = new EditRolesViewData(rolesAsSelectListItems);
            return RazorPartialView<EditRoles, EditRolesViewData, EditRolesViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [UserEditFeature]
        public PartialViewResult Delete(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(person.PersonID);
            return ViewDelete(person, viewModel);
        }

        private PartialViewResult ViewDelete(Person personToDelete, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !personToDelete.HasDependentObjects() && personToDelete != CurrentPerson;
            var confirmMessage = canDelete
                ? $"Are you sure you want to delete {personToDelete.GetFullNameFirstLastAndOrg()}?"
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Person",
                    SitkaRoute<UserController>.BuildLinkFromExpression(x => x.Detail(personToDelete), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData,
                viewModel);
        }

        [HttpPost]
        [UserEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Delete(PersonPrimaryKey personPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var person = personPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDelete(person, viewModel);
            }

            person.DeleteFull(HttpRequestStorage.DatabaseEntities);
            return new ModalDialogFormJsonResult();
        }

        [UserViewFeature]
        public ViewResult Detail(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var userNotificationGridSpec = new UserNotificationGridSpec();
            var userNotificationGridDataUrl =
                SitkaRoute<UserController>.BuildUrlFromExpression(
                    x => x.UserNotificationsGridJsonData(personPrimaryKey));
            var basicProjectInfoGridSpec = new Views.Project.BasicProjectInfoGridSpec(CurrentFirmaSession, false)
            {
                ObjectNameSingular =
                    $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} where {person.GetFullNameFirstLast()} is the {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural =
                    $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} where {person.GetFullNameFirstLast()} is the {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()}",
                SaveFiltersInCookie = true
            };
            const string basicProjectInfoGridName = "userProjectListGrid";
            var basicProjectInfoGridDataUrl =
                SitkaRoute<UserController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(person));
            var activateInactivateUrl =
                SitkaRoute<UserController>.BuildUrlFromExpression(x => x.ActivateInactivatePerson(person));
            var viewData = new DetailViewData(this.CurrentFirmaSession,
                person,
                basicProjectInfoGridSpec,
                basicProjectInfoGridName,
                basicProjectInfoGridDataUrl,
                userNotificationGridSpec,
                "userNotifications",
                userNotificationGridDataUrl,
                activateInactivateUrl);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [UserViewFeature]
        public GridJsonNetJObjectResult<Project> ProjectsGridJsonData(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var gridSpec = new Views.Project.BasicProjectInfoGridSpec(CurrentFirmaSession, false);
            var projectPersons = person.GetPrimaryContactProjects(CurrentFirmaSession).OrderBy(x => x.GetDisplayName())
                .ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Project>(projectPersons, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [UserViewFeature]
        public GridJsonNetJObjectResult<Notification> UserNotificationsGridJsonData(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var gridSpec = new UserNotificationGridSpec();
            var notifications = person.Notifications.OrderByDescending(x => x.NotificationDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Notification>(notifications, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [UserEditFeature]
        public PartialViewResult ActivateInactivatePerson(PersonPrimaryKey personPrimaryKey)
        {
            var viewModel = new ConfirmDialogFormViewModel(personPrimaryKey.PrimaryKeyValue);
            return ViewActivateInactivatePerson(personPrimaryKey.EntityObject, viewModel);
        }

        private PartialViewResult ViewActivateInactivatePerson(Person person, ConfirmDialogFormViewModel viewModel)
        {
            string confirmMessage;
            if (person.IsActive)
            {
                var isPrimaryContactForAnyOrganization = person.OrganizationsWhereYouAreThePrimaryContactPerson.Any();
                if (isPrimaryContactForAnyOrganization)
                {
                    confirmMessage =
                        $@"You cannot inactive user '{person.GetFullNameFirstLast()}' because {person.FirstName} is the {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()} for the following organizations: <ul> {string.Join("\r\n", person.GetPrimaryContactOrganizations().Select(x => $"<li>{x.OrganizationName}</li>"))}</ul>";
                }
                else
                {
                    confirmMessage = $"Are you sure you want to inactivate user '{person.GetFullNameFirstLast()}'?";
                }

                var viewData = new ConfirmDialogFormViewData(confirmMessage, !isPrimaryContactForAnyOrganization);
                return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(
                    viewData, viewModel);
            }
            else
            {
                confirmMessage = $"Are you sure you want to activate user '{person.GetFullNameFirstLast()}'?";
                var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
                return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(
                    viewData, viewModel);
            }
        }

        [HttpPost]
        [UserEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ActivateInactivatePerson(PersonPrimaryKey personPrimaryKey,
            ConfirmDialogFormViewModel viewModel)
        {
            var person = personPrimaryKey.EntityObject;
            if (person.IsActive)
            {
                Check.Require(!person.OrganizationsWhereYouAreThePrimaryContactPerson.Any(),
                    $@"You cannot inactive user '{person.GetFullNameFirstLast()}' because {
                            person.FirstName
                        } is the {FieldDefinitionEnum.OrganizationPrimaryContact.ToType().GetFieldDefinitionLabel()} for one or more {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}!");
            }

            if (!ModelState.IsValid)
            {
                return ViewActivateInactivatePerson(person, viewModel);
            }

            if (person.IsActive)
            {
                // if the person is currently active, we need to remove them from the support email list no matter what since we are about to inactivate the person
                person.ReceiveSupportEmails = false;
            }

            person.IsActive = !person.IsActive;
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [UserEditFeature]
        public PartialViewResult EditStewardshipAreas(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var viewModel =
                new EditUserStewardshipAreasViewModel(person, MultiTenantHelpers.GetProjectStewardshipAreaType());
            return ViewEditStewardshipAreas(viewModel);
        }

        [HttpPost]
        [UserEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditStewardshipAreas(PersonPrimaryKey personPrimaryKey,
            EditUserStewardshipAreasViewModel viewModel)
        {
            var person = personPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditStewardshipAreas(viewModel);
            }

            var projectStewardshipAreaType = MultiTenantHelpers.GetProjectStewardshipAreaType().ToEnum;

            switch (projectStewardshipAreaType)
            {
                case ProjectStewardshipAreaTypeEnum.ProjectStewardingOrganizations:
                    HttpRequestStorage.DatabaseEntities.Organizations.Load();
                    viewModel.UpdateModel(person,
                        HttpRequestStorage.DatabaseEntities.AllPersonStewardOrganizations.Local);
                    break;
                case ProjectStewardshipAreaTypeEnum.TaxonomyBranches:
                    HttpRequestStorage.DatabaseEntities.TaxonomyBranches.Load();
                    viewModel.UpdateModel(person,
                        HttpRequestStorage.DatabaseEntities.AllPersonStewardTaxonomyBranches.Local);
                    break;
                case ProjectStewardshipAreaTypeEnum.GeospatialAreas:
                    HttpRequestStorage.DatabaseEntities.GeospatialAreas.Load();
                    viewModel.UpdateModel(person,
                        HttpRequestStorage.DatabaseEntities.AllPersonStewardGeospatialAreas.Local);
                    break;
                default:
                    throw new InvalidOperationException(
                        "The Stewardship Area editor should only be allowed for tenants with a Project Stewardship Area Type");
            }


            SetMessageForDisplay(
                $"Assigned {FieldDefinitionEnum.ProjectStewardshipArea.ToType().GetFieldDefinitionLabelPluralized()} successfully changed for {person.GetFullNameFirstLast()}.");
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditStewardshipAreas(EditUserStewardshipAreasViewModel viewModel)
        {
            EditUserStewardshipAreasViewData viewData;
            var projectStewardshipAreaType = MultiTenantHelpers.GetProjectStewardshipAreaType().ToEnum;

            switch (projectStewardshipAreaType)
            {
                case ProjectStewardshipAreaTypeEnum.ProjectStewardingOrganizations:
                    var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList()
                        .Where(x => x.CanStewardProjects()).ToList();
                    viewData = new EditUserStewardshipAreasViewData(CurrentFirmaSession, allOrganizations, false);
                    break;
                case ProjectStewardshipAreaTypeEnum.TaxonomyBranches:
                    var allTaxonomyBranches = HttpRequestStorage.DatabaseEntities.TaxonomyBranches.ToList();
                    viewData = new EditUserStewardshipAreasViewData(CurrentFirmaSession, allTaxonomyBranches, false);
                    break;
                case ProjectStewardshipAreaTypeEnum.GeospatialAreas:
                    var allGeospatialAreas = HttpRequestStorage.DatabaseEntities.GeospatialAreas.ToList();
                    viewData = new EditUserStewardshipAreasViewData(CurrentFirmaSession, allGeospatialAreas, false);
                    break;
                default:
                    throw new InvalidOperationException(
                        "The Stewardship Area editor should only be allowed for tenants with a Project Stewardship Area Type");
            }

            return RazorPartialView<EditUserStewardshipAreas, EditUserStewardshipAreasViewData,
                EditUserStewardshipAreasViewModel>(viewData, viewModel);
        }

        [FirmaAdminFeature]
        [HttpGet]
        public ActionResult Invite()
        {
            var viewModel = new InviteViewModel();
            return ViewInvite(viewModel);
        }

        private ActionResult ViewInvite(InviteViewModel viewModel)
        {
            var firmaPage = FirmaPageTypeEnum.InviteUser.GetFirmaPage();
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.OrderBy(x => x.OrganizationName)
                .ToList();
            var cancelUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.Index());
            var viewData = new InviteViewData(CurrentFirmaSession, organizations, firmaPage, cancelUrl);
            return RazorView<Invite, InviteViewData, InviteViewModel>(viewData, viewModel);
        }

        [FirmaAdminFeature]
        [HttpPost]
        public ActionResult Invite(InviteViewModel viewModel)
        {
            var toolDisplayName = MultiTenantHelpers.GetToolDisplayName();
            var homeUrl = SitkaRoute<HomeController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Index());
            var supportUrl = SitkaRoute<HelpController>.BuildAbsoluteUrlHttpsFromExpression(x => x.RequestSupport());
            var inviteModel = new KeystoneService.KeystoneInviteModel
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                SiteName = toolDisplayName,
                Subject = $"Invitation to {toolDisplayName}",
                WelcomeText =
                    $"You have been invited by {CurrentPerson.GetFullNameFirstLast()} at {CurrentPerson.Organization.OrganizationName} ({CurrentPerson.Email}), to create an account in <a href=\"{homeUrl}\">{toolDisplayName}</a>.",
                RedirectURL = homeUrl,
                SupportBlock = $"If you have any questions, please visit our <a href=\"{supportUrl}\">support page</a> or contact {MultiTenantHelpers.GetTenantAttribute().PrimaryContactPerson.GetFullNameFirstLast()} at {MultiTenantHelpers.GetTenantAttribute().PrimaryContactPerson.Organization.OrganizationName} ({MultiTenantHelpers.GetTenantAttribute().PrimaryContactPerson.Email})",
                OrganizationGuid = viewModel.OrganizationGuid,
                SignatureBlock = $"The {toolDisplayName} team"
            };

            var keystoneService = new KeystoneService(HttpRequestStorage.GetHttpContextUserThroughOwin());
            var response = keystoneService.Invite(inviteModel);
            if (response.StatusCode != HttpStatusCode.OK || response.Error != null)
            {
                ModelState.AddModelError("Email",
                    $"There was a problem inviting the user to Keystone: {response.Error.Message}.");
                if (response.Error.ModelState != null)
                {
                    foreach (var modelStateKey in response.Error.ModelState.Keys)
                    {
                        foreach (var err in response.Error.ModelState[modelStateKey])
                        {
                            ModelState.AddModelError(modelStateKey, err);
                        }
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                return ViewInvite(viewModel);
            }

            var keystoneUser = response.Payload.Claims;
            var existingUser = HttpRequestStorage.DatabaseEntities.People.GetPersonByPersonGuid(keystoneUser.UserGuid);
            if (existingUser != null)
            {
                SetMessageForDisplay($"{existingUser.GetFullNameFirstLastAndOrgAsUrl()} already has an account.</a>.");
                return RedirectToAction(new SitkaRoute<UserController>(x => x.Detail(existingUser)));
            }

            var newUser = CreateNewFirmaPerson(keystoneUser, keystoneUser.OrganizationGuid);

            HttpRequestStorage.DatabaseEntities.SaveChanges();

            newUser.RoleID = Role.Normal.RoleID;

            HttpRequestStorage.DatabaseEntities.SaveChanges();

            if (!viewModel.DoNotSendInviteEmailIfExisting && !response.Payload.Created)
            {
                SendExistingKeystoneUserCreatedMessage(newUser, CurrentPerson);
            }

            SetMessageForDisplay(
                $"{newUser.GetFullNameFirstLastAndOrgAsUrl()} successfully added. You may want to assign them a role</a>.");
            return RedirectToAction(new SitkaRoute<UserController>(x => x.Detail(newUser)));
        }

        private static Person CreateNewFirmaPerson(KeystoneService.KeystoneUserClaims keystoneUser, Guid? organizationGuid)
        {
            Organization organization;
            if (organizationGuid.HasValue)
            {
                organization =
                    HttpRequestStorage.DatabaseEntities.Organizations.GetOrganizationByOrganizationGuid(organizationGuid
                        .Value);

                if (organization == null)
                {
                    var keystoneClient = new KeystoneDataClient();


                    var keystoneOrganization = keystoneClient.GetOrganization(organizationGuid.Value);


                    var defaultOrganizationType =
                        HttpRequestStorage.DatabaseEntities.OrganizationTypes.GetDefaultOrganizationType();
                    var firmaOrganization =
                        new Organization(keystoneOrganization.FullName, true, defaultOrganizationType)
                        {
                            OrganizationGuid = keystoneOrganization.OrganizationGuid,
                            OrganizationShortName = keystoneOrganization.ShortName,
                            OrganizationUrl = keystoneOrganization.URL
                        };
                    HttpRequestStorage.DatabaseEntities.AllOrganizations.Add(firmaOrganization);

                    HttpRequestStorage.DatabaseEntities.SaveChanges();

                    organization = firmaOrganization;
                }
            }
            else
            {
                organization = HttpRequestStorage.DatabaseEntities.Organizations.GetUnknownOrganization();
            }


            var firmaPerson = new Person(keystoneUser.UserGuid, keystoneUser.FirstName, keystoneUser.LastName,
                keystoneUser.Email, Role.Unassigned, DateTime.Now, true, organization, false,
                keystoneUser.LoginName);
            HttpRequestStorage.DatabaseEntities.AllPeople.Add(firmaPerson);
            return firmaPerson;
        }


        private static void SendExistingKeystoneUserCreatedMessage(Person person, Person currentPerson)
        {
            var toolDisplayName = MultiTenantHelpers.GetToolDisplayName();
            var subject = $"Invitation to {toolDisplayName}";
            var message = $@"
<div style='font-size: 12px; font-family: Arial'>
    Welcome {person.FirstName},
    <p>
    You have been invited by a colleague, {currentPerson.GetFullNameFirstLast()}, to check out <a href=""{SitkaRoute<HomeController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Index())}\"">{toolDisplayName}</a>.
</p>
    <p>
    Because you have logged into other systems that use the same log in service (Keystone) that {toolDisplayName} uses, you already have an account, but it needs to be activated for {toolDisplayName}.
    </p>
    <p>
    When you have a moment, please activate your account by logging in:
    </p>
    <strong>Log in here:</strong>  <a href=""{SitkaRoute<AccountController>.BuildAbsoluteUrlFromExpression(x => x.LogOn())}"">{toolDisplayName}</a><br />
    <strong>Your user name is:</strong> {person.LoginName}<br />
    <p>
    If you don't remember your password, you will be able to reset it from the link above.
    </p>
    <p>
    Sincerely,<br />
    The {toolDisplayName} team
    </p>";
            var mailMessage = new MailMessage
            {
                From = new MailAddress(FirmaWebConfiguration.DoNotReplyEmail),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.ReplyToList.Add(currentPerson.Email);
            mailMessage.To.Add(person.Email);
            SitkaSmtpClient.Send(mailMessage);
        }

        #region Impersonation
        
        [FirmaImpersonateUserFeature]
        public ActionResult SinglePageImpersonateUser(PersonPrimaryKey personToImpersonate)
        {
            return ImpersonateUser(personToImpersonate);
            /*
            AssertImpersonationAllowedByEnvironment();
            AssertFirmaSessionCanImpersonate(this.CurrentFirmaSession);

            var personToImpersonate = People.GetPerson(personIDToImpersonate, true);

            var viewData = new SinglePageImpersonateUserViewData(TaurusSession, personToImpersonate);
            var viewModel = new SinglePageImpersonateUserViewModel();
            return View<SinglePageImpersonateUser, SinglePageImpersonateUserViewData, SinglePageImpersonateUserViewModel>(viewData, viewModel);
            */
            //throw new NotImplementedException();
        }

        [FirmaImpersonateUserFeature]
        [HttpPost]
        public ActionResult ImpersonateUser(PersonPrimaryKey personToImpersonate)
        {
            AssertImpersonationAllowedByEnvironment();
            AssertFirmaSessionCanImpersonate(this.CurrentFirmaSession);

            Uri previousPageUri = Request.UrlReferrer;
            ImpersonatePersonID(this, personToImpersonate, previousPageUri);

            // Drop them on the home page for any new impersonation. 
            // 
            // This is because we don't know what a given user might have access to, so we can't be sure the current page
            // will be accessible any more.
            return RedirectToAction(new SitkaRoute<HomeController>(c => c.Index()));
        }

        /// <summary>
        /// Impersonate the given User ID.
        /// Designed to be callable by other methods in other controllers
        /// </summary>
        /// <param name="activeController"></param>
        /// <param name="personIDToImpersonate"></param>
        /// <param name="optionalPreviousPageUri">Optional URI to the referring page. May be null or blank if not known.</param>
        public static void ImpersonatePersonID(FirmaBaseController activeController, PersonPrimaryKey personIDToImpersonate, Uri optionalPreviousPageUri)
        {
            Person personToImpersonate = personIDToImpersonate.EntityObject;
            if (activeController.CurrentFirmaSession.Person.PersonID == personToImpersonate.PersonID)
            {
                string currentPersonFullName = activeController.CurrentFirmaSession.Person.GetFullNameFirstLast();
                string impersonationWarning = $"Attempted to impersonate person {currentPersonFullName}, but you are already acting as {currentPersonFullName}. Nothing done.";
                activeController.SetErrorForDisplay(impersonationWarning);
                return;
            }

            AssertImpersonationAllowedByEnvironment();
            AssertFirmaSessionCanImpersonate(activeController.CurrentFirmaSession);
            AssertNotAttemptingToImpersonateSelf(activeController.CurrentFirmaSession, personToImpersonate.PersonID);
            AssertPersonCanBeImpersonated(activeController.CurrentFirmaSession, personToImpersonate);

            activeController.CurrentFirmaSession.ImpersonateUser(personToImpersonate, optionalPreviousPageUri, out var statusMessage, out var statusWarning);
            activeController.SetInfoForDisplay(statusMessage);

            // Warning is optional
            if (statusWarning != null)
            {
                // In Firma, is this the best way to express a "warning" message? Unsure.
                activeController.SetMessageForDisplay(statusWarning);
            }

            HttpRequestStorage.DatabaseEntities.SaveChangesWithNoAuditing(activeController.CurrentPerson.TenantID);
        }

        public static void AssertNotAttemptingToImpersonateSelf(FirmaSession firmaSession, int personIDToImpersonate)
        {
            Check.RequireThrowNotAuthorized(firmaSession.PersonID != personIDToImpersonate, $"User {firmaSession.UserDisplayName} is not allowed to impersonate themselves. (This should not have happened, and may indicate a coding error).");
        }

        public static void AssertImpersonationAllowedByEnvironment()
        {
            Check.RequireThrowNotAuthorized(FirmaWebConfiguration.ImpersonationAllowedInEnvironment, $"Impersonation is not enabled for Tenant {HttpRequestStorage.Tenant.TenantName}");
        }

        public static void AssertFirmaSessionCanImpersonate(FirmaSession firmaSession)
        {
            bool currentFirmaSessionCanImpersonate = new FirmaImpersonateUserFeature().HasPermissionByFirmaSession(firmaSession);
            Check.RequireThrowNotAuthorized(currentFirmaSessionCanImpersonate, $"User {firmaSession.UserDisplayName} is not allowed to impersonate anyone else.");
        }

        public static void AssertPersonCanBeImpersonated(FirmaSession firmaSession, Person personToImpersonate)
        {
            Check.RequireNotNull(personToImpersonate, "Can't impersonate a null/anonymous user");
            AssertNotAttemptingToImpersonateSelf(firmaSession, personToImpersonate.PersonID);
        }

        #endregion impersonation



    }
}
