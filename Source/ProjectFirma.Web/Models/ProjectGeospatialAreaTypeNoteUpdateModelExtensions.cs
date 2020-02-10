using System.Linq;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectGeospatialAreaTypeNoteUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            var projectGeospatialAreaTypeNoteUpdates = project.ProjectGeospatialAreaTypeNotes.Select(
                projectGeospatialAreaTypeNote => new ProjectGeospatialAreaTypeNoteUpdate(projectUpdateBatch, projectGeospatialAreaTypeNote.GeospatialAreaType, projectGeospatialAreaTypeNote.Notes)).ToList();
            projectUpdateBatch.ProjectGeospatialAreaTypeNoteUpdates = projectGeospatialAreaTypeNoteUpdates;
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var projectGeospatialAreaTypeNotesFromProjectUpdate =
                projectUpdateBatch.ProjectGeospatialAreaTypeNoteUpdates.Select(
                    x => new ProjectGeospatialAreaTypeNote(project.ProjectID, x.GeospatialAreaTypeID, x.Notes)).ToList();
            project.ProjectGeospatialAreaTypeNotes.Merge(projectGeospatialAreaTypeNotesFromProjectUpdate, (x, y) => x.ProjectID == y.ProjectID && x.GeospatialAreaTypeID == y.GeospatialAreaTypeID, (x, y) => x.Notes = y.Notes, databaseEntities);
        }
    }
}