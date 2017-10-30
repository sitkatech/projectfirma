/*-----------------------------------------------------------------------
<copyright file="EditProjectBudgetsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectBudget
{
    public class EditProjectBudgetsViewData : FirmaUserControlViewData
    {
        public readonly List<int> CalendarYearRange;
        public readonly List<ProjectCostTypeSimple> AllProjectCostTypes;
        public readonly List<FundingSourceSimple> AllFundingSources;
        public readonly int ProjectID;
        public readonly string FundingSourceUrl;

        public EditProjectBudgetsViewData(Models.Project project, List<FundingSourceSimple> allFundingSources, List<ProjectCostTypeSimple> allProjectCostTypes, List<int> calendarYearRange)
        {
            CalendarYearRange = calendarYearRange;
            AllFundingSources = allFundingSources;
            ProjectID = project.ProjectID;
            AllProjectCostTypes = allProjectCostTypes;
            FundingSourceUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(x => x.Index());
        }

        
    }
}
