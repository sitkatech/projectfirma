using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.Project
{
    public class IndexViewData : EIPViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Full Project List";

            GridSpec = new IndexGridSpec(currentPerson) {ObjectNameSingular = "Project", ObjectNamePlural = "Projects", SaveFiltersInCookie = true};
            if (new ProjectCreateNewFeature().HasPermissionByPerson(CurrentPerson))
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.New()), "New Project");
                GridSpec.CustomExcelDownloadUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.IndexExcelDownload());
            }
            GridName = "projectsGrid";
            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}