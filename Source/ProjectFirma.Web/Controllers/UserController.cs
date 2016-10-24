using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.User;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class UserController : LakeTahoeInfoBaseController
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
            IndexGridSpec gridSpec;
            var persons = GetPersonsAndGridSpec(out gridSpec);
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Person>(persons, gridSpec);
            return gridJsonNetJObjectResult;
        }

        private static List<Person> GetPersonsAndGridSpec(out IndexGridSpec gridSpec)
        {
            gridSpec = new IndexGridSpec();
            return HttpRequestStorage.DatabaseEntities.People.ToList().OrderBy(x => x.FullNameLastFirst).ToList();
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
            var eipRolesAsSelectListItems = EIPRole.All.ToSelectListWithEmptyFirstRow(x => x.RoleID.ToString(CultureInfo.InvariantCulture), x => x.RoleDisplayName);
            var ltInfoRolesAsSelectListItems = LTInfoRole.All.ToSelectListWithEmptyFirstRow(x => x.RoleID.ToString(CultureInfo.InvariantCulture), x => x.RoleDisplayName);
            var viewData = new EditRolesViewData(eipRolesAsSelectListItems, ltInfoRolesAsSelectListItems);
            return RazorPartialView<EditRoles, EditRolesViewData, EditRolesViewModel>(viewData, viewModel);
        }

        [UserViewFeature]
        public ViewResult Summary(PersonPrimaryKey personPrimaryKey)
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
            var viewData = new SummaryViewData(CurrentPerson, person, basicProjectInfoGridSpec, basicProjectInfoGridName, basicProjectInfoGridDataUrl, userNotificationGridSpec, "userNotifications", userNotificationGridDataUrl, activateInactivateUrl);
            return RazorView<Summary, SummaryViewData>(viewData);
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
                foreach (var personAreaEntry in person.PersonAreas)
                {
                    personAreaEntry.ReceiveSupportEmails = false;
                }
            }
            person.IsActive = !person.IsActive;
            return new ModalDialogFormJsonResult();
        }
    }
}