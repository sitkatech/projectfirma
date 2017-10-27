using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectWatershedUpdate : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var watershed = Watershed != null ? Watershed.DisplayName : ViewUtilities.NotFoundString;
                var projectUpdate = ProjectUpdateBatch != null ? ProjectUpdateBatch.ProjectUpdate.DisplayName : ViewUtilities.NotFoundString;
                return $"Watershed: {watershed}, Project Update: {projectUpdate}";
            }
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            var projectWatershedUpdates = project.ProjectWatersheds.Select(
                projectWatershedToClone => new ProjectWatershedUpdate(projectUpdateBatch, projectWatershedToClone.Watershed)).ToList();
            projectUpdateBatch.ProjectWatershedUpdates = projectWatershedUpdates;
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectWatershed> allProjectWatersheds)
        {
            var project = projectUpdateBatch.Project;
            var currentProjectWatersheds = project.ProjectWatersheds.ToList();
            currentProjectWatersheds.ForEach(projectWatershed =>
            {
                allProjectWatersheds.Remove(projectWatershed);
            });
            currentProjectWatersheds.Clear();

            if (projectUpdateBatch.ProjectWatershedUpdates.Any())
            {
                // Completely rebuild the list
                projectUpdateBatch.ProjectWatershedUpdates.ToList().ForEach(x =>
                {
                    var projectWatershed = new ProjectWatershed(project, x.Watershed);
                    allProjectWatersheds.Add(projectWatershed);
                });
            }
        }
    }
}