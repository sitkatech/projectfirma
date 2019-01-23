using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectWorkflowSectionGrouping
    {
        public List<ProjectSectionSimple> GetProjectCreateSections(Project project, bool ignoreStatus)
        {
            return ProjectWorkflowSectionGroupingModelExtensions.GetProjectCreateSections(this, project, ignoreStatus);
        }

        public List<ProjectSectionSimple> GetProjectUpdateSections(ProjectUpdateBatch projectUpdateBatch,
            ProjectUpdateStatus projectUpdateStatus, bool ignoreStatus)
        {
            return ProjectWorkflowSectionGroupingModelExtensions.GetProjectUpdateSections(this, projectUpdateBatch, projectUpdateStatus, ignoreStatus);
        }
    }
}