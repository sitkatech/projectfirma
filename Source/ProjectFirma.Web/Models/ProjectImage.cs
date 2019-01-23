/*-----------------------------------------------------------------------
<copyright file="ProjectImage.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectImage : IFileResourcePhoto, IAuditableEntity
    {
        public ProjectImage(Project project, bool userHasPermissionToSetKeyPhoto)
            : this(ModelObjectHelpers.NotYetAssignedID, project.ProjectID, ProjectImageTiming.Unknown.ProjectImageTimingID, string.Empty, string.Empty, false, false)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Project = project;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor

            // If we are the only picture for this Project so far, it must be the key image -- so long as we have permission to set key photos.
            if (userHasPermissionToSetKeyPhoto && !project.ProjectImages.Any())
            {
                IsKeyPhoto = true;
            }

            // If they don't have permission, it's definitely NOT the key photo, no matter what.
            if (!userHasPermissionToSetKeyPhoto)
            {
                IsKeyPhoto = false;
            }
        }

        public DateTime GetCreateDate() => FileResource.CreateDate;

        public string GetDeleteUrl()
        {
            return ProjectImageModelExtensions.GetDeleteUrl(this);
        }

        public string GetCaptionOnFullView()
        {
            var creditString = string.IsNullOrWhiteSpace(Credit) ? string.Empty : $"\r\nCredit: {Credit}";
            return $"{GetCaptionOnGallery()}{creditString}";
        }

        public string GetCaptionOnGallery() =>
            $"{Caption}\r\n(Timing: {ProjectImageTiming.ProjectImageTimingDisplayName}) {FileResource.FileResourceDataLengthString}";

        public string GetPhotoUrl() => FileResource.FileResourceUrl;

        public string GetPhotoUrlScaledThumbnail() => FileResource.FileResourceUrlScaledThumbnail(150);
        public string GetPhotoUrlLargeScaledThumbnail() => FileResource.FileResourceUrlScaledThumbnail(200);

        public string GetPhotoUrlScaledForPrint() => FileResource.FileResourceUrlScaledForPrint;

        public string GetEditUrl()
        {
            return ProjectImageModelExtensions.GetEditUrl(this);
        }

        public void SetAdditionalCssClasses(List<string> value)
        {
            _additionalCssClasses = value;
        }

        public List<string> GetAdditionalCssClasses()
        {
            return _additionalCssClasses;
        }

        private object _orderBy;
        private List<string> _additionalCssClasses = new List<string>();

        public void SetOrderBy(object value) => _orderBy = value;

        public object GetOrderBy() => _orderBy ?? GetCaptionOnFullView();

        public void SetAsKeyPhoto()
        {
            SetAsKeyPhoto(Project.ProjectImages.Where(x => x.ProjectImageID != ProjectImageID).ToList());
        }

        public void SetAsKeyPhoto(List<ProjectImage> projectImagesToSetAsNotTheKeyPhoto)
        {
            IsKeyPhoto = true;
            projectImagesToSetAsNotTheKeyPhoto.ForEach(x => x.IsKeyPhoto = false);
        }

        public string GetAuditDescriptionString()
        {
            return $"Project: {ProjectID}, Image: {Caption}";
        }

        public int? GetEntityImageIDAsNullable() => ProjectImageID;
    }
}
