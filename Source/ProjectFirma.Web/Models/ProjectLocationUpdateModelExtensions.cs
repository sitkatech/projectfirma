using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectLocationUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectLocationUpdates =
                project.ProjectLocations.Select(
                    projectLocationToClone => new ProjectLocationUpdate(projectUpdateBatch,
                        projectLocationToClone.ProjectLocationGeometry, projectLocationToClone.Annotation)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch,
            DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var currentProjectLocations = project.ProjectLocations.ToList();
            currentProjectLocations.ForEach(x => x.DeleteFull(databaseEntities));
            currentProjectLocations.Clear();

            if (projectUpdateBatch.ProjectLocationUpdates.Any())
            {
                // Completely rebuild the list
                projectUpdateBatch.ProjectLocationUpdates.ToList().ForEach(x =>
                {
                    var projectLocation = new ProjectLocation(project, x.ProjectLocationUpdateGeometry, x.Annotation);
                    databaseEntities.AllProjectLocations.Add(projectLocation);
                });
            }
        }
    }
}