using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.Project
{
    public class FiveYearListViewData : EIPViewData
    {
        public readonly bool HasProposedProjectPermissions;
        public readonly BasicProjectInfoGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly string ProposeNewProjectUrl;
        public FiveYearListViewData(Person currentPerson, ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            HasProposedProjectPermissions = new ProposedProjectCreateNewFeature().HasPermissionByPerson(currentPerson);
            ProposeNewProjectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(tc => tc.Instructions(null));

            PageTitle = "5-Year Project List";

            GridName = "fiveYearListGrid";
            GridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true) { ObjectNameSingular = "5-Year List Project", ObjectNamePlural = "5-Year List Projects", SaveFiltersInCookie = true };
            
            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.FiveYearListGridJsonData());

        }
    }
}