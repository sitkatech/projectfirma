using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.MonitoringProgramPartner;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class MonitoringProgramPartnerController : FirmaBaseController
    {
        [HttpGet]
        [MonitoringProgramManageFeature]
        public PartialViewResult Edit(MonitoringProgramPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var projectOrganizationSimples = project.MonitoringProgramPartners.Select(x => new MonitoringProgramPartnerSimple(x)).ToList();
            var viewModel = new EditMonitoringProgramPartnersViewModel(projectOrganizationSimples);
            return ViewEdit(project, viewModel);
        }

        [HttpPost]
        [MonitoringProgramManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(MonitoringProgramPrimaryKey projectPrimaryKey, EditMonitoringProgramPartnersViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(project, viewModel);
            }
            var currentMonitoringProgramPartners = project.MonitoringProgramPartners.ToList();
            HttpRequestStorage.DatabaseEntities.MonitoringProgramPartners.Load();
            var allMonitoringProgramPartners = HttpRequestStorage.DatabaseEntities.MonitoringProgramPartners.Local;
            viewModel.UpdateModel(currentMonitoringProgramPartners, allMonitoringProgramPartners);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(MonitoringProgram project, EditMonitoringProgramPartnersViewModel viewModel)
        {
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList().Select(x => new OrganizationSimple(x)).OrderBy(p => p.OrganizationName).ToList();
            var viewData = new EditMonitoringProgramPartnersViewData(project, allOrganizations);
            return RazorPartialView<EditMonitoringProgramPartners, EditMonitoringProgramPartnersViewData, EditMonitoringProgramPartnersViewModel>(viewData, viewModel);
        }
    }
}