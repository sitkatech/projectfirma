using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class ApproveUploadGisViewData : FirmaViewData

    {
        public readonly MapInitJson MapInitJson;
        public readonly string OrganizationDetailUrl;

        public ApproveUploadGisViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Organization organization,
            MapInitJson mapInitJson) : base(currentFirmaSession)
        {
            MapInitJson = mapInitJson;
            OrganizationDetailUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Detail(organization));
        }
    }
}
