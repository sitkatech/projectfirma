using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
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