/*-----------------------------------------------------------------------
<copyright file="ProjectImageUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

        public int? GetEntityImageIDAsNullable()
        {
            return ProjectImageID;
        }

        public DateTime GetCreateDate()
        {
            return FileResource.CreateDate;
        }

        public string GetDeleteUrl()
        {
            return ProjectImageUpdateModelExtensions.GetDeleteUrlImpl(this);
        }

        public string GetCaptionOnFullView()
        {
            var creditString = string.IsNullOrWhiteSpace(Credit) ? string.Empty : $"\r\nCredit: {Credit}";
            return $"{GetCaptionOnGallery()}{creditString}";
        }

        public string GetCaptionOnGallery()
        {
            return $"{Caption}\r\n(Timing: {ProjectImageTiming.ProjectImageTimingDisplayName}) {FileResource.FileResourceDataLengthString}";
        }

        public string GetPhotoUrl()
        {
            return FileResource.FileResourceUrl;
        }

        public string GetPhotoUrlScaledThumbnail()
        {
            return FileResource.FileResourceUrlScaledThumbnail(150);
        }

        public string GetEditUrl()
        {
            return ProjectImageUpdateModelExtensions.GetEditUrlImpl(this);
        }

        private List<string> _additionalCssClasses = new List<string>();

        public void SetAdditionalCssClasses(List<string> value)
        {
            _additionalCssClasses = value;
        }

        public List<string> GetAdditionalCssClasses()
        {
            return _additionalCssClasses;
        }

        private object _orderBy;

        public void SetOrderBy(object value)
        {
            _orderBy = value;
        }

        public object GetOrderBy()
        {
            return _orderBy ?? GetCaptionOnFullView();
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
    }
}
