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

using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class LocationSimpleViewData : ProjectUpdateViewData
    {
        public ProjectLocationSimpleViewData ProjectLocationSimpleViewData { get; }
        public ProjectLocationSummaryViewData ProjectLocationSummaryViewData { get; }
        public string RefreshUrl { get; }
        public SectionCommentsViewData SectionCommentsViewData { get; }

        public LocationSimpleViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.ProjectUpdate projectUpdate,
            ProjectLocationSimpleViewData projectLocationSimpleViewData,
            ProjectLocationSummaryViewData projectLocationSummaryViewData,
            LocationSimpleValidationResult locationSimpleValidationResult, ProjectUpdateStatus projectUpdateStatus) 
            : base(currentFirmaSession, projectUpdate.ProjectUpdateBatch, projectUpdateStatus,
                    locationSimpleValidationResult.GetWarningMessages(),
                    ProjectUpdateSection.LocationSimple.ProjectUpdateSectionDisplayName)
        {
            ProjectLocationSimpleViewData = projectLocationSimpleViewData;
            ProjectLocationSummaryViewData = projectLocationSummaryViewData;
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x =>
                x.RefreshProjectLocationSimple(projectUpdate.ProjectUpdateBatch.Project));
            SectionCommentsViewData = new SectionCommentsViewData(
                projectUpdate.ProjectUpdateBatch.LocationSimpleComment, projectUpdate.ProjectUpdateBatch.IsReturned());
            ValidationWarnings = locationSimpleValidationResult.GetWarningMessages();
        }
    }
}
