using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectInternalNoteModelExtensions
    {
        public static string GetDeleteUrl(this ProjectInternalNote projectInternalNote)
        {
            return SitkaRoute<ProjectInternalNoteController>.BuildUrlFromExpression(c => c.DeleteProjectInternalNote(projectInternalNote));
        }

        public static string GetEditUrl(this ProjectInternalNote projectInternalNote)
        {
            return SitkaRoute<ProjectInternalNoteController>.BuildUrlFromExpression(c => c.Edit(projectInternalNote));
        }
    }
}