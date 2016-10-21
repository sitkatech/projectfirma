using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    public class LocationDetailedViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly SectionCommentsViewData SectionCommentsViewData;

        public readonly ProjectLocationDetailViewData ProjectLocationDetailViewData;
        public readonly string UploadGisFileUrl;


        public LocationDetailedViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ProjectLocationDetailViewData projectLocationDetailViewData, string uploadGisFileUrl, UpdateStatus updateStatus) : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.LocationDetailed, updateStatus)
        {
            ProjectLocationDetailViewData = projectLocationDetailViewData;
            UploadGisFileUrl = uploadGisFileUrl;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshProjectLocationDetailed(projectUpdateBatch.Project));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.LocationDetailedComment, projectUpdateBatch.IsReturned);
        }
    }
}