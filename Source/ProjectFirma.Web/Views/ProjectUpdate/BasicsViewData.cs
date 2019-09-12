/*-----------------------------------------------------------------------
<copyright file="BasicsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
        public string TaxonomyLeafDisplayName { get; }
        public string RefreshUrl { get; }
        public string DiffUrl { get; }

        public ProjectFirmaModels.Models.ProjectUpdate ProjectUpdate { get; }
        public SectionCommentsViewData SectionCommentsViewData { get; }
        public int? StartYearForTotalCostCalculation { get; }


        public BasicsViewData(Person currentPerson, ProjectFirmaModels.Models.ProjectUpdate projectUpdate,
            IEnumerable<ProjectStage> projectStages, ProjectUpdateStatus projectUpdateStatus,
            BasicsValidationResult basicsValidationResult)
            : base(currentPerson, projectUpdate.ProjectUpdateBatch, projectUpdateStatus, basicsValidationResult.GetWarningMessages(), ProjectUpdateSection.Basics.ProjectUpdateSectionDisplayName)
        {
            ProjectUpdate = projectUpdate;
            TaxonomyLeafDisplayName = projectUpdate.ProjectUpdateBatch.Project.TaxonomyLeaf.GetDisplayName();
            ProjectStages = projectStages.OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.ProjectStageDisplayName);
            PlanningDesignStartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay);
            ImplementationStartYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay);
            CompletionYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay);
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshBasics(Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffBasics(Project));
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdate.ProjectUpdateBatch.BasicsComment, projectUpdate.ProjectUpdateBatch.IsReturned());
            StartYearForTotalCostCalculation = projectUpdate.StartYearForTotalCostCalculations();
        }
    }
}
