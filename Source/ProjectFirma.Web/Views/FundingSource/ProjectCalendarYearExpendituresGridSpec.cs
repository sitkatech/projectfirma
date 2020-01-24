/*-----------------------------------------------------------------------
<copyright file="ProjectCalendarYearExpendituresGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectFirma.Web.Views.FundingSource
{
    public class ProjectCalendarYearExpendituresGridSpec : GridSpec<ProjectCalendarYearExpenditure>
    {
        public ProjectCalendarYearExpendituresGridSpec(IEnumerable<int> calendarYearsForProjectExpenditures)
        {
            Add(FieldDefinitionEnum.Project.ToType().ToGridHeaderString(),
                a => UrlTemplate.MakeHrefString(a.Project.GetDetailUrl(), a.Project.GetDisplayName()),
                350,
                DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            foreach (var year in calendarYearsForProjectExpenditures)
            {
                var calendarYear = year;
                Add(calendarYear.ToString(CultureInfo.InvariantCulture), a => a.CalendarYearExpenditure[calendarYear], 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
        }
    }
}
