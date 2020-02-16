using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectAttachmentUpdateModelExtensions
    {
        public static string GetDeleteUrl(this ProjectAttachmentUpdate projectAttachmentUpdate)
        {
            return SitkaRoute<ProjectAttachmentUpdateController>.BuildUrlFromExpression(x =>
                x.Delete(projectAttachmentUpdate.ProjectAttachmentUpdateID));
        }

        public static string GetEditUrl(this ProjectAttachmentUpdate projectAttachmentUpdate)
        {
            return SitkaRoute<ProjectAttachmentUpdateController>.BuildUrlFromExpression(x =>
                x.Edit(projectAttachmentUpdate.ProjectAttachmentUpdateID));
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectUpdate.PrimaryContactPersonID = project.PrimaryContactPersonID;
            projectUpdateBatch.ProjectAttachmentUpdates =
                project.ProjectAttachments.Select(
                    po => new ProjectAttachmentUpdate(projectUpdateBatch, po.Attachment, po.AttachmentType, po.DisplayName) { Description = po.Description}
                ).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var projectAttachmentsFromProjectUpdate =
                projectUpdateBatch.ProjectAttachmentUpdates.Select(
                    x => new ProjectAttachment(project.ProjectID, x.AttachmentID, x.AttachmentTypeID, x.DisplayName){Description = x.Description}).ToList();
            project.ProjectAttachments.Merge(projectAttachmentsFromProjectUpdate,
                (x, y) => x.ProjectID == y.ProjectID && x.AttachmentID == y.AttachmentID, databaseEntities);
        }
    }
}