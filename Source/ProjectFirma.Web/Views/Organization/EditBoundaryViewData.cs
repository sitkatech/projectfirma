using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Organization
{
    public class EditBoundaryViewData : FirmaViewData
    {
        public readonly ProjectFirmaModels.Models.Organization Organization;
        public readonly string EditBoundaryUrl;
        public readonly string ApproveGisUploadUrl;
        public readonly string OrganizationDetailUrl;

        public EditBoundaryViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Organization organization) : base(currentFirmaSession)
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
