using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class ProjectNoteUpdateModelExtensions
    {
        public static string GetDeleteUrlImpl(ProjectNoteUpdate projectNoteUpdate)
        {
            return SitkaRoute<ProjectNoteUpdateController>.BuildUrlFromExpression(c => c.Delete(projectNoteUpdate.ProjectNoteUpdateID));
        }

        public static string GetEditUrlImpl(ProjectNoteUpdate projectNoteUpdate)
        {
            return SitkaRoute<ProjectNoteUpdateController>.BuildUrlFromExpression(c => c.Edit(projectNoteUpdate.ProjectNoteUpdateID));
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectNoteUpdates =
                project.ProjectNotes.Select(
                    pn => new ProjectNoteUpdate(projectUpdateBatch, pn.Note, pn.CreateDate) {CreatePerson = pn.CreatePerson, UpdateDate = pn.UpdateDate, UpdatePerson = pn.UpdatePerson}).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectNote> allProjectNotes)
        {
            var project = projectUpdateBatch.Project;
            var projectNotesFromProjectUpdate =
                projectUpdateBatch.ProjectNoteUpdates.Select(
                    x => new ProjectNote(project.ProjectID, x.Note, x.CreateDate) {CreatePersonID = x.CreatePersonID, UpdateDate = x.UpdateDate, UpdatePersonID = x.UpdatePersonID}).ToList();
            project.ProjectNotes.Merge(projectNotesFromProjectUpdate, allProjectNotes, (x, y) => x.ProjectID == y.ProjectID && x.Note == y.Note);
        }
    }
}