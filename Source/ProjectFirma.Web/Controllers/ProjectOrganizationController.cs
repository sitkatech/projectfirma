using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectOrganization;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectOrganizationController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [ProjectOrganizationManageFeature]
        public PartialViewResult EditOrganizations(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditOrganizationsViewModel(project.GetAllProjectOrganizations());
            return ViewEditOrganizations(viewModel);
        }

        [HttpPost]
        [ProjectOrganizationManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditOrganizations(ProjectPrimaryKey projectPrimaryKey, EditOrganizationsViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditOrganizations(viewModel);
            }
            HttpRequestStorage.DatabaseEntities.ProjectFundingOrganizations.Load();
            var projectFundingOrganizations = HttpRequestStorage.DatabaseEntities.ProjectFundingOrganizations.Local;

            HttpRequestStorage.DatabaseEntities.ProjectImplementingOrganizations.Load();
            var projectImplementingOrganizations = HttpRequestStorage.DatabaseEntities.ProjectImplementingOrganizations.Local;

            viewModel.UpdateModel(project, projectFundingOrganizations, projectImplementingOrganizations);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditOrganizations(EditOrganizationsViewModel viewModel)
        {
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            var allPeople = HttpRequestStorage.DatabaseEntities.People.ToList().OrderBy(p => p.FullNameFirstLastAndOrg).ToList();
            var viewData = new EditOrganizationsViewData(allOrganizations, allPeople);
            return RazorPartialView<EditOrganizations, EditOrganizationsViewData, EditOrganizationsViewModel>(viewData, viewModel);
        }
    }
}