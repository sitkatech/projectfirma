using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class ApproveUploadGisViewData : FirmaViewData

    {
        public readonly MapInitJson MapInitJson;
        public readonly string OrganizationDetailUrl;

        public ApproveUploadGisViewData(Person currentPerson, Models.Organization organization,
            MapInitJson mapInitJson) : base(currentPerson)
        {
            MapInitJson = mapInitJson;
            OrganizationDetailUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Detail(organization));
        }
    }
}
