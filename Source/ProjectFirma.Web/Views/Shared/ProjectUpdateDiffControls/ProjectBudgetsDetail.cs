﻿/*-----------------------------------------------------------------------
<copyright file="ProjectFundingRequestsDetail.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.Web.Mvc;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.Shared.ProjectUpdateDiffControls
{
    public abstract class ProjectBudgetsDetail : TypedWebPartialViewPage<ProjectBudgetsDetailViewData>
    {
        public static void RenderPartialView(HtmlHelper html, ProjectBudgetsDetailViewData viewData)
        {
            html.RenderRazorSitkaPartial<ProjectBudgetsDetail, ProjectBudgetsDetailViewData>(viewData);
        }
    }
}
