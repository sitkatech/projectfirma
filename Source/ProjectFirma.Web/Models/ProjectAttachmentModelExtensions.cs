using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirmaModels.Models
{
    public static class ProjectAttachmentModelExtensions
    {
        public static string GetDeleteUrl(this ProjectAttachment projectAttachment)
        {
            return DeleteUrlTemplate.ParameterReplace(projectAttachment.ProjectAttachmentID);
        }

        public static string GetDeleteUrl(this vProjectAttachment projectAttachment)
        {
            return DeleteUrlTemplate.ParameterReplace(projectAttachment.ProjectAttachmentID);
        }

        public static string GetEditUrl(this ProjectAttachment projectAttachment)
        {
            return EditUrlTemplate.ParameterReplace(projectAttachment.ProjectAttachmentID);
        }

        public static string GetEditUrl(this vProjectAttachment projectAttachment)
        {
            return EditUrlTemplate.ParameterReplace(projectAttachment.ProjectAttachmentID);
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate =
            new UrlTemplate<int>(SitkaRoute<ProjectAttachmentController>.BuildUrlFromExpression(x =>
                x.Delete(UrlTemplate.Parameter1Int)));

        public static readonly UrlTemplate<int> EditUrlTemplate =
            new UrlTemplate<int>(SitkaRoute<ProjectAttachmentController>.BuildUrlFromExpression(x =>
                x.Edit(UrlTemplate.Parameter1Int)));

     
    }
}