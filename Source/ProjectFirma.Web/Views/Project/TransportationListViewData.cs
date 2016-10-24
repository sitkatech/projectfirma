using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Project
{
    public class TransportationListViewData : EIPViewData
    {
        public readonly TransportationListProjectGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public TransportationListViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Transportation Project List";

            GridSpec = new TransportationListProjectGridSpec(currentPerson)
            {
                ObjectNameSingular = "Transportation Project",
                ObjectNamePlural = "Transportation Projects",
                SaveFiltersInCookie = true
            };

            GridName = "transportationProjectListGrid";
            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.TransportationListGridJsonData());
        }
    }
}