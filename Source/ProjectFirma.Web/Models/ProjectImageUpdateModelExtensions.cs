using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectImageUpdateModelExtensions
    {
        public static string GetDeleteUrl(this ProjectImageUpdate projectImageUpdate)
        {
            return SitkaRoute<ProjectImageUpdateController>.BuildUrlFromExpression(x =>
                x.DeleteProjectImageUpdate(projectImageUpdate.ProjectImageUpdateID));
        }

        public static string GetEditUrl(this ProjectImageUpdate projectImageUpdate)
        {
            return SitkaRoute<ProjectImageUpdateController>.BuildUrlFromExpression(x => x.Edit(projectImageUpdate.ProjectImageUpdateID));
        }

        public static string GetCaptionOnFullView(this ProjectImageUpdate projectImageUpdate)
        {
            var creditString = string.IsNullOrWhiteSpace(projectImageUpdate.Credit) ? string.Empty : $"\r\nCredit: {projectImageUpdate.Credit}";
            return $"{projectImageUpdate.GetCaptionOnGallery()}{creditString}";
        }

        public static string GetCaptionOnGallery(this ProjectImageUpdate projectImageUpdate)
        {
            return $"{projectImageUpdate.Caption}\r\n(Timing: {projectImageUpdate.ProjectImageTiming.ProjectImageTimingDisplayName}) {projectImageUpdate.FileResource.GetFileResourceDataLengthString()}";
        }

        public static string GetPhotoUrl(this ProjectImageUpdate projectImageUpdate)
        {
            return projectImageUpdate.FileResource.GetFileResourceUrl();
        }

        public static string GetPhotoUrlScaledThumbnail(this ProjectImageUpdate projectImageUpdate)
        {
            return projectImageUpdate.FileResource.FileResourceUrlScaledThumbnail(150);
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectImageUpdates = project.ProjectImages.Select(pn =>
            {
                var currentFileResource = pn.FileResource;
                var newFileResource = new FileResource(currentFileResource.FileResourceMimeType,
                    currentFileResource.OriginalBaseFilename,
                    currentFileResource.OriginalFileExtension,
                    Guid.NewGuid(),
                    currentFileResource.FileResourceData,
                    currentFileResource.CreatePerson,
                    currentFileResource.CreateDate);
                return new ProjectImageUpdate(projectUpdateBatch, pn.ProjectImageTiming, pn.Caption, pn.Credit, pn.IsKeyPhoto, pn.ExcludeFromFactSheet)
                {
                    FileResource = newFileResource,
                    ProjectImageID = pn.ProjectImageID
                
                };
            }).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var projectImageUpdatesToCommit = new List<ProjectImage>();

            if (projectUpdateBatch.ProjectImageUpdates.Any())
            {
                projectImageUpdatesToCommit = projectUpdateBatch.ProjectImageUpdates.Select(x =>
                {
                    var currentFileResource = x.FileResource;
                    return new ProjectImage(x.ProjectImageID ?? ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(),
                        currentFileResource.FileResourceID,
                        project.ProjectID,
                        x.ProjectImageTimingID,
                        x.Caption,
                        x.Credit,
                        x.IsKeyPhoto,
                        x.ExcludeFromFactSheet);
                }).ToList();
            }

            project.ProjectImages.Merge(projectImageUpdatesToCommit,
                (x, y) => x.ProjectImageID == y.ProjectImageID,
                (x, y) =>
                {
                    x.ProjectImageTimingID = y.ProjectImageTimingID;
                    x.Caption = y.Caption;
                    x.Credit = y.Credit;
                    x.IsKeyPhoto = y.IsKeyPhoto;
                    x.ExcludeFromFactSheet = y.ExcludeFromFactSheet;
                }, databaseEntities);
        }
    }
}