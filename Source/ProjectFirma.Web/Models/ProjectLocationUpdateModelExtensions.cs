using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectLocationUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            // Using ProjectLocationUpdates here because locations are being updated
            projectUpdateBatch.ProjectLocationUpdates =
                project.GetProjectLocationDetailedAsProjectLocations(true).Select(
                    projectLocationToClone => new ProjectLocationUpdate(projectUpdateBatch,
                        projectLocationToClone.ProjectLocationGeometry, projectLocationToClone.Annotation)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch,
            DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var currentProjectLocations = project.GetProjectLocationDetailedAsProjectLocations(true).ToList();
            currentProjectLocations.ForEach(x => x.DeleteFull(databaseEntities));
            currentProjectLocations.Clear();

            if (projectUpdateBatch.ProjectUpdate.HasProjectLocationDetailed(true)){
                // Completely rebuild the list
                projectUpdateBatch.ProjectUpdate.GetProjectLocationDetailedAsProjectLocationUpdate(true).ForEach(x =>
                {
                    var projectLocation = new ProjectLocation(project, x.ProjectLocationUpdateGeometry, x.Annotation);
                    databaseEntities.AllProjectLocations.Add(projectLocation);
                });
            }
        }
    }
}