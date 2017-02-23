/*-----------------------------------------------------------------------
<copyright file="ProjectImageUpdate.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectImageUpdate : IFileResourcePhoto
    {
        public ProjectImageUpdate(ProjectUpdateBatch projectUpdateBatch, bool userHasPermissionToSetKeyPhoto)
            : this(ModelObjectHelpers.NotYetAssignedID, null, projectUpdateBatch.ProjectUpdateBatchID, ProjectImageTiming.Unknown.ProjectImageTimingID, string.Empty, string.Empty, false, false, null)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            ProjectUpdateBatch = projectUpdateBatch;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor

            // If we are the only picture for this Project so far, it must be the key image -- so long as we have permission to set key photos.
            if (userHasPermissionToSetKeyPhoto && !projectUpdateBatch.ProjectImageUpdates.Any())
            {
                IsKeyPhoto = true;
            }

            // If they don't have permission, it's definitely NOT the key photo, no matter what.
            if (!userHasPermissionToSetKeyPhoto)
            {
                IsKeyPhoto = false;
            }
        }

        public int? EntityImageIDAsNullable
        {
            get { return ProjectImageID; } 
        }
        public DateTime CreateDate
        {
            get { return FileResource.CreateDate; }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<ProjectImageUpdateController>.BuildUrlFromExpression(x => x.DeleteProjectImageUpdate(ProjectImageUpdateID)); }
        }

        public string CaptionOnFullView
        {
            get
            {
                var creditString = string.IsNullOrWhiteSpace(Credit) ? string.Empty : string.Format("\r\nCredit: {0}", Credit);
                return string.Format("{0}{1}", CaptionOnGallery, creditString);
            }
        }

        public string CaptionOnGallery
        {
            get { return string.Format("{0}\r\n(Timing: {1}) {2}", Caption, ProjectImageTiming.ProjectImageTimingDisplayName, FileResource.FileResourceDataLengthString); }
        }

        public string PhotoUrl
        {
            get { return FileResource.FileResourceUrl; }
        }

        public string PhotoUrlScaledThumbnail
        {
            get { return FileResource.FileResourceUrlScaledThumbnail; }
        }

        public string PhotoUrlScaledForPrint
        {
            get { return FileResource.FileResourceUrlScaledForPrint; }
        }

        public string EditUrl
        {
            get { return SitkaRoute<ProjectImageUpdateController>.BuildUrlFromExpression(x => x.Edit(ProjectImageUpdateID)); }
        }

        private List<string> _additionalCssClasses = new List<string>(); 
        public List<string> AdditionalCssClasses
        {
            get { return _additionalCssClasses; }
            set { _additionalCssClasses = value; }
        }
        private object _orderBy;
        public object OrderBy
        {
            get { return _orderBy ?? CaptionOnFullView; }
            set { _orderBy = value; }
        }

        public void SetAsKeyPhoto()
        {
            SetAsKeyPhoto(ProjectUpdateBatch.ProjectImageUpdates.Where(x => x.ProjectImageUpdateID != ProjectImageUpdateID).ToList());
        }

        public void SetAsKeyPhoto(List<ProjectImageUpdate> projectImageUpdatesToSetAsNotTheKeyPhoto)
        {
            IsKeyPhoto = true;
            projectImageUpdatesToSetAsNotTheKeyPhoto.ForEach(x => x.IsKeyPhoto = false);
        }

        public bool IsPersonTheCreator(Person person)
        {
            return FileResource.CreatePerson != null && person != null && person.PersonID == FileResource.CreatePersonID;
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

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectImage> allProjectImages)
        {
            var project = projectUpdateBatch.Project;
            var projectImageUpdatesToCommit = new List<ProjectImage>();

            if (projectUpdateBatch.ProjectImageUpdates.Any())
            {
                // Completely rebuild the list
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
                allProjectImages,
                (x, y) => x.ProjectImageID == y.ProjectImageID,
                (x, y) =>
                {
                    x.ProjectImageTimingID = y.ProjectImageTimingID;
                    x.Caption = y.Caption;
                    x.Credit = y.Credit;
                    x.IsKeyPhoto = y.IsKeyPhoto;
                    x.ExcludeFromFactSheet = y.ExcludeFromFactSheet;
                });
        }
    }
}
