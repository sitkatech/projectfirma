using System.Linq;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectClassificationsUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectClassificationUpdates = project.ProjectClassifications.Select(x => new ProjectClassificationUpdate(projectUpdateBatch, x.Classification){ProjectClassificationUpdateNotes = x.ProjectClassificationNotes}).ToList();
        }


        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var projectClassificationsFromProjectUpdate = projectUpdateBatch.ProjectClassificationUpdates
                .Select(x => new ProjectClassification(project.ProjectID, x.ClassificationID) {ProjectClassificationNotes = x.ProjectClassificationUpdateNotes})
                .ToList();

            var existingProjectClassifications = project.ProjectClassifications.ToList();
            existingProjectClassifications.Merge(projectClassificationsFromProjectUpdate,
                (a, b) => a.ProjectID == b.ProjectID && a.ClassificationID == b.ClassificationID, databaseEntities);
        }

    }
}