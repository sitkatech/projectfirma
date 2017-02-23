/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureReportedValuesGroupedViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Shared.PerformanceMeasureControls
{
    public class PerformanceMeasureReportedValuesGroupedViewData : FirmaUserControlViewData
    {
        public readonly List<int> CalendarYearsForPerformanceMeasures;
        public readonly List<int> ExemptReportingYears;
        public readonly string ExemptionExplanation;
        public readonly List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> PerformanceMeasureSubcategoriesCalendarYearReportedValues;
        public readonly bool HideByDefault;

        public PerformanceMeasureReportedValuesGroupedViewData(List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> performanceMeasureSubcategoriesCalendarYearReportedValues,
            List<int> exemptReportingYears,
            string exemptionExplanation,
            List<int> calendarYearsForPerformanceMeasures)
            : this(performanceMeasureSubcategoriesCalendarYearReportedValues, exemptReportingYears, exemptionExplanation, calendarYearsForPerformanceMeasures, false)
        {
        }

        public PerformanceMeasureReportedValuesGroupedViewData(List<PerformanceMeasureSubcategoriesCalendarYearReportedValue> performanceMeasureSubcategoriesCalendarYearReportedValues,
            List<int> exemptReportingYears,
            string exemptionExplanation,
            List<int> calendarYearsForPerformanceMeasures,
            bool hideByDefault)
        {
            CalendarYearsForPerformanceMeasures = calendarYearsForPerformanceMeasures;
            PerformanceMeasureSubcategoriesCalendarYearReportedValues = performanceMeasureSubcategoriesCalendarYearReportedValues;
            ExemptReportingYears = exemptReportingYears;
            ExemptionExplanation = exemptionExplanation;
            HideByDefault = hideByDefault;
        }

        public string HideByDefaultStyle()
        {
            return string.Format("display: {0};", HideByDefault ? "none" : "table");
        }
    }
}
