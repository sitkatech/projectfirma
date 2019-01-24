using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectGeospatialAreaTypeNoteUpdate : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"GeospatialAreaType: {GeospatialAreaTypeID}, {Models.FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update Batch: {ProjectUpdateBatchID}";
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            var projectGeospatialAreaTypeNoteUpdates = project.ProjectGeospatialAreaTypeNotes.Select(
                projectGeospatialAreaTypeNote => new ProjectGeospatialAreaTypeNoteUpdate(projectUpdateBatch, projectGeospatialAreaTypeNote.GeospatialAreaType, projectGeospatialAreaTypeNote.Notes)).ToList();
            projectUpdateBatch.ProjectGeospatialAreaTypeNoteUpdates = projectGeospatialAreaTypeNoteUpdates;
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectGeospatialAreaTypeNote> allProjectGeospatialAreaTypeNotes)
        {
            var project = projectUpdateBatch.Project;
            var currentProjectGeospatialAreaTypeNotes = project.ProjectGeospatialAreaTypeNotes.ToList();
            currentProjectGeospatialAreaTypeNotes.ForEach(projectGeospatialArea =>
            {
                allProjectGeospatialAreaTypeNotes.Remove(projectGeospatialArea);
            });
            currentProjectGeospatialAreaTypeNotes.Clear();

            if (projectUpdateBatch.ProjectGeospatialAreaTypeNoteUpdates.Any())
            {
                // Completely rebuild the list
                projectUpdateBatch.ProjectGeospatialAreaTypeNoteUpdates.ToList().ForEach(x =>
                {
                    var projectGeospatialAreaTypeNote = new ProjectGeospatialAreaTypeNote(project, x.GeospatialAreaType, x.Notes);
                    allProjectGeospatialAreaTypeNotes.Add(projectGeospatialAreaTypeNote);
                });
            }
        }
    }
}