using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Project
{
    public class ActiveProjectsListViewData : FirmaViewData
    {
        public readonly bool HasProposedProjectPermissions;
        public readonly BasicProjectInfoGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly string ProposeNewProjectUrl;
        public ActiveProjectsListViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage, false)
        {
            HasProposedProjectPermissions = new ProposedProjectCreateNewFeature().HasPermissionByPerson(currentPerson);
            ProposeNewProjectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(tc => tc.Instructions(null));

            PageTitle = "Active Project List";

            GridName = "activeProjectsListGrid";
            GridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true) { ObjectNameSingular = "Active Project", ObjectNamePlural = "Active Projects", SaveFiltersInCookie = true };
            
            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.ActiveProjectsListGridJsonData());

        }
    }
}