/*-----------------------------------------------------------------------
<copyright file="LocationDetailedViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class LocationDetailedViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly SectionCommentsViewData SectionCommentsViewData;

        public readonly ProjectLocationDetailViewData ProjectLocationDetailViewData;
        public readonly string UploadGisFileUrl;


        public LocationDetailedViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ProjectLocationDetailViewData projectLocationDetailViewData, string uploadGisFileUrl, UpdateStatus updateStatus)
            : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.LocationDetailed, updateStatus, new List<string>())
        {
            ProjectLocationDetailViewData = projectLocationDetailViewData;
            UploadGisFileUrl = uploadGisFileUrl;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshProjectLocationDetailed(projectUpdateBatch.Project));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.LocationDetailedComment, projectUpdateBatch.IsReturned);
        }
    }
}
