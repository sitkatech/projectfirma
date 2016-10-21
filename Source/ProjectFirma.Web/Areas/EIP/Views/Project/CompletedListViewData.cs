using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.Project
{
    public class CompletedListViewData : EIPViewData
    {
        public readonly BasicProjectInfoGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public CompletedListViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Completed Project List";

            GridName = "CompletedListGrid";
            GridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true) { ObjectNameSingular = "Completed Project", ObjectNamePlural = "Completed Projects", SaveFiltersInCookie = true };

            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.CompletedListGridJsonData());
        }
    }
}