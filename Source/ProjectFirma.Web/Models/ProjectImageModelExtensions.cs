using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class ProjectImageModelExtensions
    {
        public static string GetEditUrl(ProjectImage projectImage)
        {
            return SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.Edit(projectImage.ProjectImageID));
        }

        public static string GetDeleteUrl(ProjectImage projectImage)
        {
            return SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.DeleteProjectImage(projectImage.ProjectImageID));
        }
    }
}