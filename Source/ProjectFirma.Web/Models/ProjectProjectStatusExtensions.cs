using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectProjectStatusExtensions
    {
        public static readonly UrlTemplate<int> EditProjectProjectStatusUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectProjectStatusController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int)));
        public static string GetEditProjectProjectStatusUrl(this ProjectProjectStatus projectProjectStatus)
        {
            return EditProjectProjectStatusUrlTemplate.ParameterReplace(projectProjectStatus.ProjectProjectStatusID);
        }

        public static readonly UrlTemplate<int> DeleteProjectProjectStatusUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectProjectStatusController>.BuildUrlFromExpression(t => t.DeleteProjectProjectStatus(UrlTemplate.Parameter1Int)));
        public static string GetDeleteProjectProjectStatusUrl(this ProjectProjectStatus projectProjectStatus)
        {
            return DeleteProjectProjectStatusUrlTemplate.ParameterReplace(projectProjectStatus.ProjectProjectStatusID);
        }

    }
}