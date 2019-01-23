using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static class ProjectUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var projectUpdate = new ProjectUpdate(projectUpdateBatch);
            HttpRequestStorage.DatabaseEntities.AllProjectUpdates.Add(projectUpdate);
        }

        public static string GetPlanningDesignStartYear(ProjectUpdate projectUpdate)
        {
            return projectUpdate.PlanningDesignStartYear.HasValue ? MultiTenantHelpers.FormatReportingYear(projectUpdate.PlanningDesignStartYear.Value) : null;
        }
    }
}