using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.LocalAuthentication
{
    public class LocalAuthLogonViewData : FirmaViewData
    {
        //public readonly ProjectFirmaModels.Models.Organization Organization;
        //public readonly string EditBoundaryUrl;
        //public readonly string ApproveGisUploadUrl;
        //public readonly string OrganizationDetailUrl;

        public LocalAuthLogonViewData(FirmaSession currentFirmaSession) : base(currentFirmaSession)
        {

            PageTitle = "Local Authentication Logon";

            /*
            Organization = organization;
            EditBoundaryUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditBoundary(organization));
            ApproveGisUploadUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.ApproveUploadGis(organization));
            OrganizationDetailUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Detail(organization, null));
            */
        }
    }
}
