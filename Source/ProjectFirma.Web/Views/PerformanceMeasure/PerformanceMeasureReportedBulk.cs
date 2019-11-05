/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureReportedBulk.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureReportedBulk
    {
        [Required]
        public int PerformanceMeasureReportingPeriodID { get; set; }
        [Required]
        [StringLength(PerformanceMeasureReportingPeriod.FieldLengths.PerformanceMeasureReportingPeriodLabel)]
        public string PerformanceMeasureReportingPeriodLabel { get; set; }
        [Required]
        public int PerformanceMeasureReportingPeriodCalendarYear { get; set; }

        public int? PerformanceMeasureSubcategoryID { get; set; }
        [Required]
        public List<ReportedValueForDisplay> ReportedValuesForDisplay { get; set; }

        public double? TargetValue { get; set; }
        public string TargetValueDescription { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureReportedBulk()
        {
        }

        public PerformanceMeasureReportedBulk(PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasureSubcategory performanceMeasureSubcategory, IEnumerable<PerformanceMeasureReportedValue> performanceMeasureReportedValues)
        {
            PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID;
            PerformanceMeasureReportingPeriodLabel = performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel;
            PerformanceMeasureReportingPeriodCalendarYear = performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear;

            PerformanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
            TargetValue = performanceMeasureReportingPeriod.TargetValue;
            TargetValueDescription = performanceMeasureReportingPeriod.TargetValueDescription;
            var allPossibleReportedValuesForDisplays = performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.Select(x => new ReportedValueForDisplay(x.PerformanceMeasureSubcategoryOptionID, 0, x.SortOrder ?? 0)).ToList();
            foreach (var performanceMeasureReportedValue in performanceMeasureReportedValues)
            {
                var matchingPerformanceMeasureReportedValue = allPossibleReportedValuesForDisplays.SingleOrDefault(x => x.PerformanceMeasureSubcategoryOptionID == performanceMeasureReportedValue.PerformanceMeasureActualSubcategoryOptions.Single().PerformanceMeasureSubcategoryOptionID);
                if (matchingPerformanceMeasureReportedValue != null)
                {
                    matchingPerformanceMeasureReportedValue.ReportedValue = performanceMeasureReportedValue.GetReportedValue();
                    //todo: 11/4/2019 TK - check this out
                    //matchingPerformanceMeasureReportedValue.SortOrder = performanceMeasureReportedValue.GetSortOrder();
                }
            }
            ReportedValuesForDisplay = allPossibleReportedValuesForDisplays;
        }

        public static List<PerformanceMeasureReportedBulk> MakeFromList(IEnumerable<PerformanceMeasureReportedValue> performanceMeasureReportedValues)
        { 
            var groupedByNameAndReportingPeriod = performanceMeasureReportedValues.GroupBy(x => new { x.PerformanceMeasureID, x.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID });
            return groupedByNameAndReportingPeriod.Select(grouping => new PerformanceMeasureReportedBulk(grouping.First().PerformanceMeasureReportingPeriod, grouping.First().PerformanceMeasure.PerformanceMeasureSubcategories.Single(), grouping.ToList())).ToList();
        }
    }
}
