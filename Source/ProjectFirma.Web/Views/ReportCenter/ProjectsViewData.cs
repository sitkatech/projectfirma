using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ReportCenter
{
    public class ProjectsViewData : FirmaViewData
    {
        public ReportTemplateGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public bool HasManageReportTemplatePermissions { get; }
        public string NewUrl { get; }

        public ProjectsViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            GridSpec = new ReportTemplateGridSpec(new ReportTemplateViewListFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                ObjectNameSingular = "Report Template",
                ObjectNamePlural = "Report Templates",
                SaveFiltersInCookie = true
            };
            GridName = "ReportCenterProjects";
            PageTitle = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}";
            GridDataUrl = SitkaRoute<ReportCenterController>.BuildUrlFromExpression(rcc => rcc.IndexGridJsonData());
            HasManageReportTemplatePermissions = new ReportTemplateManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            NewUrl = SitkaRoute<ReportCenterController>.BuildUrlFromExpression(t => t.New());
        }
    }
}