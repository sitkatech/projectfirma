using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditBoundaryViewData : FirmaViewData
    {
        public readonly string EditBoundaryUrl;
        public readonly string ApproveGisUploadUrl;

        public EditBoundaryViewData(Person currentPerson, Models.Organization organization) : base(currentPerson)
        {
            PageTitle = "Edit Organization Boundary";

            EditBoundaryUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditBoundary(organization));
            ApproveGisUploadUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.ApproveUploadGis(organization));
        }
    }
}
