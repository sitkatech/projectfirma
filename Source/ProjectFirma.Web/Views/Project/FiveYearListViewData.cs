using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Project
{
    public class FiveYearListViewData : FirmaViewData
    {
        public readonly bool HasProposedProjectPermissions;
        public readonly BasicProjectInfoGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly string ProposeNewProjectUrl;
        public FiveYearListViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
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