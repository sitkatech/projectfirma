using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectStatus
{
    public class ManageViewData : FirmaViewData
    {
        public ProjectStatusGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public string NewProjectStatusUrl { get; }
        public bool HasManagePermissions { get; }
        public string EditSortOrderUrl { get; }

        public ManageViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage neptunePage)
            : base(currentFirmaSession, neptunePage)
        {
            EntityName = "Project Status";
            PageTitle = $"Manage Statuses";

            NewProjectStatusUrl = SitkaRoute<ProjectStatusController>.BuildUrlFromExpression(t => t.New());
            GridSpec = new ProjectStatusGridSpec()
            {
                ObjectNameSingular = "Attribute Type",
                ObjectNamePlural = "Attribute Types",
                SaveFiltersInCookie = true
            };

            GridName = "projectStatusGrid";
            GridDataUrl = SitkaRoute<ProjectStatusController>.BuildUrlFromExpression(x => x.ProjectStatusGridJsonData());

            EditSortOrderUrl = SitkaRoute<ProjectStatusController>.BuildUrlFromExpression(x => x.EditSortOrder());
            
            HasManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
        }

        
    }
}
