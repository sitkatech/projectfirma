using System.Collections.Generic;

namespace ProjectFirma.Web.Views.Shared.ProjectTimeline
{
    public class ProjectStatusLegendDisplayViewData : FirmaUserControlViewData
    {
        public List<ProjectFirmaModels.Models.ProjectStatus> ProjectStatuses { get; }
        public ProjectStatusLegendDisplayViewData(List<ProjectFirmaModels.Models.ProjectStatus> projectStatuses)
        {
            ProjectStatuses = projectStatuses;
        }
    }
}