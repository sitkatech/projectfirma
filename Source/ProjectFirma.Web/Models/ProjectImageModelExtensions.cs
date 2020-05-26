using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectImageModelExtensions
    {
        public static string GetEditUrl(this ProjectImage projectImage)
        {
            return SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.Edit(projectImage.ProjectImageID));
        }

        public static string GetDeleteUrl(this ProjectImage projectImage)
        {
            return SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.DeleteProjectImage(projectImage.ProjectImageID));
        }

        public static string GetPhotoUrl(this ProjectImage projectImage) => projectImage.FileResourceInfo.GetFileResourceUrl();

        public static string GetPhotoUrlScaledThumbnail(this ProjectImage projectImage) => projectImage.FileResourceInfo.FileResourceUrlScaledThumbnail(150);
        public static string GetPhotoUrlLargeScaledThumbnail(this ProjectImage projectImage) => projectImage.FileResourceInfo.FileResourceUrlScaledThumbnail(200);

        public static string GetPhotoUrlScaledForPrint(this ProjectImage projectImage) => projectImage.FileResourceInfo.GetFileResourceUrlScaledForPrint();

        public static string GetCaptionOnFullView(this ProjectImage projectImage)
        {
            var creditString = string.IsNullOrWhiteSpace(projectImage.Credit) ? string.Empty : $"\r\nCredit: {projectImage.Credit}";
            return $"{projectImage.GetCaptionOnGallery()}{creditString}";
        }

        public static string GetCaptionOnGallery(this ProjectImage projectImage) =>
            $"{projectImage.Caption}\r\n(Timing: {projectImage.ProjectImageTiming.ProjectImageTimingDisplayName}) {projectImage.FileResourceInfo.GetFileResourceDataLengthString()}";


    }
}