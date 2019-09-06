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

using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PhotosViewData : ProjectUpdateViewData
    {
        public ImageGalleryViewData ImageGalleryViewData { get; }
        public string RefreshUrl { get; }
        public string DiffUrl { get; }
        public string ContinueUrl { get; }

        public PhotosViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ProjectUpdateStatus projectUpdateStatus) : base(currentPerson, projectUpdateBatch, projectUpdateStatus, new List<string>(), ProjectUpdateSection.Photos.ProjectUpdateSectionDisplayName)
        {
            var addNewImageUrl = SitkaRoute<ProjectImageUpdateController>.BuildUrlFromExpression(x => x.New(projectUpdateBatch));
            var selectKeyImageUrl = IsEditable ? SitkaRoute<ProjectImageUpdateController>.BuildUrlFromExpression(x => x.SetKeyPhoto(UrlTemplate.Parameter1Int)) : string.Empty;
            ImageGalleryViewData = new ImageGalleryViewData(currentPerson,
                $"ProjectImages{projectUpdateBatch.Project.ProjectID}",
                projectUpdateBatch.ProjectImageUpdates.Select(x => new FileResourcePhoto(x)),
                IsEditable,
                addNewImageUrl,
                selectKeyImageUrl,
                true,
                x => x.CaptionOnFullView,
                "Photo");
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshPhotos(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffPhotos(projectUpdateBatch.Project));
            ContinueUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.AttachmentsAndNotes(projectUpdateBatch.Project));
        }
    }
}
