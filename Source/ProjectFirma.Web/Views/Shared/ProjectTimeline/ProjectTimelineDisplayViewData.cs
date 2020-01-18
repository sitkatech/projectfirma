/*-----------------------------------------------------------------------
<copyright file="ProjectTimelineDisplayViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Web;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectTimeline;

namespace ProjectFirma.Web.Views.Shared.ProjectContact
{
    public class ProjectTimelineDisplayViewData : FirmaUserControlViewData
    {
        public Models.ProjectTimeline ProjectTimeline { get; }

        public HtmlString AddProjectProjectStatusButton { get; }
        public bool UserHasProjectStatusUpdatePermissions { get; }

        public ProjectStatusLegendDisplayViewData ProjectStatusLegendDisplayViewData { get; }
        public ProjectFirmaModels.Models.ProjectStatus CurrentProjectStatus { get; }

        public ProjectTimelineDisplayViewData(ProjectFirmaModels.Models.Project project,
            Models.ProjectTimeline projectTimeline, bool userHasProjectStatusUpdatePermissions,
            ProjectStatusLegendDisplayViewData projectStatusLegendDisplayViewData)
        {
            ProjectTimeline = projectTimeline;
            UserHasProjectStatusUpdatePermissions = userHasProjectStatusUpdatePermissions;
            var updateStatusUrl = SitkaRoute<ProjectProjectStatusController>.BuildUrlFromExpression(tc => tc.New(project));
            AddProjectProjectStatusButton =
                ModalDialogFormHelper.MakeNewIconButton(updateStatusUrl, "Update Status", true);
            ProjectStatusLegendDisplayViewData = projectStatusLegendDisplayViewData;
            CurrentProjectStatus = project.GetCurrentProjectStatus();
        }
    }
}
