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

namespace ProjectFirmaModels.Models
{
    /// <summary>
    /// This is a wrapper class for PerformanceMeasureActual
    /// </summary>
    public partial class PerformanceMeasureReportedValue //: IPerformanceMeasureReportedValue
    {
        //public readonly Project Project;
        //private readonly double? _reportedValue;
        public int CalendarYear => this.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodBeginDate.Year;
        //public PerformanceMeasure PerformanceMeasure { get; }

        //public double? GetReportedValue()
        //{
        //    return _reportedValue;
        //}

        //public int PerformanceMeasureID => PerformanceMeasure.PerformanceMeasureID;

        //public string GetPerformanceMeasureName() => PerformanceMeasure.PerformanceMeasureDisplayName;

        //todo: 11/4/2019 TK -- find another way to get the project name
        public string ProjectName => this.PerformanceMeasureID.ToString();

        //public MeasurementUnitType GetMeasurementUnitType() => PerformanceMeasure.MeasurementUnitType;

        //public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; set; }

        private PerformanceMeasureReportedValue(PerformanceMeasureActual performanceMeasureActual) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.PerformanceMeasureID = performanceMeasureActual.PerformanceMeasureID;
            //this.PerformanceMeasure = performanceMeasureActual.PerformanceMeasure;
            //this.PerformanceMeasureReportingPeriodID = performanceMeasureActual.PerformanceMeasureReportingPeriodID;
            //this.PerformanceMeasureReportingPeriod = performanceMeasureReportingPeriod;
            //performanceMeasureReportingPeriod.PerformanceMeasureReportedValues.Add(this);
            this.ReportedValue = performanceMeasureActual.ActualValue;

        }
        //{
        //    PerformanceMeasure = performanceMeasureActual.PerformanceMeasure;

        //    CalendarYear = performanceMeasureActual.CalendarYear;
        //    _reportedValue = performanceMeasureActual.ActualValue;
        //    Project = performanceMeasureActual.Project;
        //    PerformanceMeasureActualSubcategoryOptions = new List<IPerformanceMeasureValueSubcategoryOption>(performanceMeasureActual.PerformanceMeasureActualSubcategoryOptions);
        //}

        //public PerformanceMeasureReportedValue(PerformanceMeasure performanceMeasure, Project project, int calendarYear, double reportedValue)
        //{
        //    PerformanceMeasure = performanceMeasure;
        //    CalendarYear = calendarYear;
        //    _reportedValue = reportedValue;
        //    Project = project;
        //    PerformanceMeasureActualSubcategoryOptions = new List<IPerformanceMeasureValueSubcategoryOption>();
        //}

        public string GetPerformanceMeasureSubcategoriesAsString()
        {
            return PerformanceMeasureReportedValueSubcategoryOptions.Any()
                ? string.Join("\r\n",
                    PerformanceMeasureReportedValueSubcategoryOptions.OrderBy(x =>
                            x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                        .Select(x =>
                            $"{x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName}: {x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName}"))
                : ViewUtilities.NoneString;
        }

        public static List<PerformanceMeasureReportedValue> MakeFromList(IEnumerable<PerformanceMeasureActual> performanceMeasureActuals)
        {
            return performanceMeasureActuals.Select(x => new PerformanceMeasureReportedValue(x)).ToList();
        }

        public List<IPerformanceMeasureValueSubcategoryOption> GetPerformanceMeasureSubcategoryOptions() =>
            new List<IPerformanceMeasureValueSubcategoryOption>(this.PerformanceMeasureReportedValueSubcategoryOptions);
    }
}
