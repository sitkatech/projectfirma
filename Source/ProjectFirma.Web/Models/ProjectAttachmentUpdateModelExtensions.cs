using System;
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
                    po =>
                    {
                        var currentFileResource = po.Attachment;
                        var newFileResource = new FileResourceInfo(currentFileResource.FileResourceMimeType,
                            currentFileResource.OriginalBaseFilename,
                            currentFileResource.OriginalFileExtension,
                            Guid.NewGuid(),
                            currentFileResource.CreatePerson,
                            currentFileResource.CreateDate);
                        newFileResource.FileResourceDatas.Add(new FileResourceData(newFileResource.FileResourceInfoID, currentFileResource.FileResourceData.Data));

                        return new ProjectAttachmentUpdate(projectUpdateBatch, newFileResource, po.AttachmentType,
                            po.DisplayName) {Description = po.Description};
                    }).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var projectAttachmentsFromProjectUpdate =
                projectUpdateBatch.ProjectAttachmentUpdates.Select(
                    x => new ProjectAttachment(project.ProjectID, x.AttachmentID, x.AttachmentTypeID, x.DisplayName){Description = x.Description}).ToList();
            project.ProjectAttachments.Merge(projectAttachmentsFromProjectUpdate,
                (x, y) => x.ProjectID == y.ProjectID && x.AttachmentID == y.AttachmentID, (x, y) =>
                {
                    x.Description = y.Description;
                    x.DisplayName = y.DisplayName;
                    x.AttachmentTypeID = y.AttachmentTypeID;
                }, databaseEntities);
        }
    }
}