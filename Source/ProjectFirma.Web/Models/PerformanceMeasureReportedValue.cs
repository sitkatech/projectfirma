/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureReportedValue.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureReportedValue : IPerformanceMeasureReportedValue
    {
        public readonly Project Project;
        public int CalendarYear { get; private set; }
        public PerformanceMeasure PerformanceMeasure { get; private set; }
        public double? ReportedValue { get; private set; }

        public int PerformanceMeasureID => PerformanceMeasure.PerformanceMeasureID;

        public string PerformanceMeasureName => PerformanceMeasure.PerformanceMeasureDisplayName;

        public string PerformanceMeasureUrl => PerformanceMeasure.GetSummaryUrl();

        public string ProjectName => Project.DisplayName;

        public string ProjectUrl => Project.GetDetailUrl();

        public MeasurementUnitType MeasurementUnitType => PerformanceMeasure.MeasurementUnitType;

        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }

        private PerformanceMeasureReportedValue(PerformanceMeasureActual performanceMeasureActual)
        {
            PerformanceMeasure = performanceMeasureActual.PerformanceMeasure;
            CalendarYear = performanceMeasureActual.CalendarYear;
            ReportedValue = performanceMeasureActual.ActualValue;
            Project = performanceMeasureActual.Project;
            PerformanceMeasureActualSubcategoryOptions = new List<IPerformanceMeasureValueSubcategoryOption>(performanceMeasureActual.PerformanceMeasureActualSubcategoryOptions);
        }

        public PerformanceMeasureReportedValue(PerformanceMeasure performanceMeasure, Project project, int calendarYear, double reportedValue)
        {
            PerformanceMeasure = performanceMeasure;
            CalendarYear = calendarYear;
            ReportedValue = reportedValue;
            Project = project;
            PerformanceMeasureActualSubcategoryOptions = new List<IPerformanceMeasureValueSubcategoryOption>();
        }

        public string PerformanceMeasureSubcategoriesAsString
        {
            get
            {
                return PerformanceMeasureActualSubcategoryOptions.Any()
                    ? string.Join("\r\n",
                        PerformanceMeasureActualSubcategoryOptions.OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                            .Select(x =>
                                $"{x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName}: {x.PerformanceMeasureSubcategoryOptionName}"))
                    : ViewUtilities.NoneString;
            }
        }

        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureSubcategoryOptions => new List<IPerformanceMeasureValueSubcategoryOption>(PerformanceMeasureActualSubcategoryOptions);

        public string ReportedValueDisplay => MeasurementUnitType.DisplayValue(ReportedValue);

        public static List<PerformanceMeasureReportedValue> MakeFromList(IEnumerable<PerformanceMeasureActual> performanceMeasureActuals)
        {
            return performanceMeasureActuals.Select(x => new PerformanceMeasureReportedValue(x)).ToList();
        }

        public string GetCalendarYearDisplay()
        {
            return MultiTenantHelpers.FormatReportingYear(CalendarYear);
        }
    }
}
