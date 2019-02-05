using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectNoteModelExtensions
    {
        public static string GetDeleteUrl(this ProjectNote projectNote)
        {
            return SitkaRoute<ProjectNoteController>.BuildUrlFromExpression(c => c.DeleteProjectNote(projectNote.ProjectNoteID));
        }

        public static string GetEditUrl(this ProjectNote projectNote)
        {
            return SitkaRoute<ProjectNoteController>.BuildUrlFromExpression(c => c.Edit(projectNote.ProjectNoteID));
        }
    }
}