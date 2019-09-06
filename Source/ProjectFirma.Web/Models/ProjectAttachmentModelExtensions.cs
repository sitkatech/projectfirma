using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
{
    public static class ProjectAttachmentModelExtensions
    {
        public static string GetDeleteUrl(this ProjectAttachment projectAttachment)
        {
            return SitkaRoute<ProjectAttachmentController>.BuildUrlFromExpression(x =>
                x.Delete(projectAttachment.ProjectAttachmentID));
        }

        public static string GetEditUrl(this ProjectAttachment projectAttachment)
        {
            return SitkaRoute<ProjectAttachmentController>.BuildUrlFromExpression(x =>
                x.Edit(projectAttachment.ProjectAttachmentID));
        }
    }
}