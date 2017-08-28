/*-----------------------------------------------------------------------
<copyright file="LocationSimpleViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
    public class LocationSimpleViewData : ProjectUpdateViewData
    {
        public readonly ProjectLocationSimpleViewData ProjectLocationSimpleViewData;
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly string RefreshUrl;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly List<string> ValidationWarnings;

        public LocationSimpleViewData(Person currentPerson,
            Models.ProjectUpdate projectUpdate,
            ProjectLocationSimpleViewData projectLocationSimpleViewData,
            ProjectLocationSummaryViewData projectLocationSummaryViewData, LocationSimpleValidationResult locationSimpleValidationResult, UpdateStatus updateStatus) : base(currentPerson, projectUpdate.ProjectUpdateBatch, ProjectUpdateSectionEnum.LocationSimple, updateStatus)
        {
            ProjectLocationSimpleViewData = projectLocationSimpleViewData;
            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshProjectLocationSimple(projectUpdate.ProjectUpdateBatch.Project));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdate.ProjectUpdateBatch.LocationSimpleComment, projectUpdate.ProjectUpdateBatch.IsReturned);
            ValidationWarnings = locationSimpleValidationResult.GetWarningMessages();
        } 
    }
}
