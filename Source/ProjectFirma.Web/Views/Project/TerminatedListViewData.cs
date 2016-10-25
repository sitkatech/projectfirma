using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Project
{
    public class TerminatedListViewData : FirmaViewData
    {
        public readonly BasicProjectInfoGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public TerminatedListViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Terminated Project List";

            GridName = "terminatedListGrid";
            GridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true) {ObjectNameSingular = "Terminated Project", ObjectNamePlural = "Terminated Projects", SaveFiltersInCookie = true};
          
            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.TerminatedListGridJsonData());
        }
    }
}