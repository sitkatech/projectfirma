using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectProjectStatusExtensions
    {
        public static readonly UrlTemplate<int,int> EditProjectProjectStatusUrlTemplate = new UrlTemplate<int,int>(SitkaRoute<ProjectProjectStatusController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int,UrlTemplate.Parameter2Int)));
        public static string GetEditProjectProjectStatusUrl(this ProjectProjectStatus projectProjectStatus)
        {
            return EditProjectProjectStatusUrlTemplate.ParameterReplace(projectProjectStatus.ProjectID,projectProjectStatus.ProjectProjectStatusID);
        }

        public static readonly UrlTemplate<int,int> DeleteProjectProjectStatusUrlTemplate = new UrlTemplate<int,int>(SitkaRoute<ProjectProjectStatusController>.BuildUrlFromExpression(t => t.DeleteProjectProjectStatus(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int)));
        public static string GetDeleteProjectProjectStatusUrl(this ProjectProjectStatus projectProjectStatus)
        {
            return DeleteProjectProjectStatusUrlTemplate.ParameterReplace(projectProjectStatus.ProjectID, projectProjectStatus.ProjectProjectStatusID);
        }

        public static readonly UrlTemplate<int, int> ProjectProjectStatusDetailsUrlTemplate = new UrlTemplate<int, int>(SitkaRoute<ProjectProjectStatusController>.BuildUrlFromExpression(t => t.Details(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int)));
        public static string GetProjectProjectStatusDetailsUrl(this ProjectProjectStatus projectProjectStatus)
        {
            return ProjectProjectStatusDetailsUrlTemplate.ParameterReplace(projectProjectStatus.ProjectID, projectProjectStatus.ProjectProjectStatusID);
        }



        

    }
}