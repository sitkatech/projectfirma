/*-----------------------------------------------------------------------
<copyright file="PhotosViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PhotosViewData : ProjectUpdateViewData
    {
        public readonly ImageGalleryViewData ImageGalleryViewData;
        public readonly string RefreshUrl;
        public readonly string DiffUrl;

        public PhotosViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, UpdateStatus updateStatus) : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.Photos, updateStatus)
        {
            var newPhotoForProjectUrl = SitkaRoute<ProjectImageUpdateController>.BuildUrlFromExpression(x => x.New(projectUpdateBatch));
            var selectKeyImageUrl = IsEditable ? SitkaRoute<ProjectImageUpdateController>.BuildUrlFromExpression(x => x.SetKeyPhoto(UrlTemplate.Parameter1Int)) : string.Empty;
            ImageGalleryViewData = new ImageGalleryViewData(currentPerson,
                string.Format("ProjectImages{0}", projectUpdateBatch.Project.ProjectID),
                projectUpdateBatch.ProjectImageUpdates,
                IsEditable,
                newPhotoForProjectUrl,
                selectKeyImageUrl,
                true,
                x => x.CaptionOnFullView,
                "Photo");
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshPhotos(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffPhotos(projectUpdateBatch.Project));
        }
    }
}
