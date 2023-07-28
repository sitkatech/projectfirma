﻿/*-----------------------------------------------------------------------
<copyright file="BasicsViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
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

using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BasicsViewData : ProjectUpdateViewData
    {
        public IEnumerable<SelectListItem> PlanningDesignStartYearRange { get; }
        public IEnumerable<SelectListItem> ImplementationStartYearRange { get; }
        public IEnumerable<SelectListItem> CompletionYearRange { get; }
        public IEnumerable<SelectListItem> ProjectStages { get; }
        public IEnumerable<ProjectStage> ProjectStagesModels { get; }
        public string TaxonomyLeafDisplayName { get; }
        public string RefreshUrl { get; }
        public string DiffUrl { get; }

        public ProjectFirmaModels.Models.ProjectUpdate ProjectUpdate { get; }
        public SectionCommentsViewData SectionCommentsViewData { get; }
        public int? StartYearForTotalCostCalculation { get; }
        public bool TenantUsesFiscalYears { get; }
        public bool TenantHasSolicitations { get; }


        public BasicsViewData(FirmaSession currentFirmaSession
            , ProjectFirmaModels.Models.ProjectUpdate projectUpdate,
            IEnumerable<ProjectStage> projectStages
            , ProjectUpdateStatus projectUpdateStatus,
            BasicsValidationResult basicsValidationResult)
            : base(currentFirmaSession, projectUpdate.ProjectUpdateBatch, projectUpdateStatus, basicsValidationResult.GetWarningMessages(), ProjectUpdateSection.Basics.ProjectUpdateSectionDisplayName)
        {
            ProjectUpdate = projectUpdate;
            TaxonomyLeafDisplayName = projectUpdate.ProjectUpdateBatch.Project.TaxonomyLeaf.GetDisplayName();
            ProjectStages = projectStages.OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.GetProjectStageDisplayName());
            ProjectStagesModels = projectStages;
            PlanningDesignStartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay).ToList();
            ImplementationStartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay).ToList();
            CompletionYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay).ToList();
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshBasics(Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffBasics(Project));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdate.ProjectUpdateBatch.BasicsComment, projectUpdate.ProjectUpdateBatch.IsReturned());
            StartYearForTotalCostCalculation = projectUpdate.StartYearForTotalCostCalculations();
            TenantUsesFiscalYears = MultiTenantHelpers.UseFiscalYears();
            TenantHasSolicitations = MultiTenantHelpers.HasSolicitations();
        }
    }
}
