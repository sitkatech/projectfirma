using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectStatusModelExtensions
    {
        public static string GetDeleteUrl(this ProjectStatus projectStatus)
        {
            return SitkaRoute<ProjectStatusController>.BuildUrlFromExpression(c => c.Delete(projectStatus.ProjectStatusID));
        }

        public static string GetEditUrl(this ProjectStatus projectStatus)
        {
            return SitkaRoute<ProjectStatusController>.BuildUrlFromExpression(c => c.Edit(projectStatus.ProjectStatusID));
        }
    }
}