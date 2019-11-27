/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceExpendituresViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using System.Collections.Generic;

namespace ProjectFirma.Web.Views.ProjectFundingSourceExpenditure
{
    public class EditProjectFundingSourceExpendituresViewData : FirmaUserControlViewData
    {

        public int? ProjectID { get; }

        public ViewDataForAngularClass ViewDataForAngularClass { get; }


        public EditProjectFundingSourceExpendituresViewData( ViewDataForAngularClass viewDataForAngularClass)
        {
            ProjectID = viewDataForAngularClass.ProjectID;
            ViewDataForAngularClass = viewDataForAngularClass;
        }
    }

    public class ViewDataForAngularClass
    {
        public List<int> RequiredCalendarYearRange { get; }
        public List<FundingSourceSimple> AllFundingSources { get; }

        public int ProjectID { get; }
        public int MaxYear { get; }
        public bool UseFiscalYears { get; }

        public ViewDataForAngularClass(ProjectFirmaModels.Models.Project project,
            List<FundingSourceSimple> allFundingSources,
            List<int> requiredCalendarYearRange)
        {
            RequiredCalendarYearRange = requiredCalendarYearRange;
            AllFundingSources = allFundingSources;
            ProjectID = project.ProjectID;

            MaxYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
            UseFiscalYears = MultiTenantHelpers.UseFiscalYears();
        }
    }
}
