using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.Project
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