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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using LtInfo.Common.Models;
using LtInfo.Common.Views;

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

        public DateTime CreateDate => FileResource.CreateDate;

        public string DeleteUrl
        {
            get { return SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.DeleteProjectImage(ProjectImageID)); }
        }

        public string CaptionOnFullView
        {
            get
            {
                var creditString = string.IsNullOrWhiteSpace(Credit) ? string.Empty : $"\r\nCredit: {Credit}";
                return $"{CaptionOnGallery}{creditString}";
            }
        }

        public string CaptionOnGallery =>
            $"{Caption}\r\n(Timing: {ProjectImageTiming.ProjectImageTimingDisplayName}) {FileResource.FileResourceDataLengthString}";

        public string PhotoUrl => FileResource.FileResourceUrl;

        public string PhotoUrlScaledThumbnail => FileResource.FileResourceUrlScaledThumbnail;

        public string PhotoUrlScaledForPrint => FileResource.FileResourceUrlScaledForPrint;

        public string EditUrl
        {
            get { return SitkaRoute<ProjectImageController>.BuildUrlFromExpression(x => x.Edit(ProjectImageID)); }
        }

        private List<string> _additionalCssClasses = new List<string>();
        public List<string> AdditionalCssClasses
        {
            get => _additionalCssClasses;
            set => _additionalCssClasses = value;
        }

        private object _orderBy;
        public object OrderBy
        {
            get => _orderBy ?? CaptionOnFullView;
            set => _orderBy = value;
        }

        public void SetAsKeyPhoto()
        {
            SetAsKeyPhoto(Project.ProjectImages.Where(x => x.ProjectImageID != ProjectImageID).ToList());
        }

        public void SetAsKeyPhoto(List<ProjectImage> projectImagesToSetAsNotTheKeyPhoto)
        {
            IsKeyPhoto = true;
            projectImagesToSetAsNotTheKeyPhoto.ForEach(x => x.IsKeyPhoto = false);
        }

        public bool IsPersonTheCreator(Person person)
        {
            return FileResource.CreatePerson != null && person != null && person.PersonID == FileResource.CreatePersonID;
        }

        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.AllProjects.Find(ProjectID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                return $"Project: {projectName}, Image: {Caption}";
            }
        }

        public int? EntityImageIDAsNullable => ProjectImageID;
    }
}
