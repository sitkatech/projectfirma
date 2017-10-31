/*-----------------------------------------------------------------------
<copyright file="LocationSimpleViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Views.ProjectCreate;
using ProjectFirma.Web.Views.Shared.ProjectWatershedControls;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class WatershedViewData : ProjectUpdateViewData
    {
        public readonly EditProjectWatershedsViewData EditProjectWatershedsViewData;
        public readonly ProjectLocationSummaryViewData ProjectLocationSummaryViewData;
        public readonly string RefreshUrl;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly List<string> ValidationWarnings;

        public WatershedViewData(Person currentPerson,
            Models.ProjectUpdate projectUpdate,
            EditProjectWatershedsViewData editProjectWatershedsViewData,
            ProjectLocationSummaryViewData projectLocationSummaryViewData, 
            WatershedValidationResult watershedValidationResult,
            UpdateStatus updateStatus) : base(currentPerson, projectUpdate.ProjectUpdateBatch, ProjectUpdateSectionEnum.Watershed, updateStatus)
        {
            EditProjectWatershedsViewData = editProjectWatershedsViewData;
            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshProjectWatershed(projectUpdate.ProjectUpdateBatch.Project));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdate.ProjectUpdateBatch.LocationSimpleComment, projectUpdate.ProjectUpdateBatch.IsReturned);
            ValidationWarnings = watershedValidationResult.GetWarningMessages();
        } 
    }
}
