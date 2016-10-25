using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Project
{
    public class CompletedListViewData : FirmaViewData
    {
        public readonly BasicProjectInfoGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public CompletedListViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = "Completed Project List";

            GridName = "CompletedListGrid";
            GridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true) { ObjectNameSingular = "Completed Project", ObjectNamePlural = "Completed Projects", SaveFiltersInCookie = true };

            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.CompletedListGridJsonData());
        }
    }
}