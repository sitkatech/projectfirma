using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PhotosViewData : ProjectUpdateViewData
    {
        public readonly ImageGalleryViewData ImageGalleryViewData;
        public readonly string RefreshUrl;
        public readonly string DiffUrl;

        public PhotosViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, UpdateStatus updateStatus) : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.Photos, updateStatus)
        {
            var newPhotoForProjectUrl = SitkaRoute<ProjectImageUpdateController>.BuildUrlFromExpression(x => x.New(projectUpdateBatch));
            var selectKeyImageUrl = IsEditable ? SitkaRoute<ProjectImageUpdateController>.BuildUrlFromExpression(x => x.SetKeyPhoto(UrlTemplate.Parameter1Int)) : string.Empty;
            ImageGalleryViewData = new ImageGalleryViewData(currentPerson,
                string.Format("ProjectImages{0}", projectUpdateBatch.Project.ProjectID),
                projectUpdateBatch.ProjectImageUpdates,
                IsEditable,
                newPhotoForProjectUrl,
                selectKeyImageUrl,
                true,
                x => x.CaptionOnFullView,
                "Photo");
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshPhotos(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffPhotos(projectUpdateBatch.Project));
        }
    }
}