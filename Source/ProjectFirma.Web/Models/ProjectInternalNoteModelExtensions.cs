using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class ProjectInternalNoteModelExtensions
    {
        public static string GetDeleteUrl(ProjectInternalNote projectInternalNote)
        {
            return SitkaRoute<ProjectInternalNoteController>.BuildUrlFromExpression(c => c.DeleteProjectInternalNote(projectInternalNote));
        }

        public static string GetEditUrl(ProjectInternalNote projectInternalNote)
        {
            return SitkaRoute<ProjectInternalNoteController>.BuildUrlFromExpression(c => c.Edit(projectInternalNote));
        }
    }
}