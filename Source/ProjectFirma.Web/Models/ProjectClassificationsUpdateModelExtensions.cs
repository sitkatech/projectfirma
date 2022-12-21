using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectClassificationsUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch, List<ClassificationSystem> classificationSystems)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectClassificationUpdates = project.ProjectClassifications.Select(x => new ProjectClassificationUpdate(projectUpdateBatch, x.Classification){ProjectClassificationUpdateNotes = x.ProjectClassificationNotes}).ToList();
            projectUpdateBatch.ProjectUpdateBatchClassificationSystems = classificationSystems.Select(x => new ProjectUpdateBatchClassificationSystem(projectUpdateBatch, x)).ToList();
        }

        public static void RefreshForClassificationSystemFromProject(ProjectUpdateBatch projectUpdateBatch, ClassificationSystem classificationSystem)
        {
            var project = projectUpdateBatch.Project;
            var projectClassificationUpdates = project.ProjectClassifications
                .Where(x => x.Classification.ClassificationSystemID == classificationSystem.ClassificationSystemID)
                .Select(x => new ProjectClassificationUpdate(projectUpdateBatch, x.Classification)
                    {ProjectClassificationUpdateNotes = x.ProjectClassificationNotes}).ToList();
            projectUpdateBatch.ProjectClassificationUpdates.AddAll(projectClassificationUpdates);
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