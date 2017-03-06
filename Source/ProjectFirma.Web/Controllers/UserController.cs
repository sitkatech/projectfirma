/*-----------------------------------------------------------------------
<copyright file="UserController.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.User;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.KeystoneDataService;
using Organization = ProjectFirma.Web.Models.Organization;

namespace ProjectFirma.Web.Controllers
{
    public class UserController : FirmaBaseController
    {
        [UserEditFeature]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [UserEditFeature]
        public GridJsonNetJObjectResult<Person> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec(CurrentPerson);
            var persons = HttpRequestStorage.DatabaseEntities.People.ToList().Where(x => !x.IsSitkaUser && new UserViewFeature().HasPermission(CurrentPerson, x).HasPermission).OrderBy(x => x.FullNameLastFirst).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Person>(persons, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [UserEditFeature]
        public PartialViewResult EditRoles(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var viewModel = new EditRolesViewModel(person);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [UserEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditRoles(PersonPrimaryKey personPrimaryKey, EditRolesViewModel viewModel)
        {
            var person = personPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            viewModel.UpdateModel(person, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditRolesViewModel viewModel)
        {
            var rolesAsSelectListItems = Role.All.ToSelectListWithEmptyFirstRow(x => x.RoleID.ToString(CultureInfo.InvariantCulture), x => x.RoleDisplayName);
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

        private PartialViewResult ViewDelete(Person person, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !person.HasDependentObjects() && person != CurrentPerson;
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete {0}?", person.FullNameFirstLastAndOrg)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Person", SitkaRoute<UserController>.BuildLinkFromExpression(x => x.Detail(person), "here"));

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
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
            person.DeletePerson();
            return new ModalDialogFormJsonResult();
        }

        [UserViewFeature]
        public ViewResult Detail(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var userNotificationGridSpec = new UserNotificationGridSpec();
            var userNotificationGridDataUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.UserNotificationsGridJsonData(personPrimaryKey));
            var basicProjectInfoGridSpec = new Views.Project.BasicProjectInfoGridSpec(CurrentPerson, false)
            {
                ObjectNameSingular = string.Format("Project where {0} is the Primary Contact", person.FullNameFirstLast),
                ObjectNamePlural = string.Format("Projects where {0} is the Primary Contact", person.FullNameFirstLast),
                SaveFiltersInCookie = true
            };
            const string basicProjectInfoGridName = "userProjectListGrid";
            var basicProjectInfoGridDataUrl = SitkaRoute<UserController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(person));
            var activateInactivateUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.ActivateInactivatePerson(person));
            var viewData = new DetailViewData(CurrentPerson,
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
            var gridSpec = new Views.Project.BasicProjectInfoGridSpec(CurrentPerson, false);
            var projectPersons = person.GetPrimaryContactProjects().OrderBy(x => x.DisplayName).ToList();
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
                    confirmMessage = string.Format(@"You cannot inactive user '{0}' because {1} is the primary contact for the following organizations: 
<ul>
{2}
</ul>", person.FullNameFirstLast, person.FirstName, string.Join("\r\n", person.PrimaryContactOrganizations.Select(x => string.Format("<li>{0}</li>", x.OrganizationName))));
                }
                else
                {
                    confirmMessage = string.Format("Are you sure you want to inactivate user '{0}'?", person.FullNameFirstLast);
                }
                var viewData = new ConfirmDialogFormViewData(confirmMessage, !isPrimaryContactForAnyOrganization);
                return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
            }
            else
            {
                confirmMessage = string.Format("Are you sure you want to activate user '{0}'?", person.FullNameFirstLast);
                var viewData = new ConfirmDialogFormViewData(confirmMessage, true);
                return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
            }
        }

        [HttpPost]
        [UserEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ActivateInactivatePerson(PersonPrimaryKey personPrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var person = personPrimaryKey.EntityObject;
            if (person.IsActive)
            {
                Check.Require(!person.OrganizationsWhereYouAreThePrimaryContactPerson.Any(),
                    string.Format(@"You cannot inactive user '{0}' because {1} is the primary contact for one or more organizations!", person.FullNameFirstLast, person.FirstName));
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
        [SitkaAdminFeature]
        public PartialViewResult PullUserFromKeystone()
        {
            var viewModel = new PullUserFromKeystoneViewModel();

            return ViewPullUserFromKeystone(viewModel);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult PullUserFromKeystone(PullUserFromKeystoneViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewPullUserFromKeystone(viewModel);
            }

            var keystoneClient = new KeystoneDataClient();

            UserProfile keystoneUser = keystoneClient.GetUserProfileByUsername(FirmaWebConfiguration.KeystoneWebServiceApplicationGuid, viewModel.LoginName);
            if (keystoneUser == null)
            {
                SetErrorForDisplay("Person not added. The User Name was not found in Keystone");
                return new ModalDialogFormJsonResult();    
            }
            
            if (!keystoneUser.OrganizationGuid.HasValue)
            {
                SetErrorForDisplay("Person not added. They do not have an Organization in Keystone");
            }

            KeystoneDataService.Organization keystoneOrganization = null;
            try
            {
                keystoneOrganization = keystoneClient.GetOrganization(keystoneUser.OrganizationGuid.Value);
            }
            catch (Exception)
            {
                SetErrorForDisplay("Person not added. Could not find their Organization in Keystone");
            }
                        
            var firmaOrganization = HttpRequestStorage.DatabaseEntities.Organizations.SingleOrDefault(x => x.OrganizationGuid == keystoneUser.OrganizationGuid);
            if (firmaOrganization == null)
            {
                firmaOrganization = new Organization(keystoneOrganization.FullName, Sector.Private, true)
                {
                    OrganizationGuid = keystoneOrganization.OrganizationGuid,
                    OrganizationAbbreviation = keystoneOrganization.ShortName,
                    OrganizationUrl = keystoneOrganization.URL
                };
                HttpRequestStorage.DatabaseEntities.AllOrganizations.Add(firmaOrganization);
            }

            var firmaPerson = HttpRequestStorage.DatabaseEntities.People.SingleOrDefault(x => x.PersonGuid == keystoneUser.UserGuid);
            if (firmaPerson != null)
            {
                firmaPerson.OrganizationID = firmaOrganization.OrganizationID;
            }
            else
            {
                firmaPerson = new Person(keystoneUser.UserGuid, keystoneUser.FirstName, keystoneUser.LastName, keystoneUser.Email, Role.Unassigned, DateTime.Now, true, firmaOrganization, false, keystoneUser.LoginName);
                HttpRequestStorage.DatabaseEntities.AllPeople.Add(firmaPerson);
            }

            HttpRequestStorage.DatabaseEntities.SaveChanges();

            SetMessageForDisplay(string.Format("{0} successfully added. You may want to <a href=\"{1}\">assign them a role</a>.", firmaPerson.GetFullNameFirstLastAndOrgAsUrl(), firmaPerson.GetDetailUrl()));

            return new ModalDialogFormJsonResult();

            
        }

        private PartialViewResult ViewPullUserFromKeystone(PullUserFromKeystoneViewModel viewModel)
        {
            var viewData = new PullUserFromKeystoneViewData();
            return RazorPartialView<PullUserFromKeystone, PullUserFromKeystoneViewData, PullUserFromKeystoneViewModel>(viewData, viewModel);
        }
    }

}
