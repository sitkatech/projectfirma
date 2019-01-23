using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class ProjectNoteModelExtensions
    {
        public static string GetDeleteUrl(ProjectNote projectNote)
        {
            return SitkaRoute<ProjectNoteController>.BuildUrlFromExpression(c => c.DeleteProjectNote(projectNote.ProjectNoteID));
        }

        public static string GetEditUrl(ProjectNote projectNote)
        {
            return SitkaRoute<ProjectNoteController>.BuildUrlFromExpression(c => c.Edit(projectNote.ProjectNoteID));
        }
    }
}