using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditBoundaryViewData : FirmaViewData
    {
        public readonly Models.Organization Organization;
        public readonly string EditBoundaryUrl;
        public readonly string ApproveGisUploadUrl;
        public readonly string OrganizationDetailUrl;

        public EditBoundaryViewData(Person currentPerson, Models.Organization organization) : base(currentPerson)
        {
            PageTitle = "Edit Organization Boundary";

            Organization = organization;
            EditBoundaryUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditBoundary(organization));
            ApproveGisUploadUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.ApproveUploadGis(organization));
            OrganizationDetailUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Detail(organization));
        }
    }
}
