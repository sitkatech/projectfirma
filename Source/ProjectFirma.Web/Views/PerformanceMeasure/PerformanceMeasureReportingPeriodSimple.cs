/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureReportingPeriodSimple.cs" company="Tahoe Regional Planning Agency">
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
    public class PerformanceMeasureReportingPeriodSimple
    {
        [Required]
        public int PerformanceMeasureReportingPeriodID { get; set; }
        [Required]
        [StringLength(PerformanceMeasureReportingPeriod.FieldLengths.PerformanceMeasureReportingPeriodLabel)]
        public string PerformanceMeasureReportingPeriodLabel { get; set; }
        [Required]
        public int PerformanceMeasureReportingPeriodCalendarYear { get; set; }

        public double? TargetValue { get; set; }
        public string TargetValueLabel { get; set; }

        public int PerformanceMeasureID { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureReportingPeriodSimple()
        {
        }

        public PerformanceMeasureReportingPeriodSimple(PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod)
        {
            PerformanceMeasureReportingPeriodID = performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodID;
            PerformanceMeasureReportingPeriodLabel = performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel;
            PerformanceMeasureReportingPeriodCalendarYear = performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear;
            TargetValue = performanceMeasureReportingPeriod.TargetValue;
            TargetValueLabel = performanceMeasureReportingPeriod.TargetValueLabel;
            PerformanceMeasureID = performanceMeasureReportingPeriod.PerformanceMeasureID;
        }

        public static List<PerformanceMeasureReportingPeriodSimple> MakeFromList(IEnumerable<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods)
        {
            return performanceMeasureReportingPeriods.Select(pmrp => new PerformanceMeasureReportingPeriodSimple(pmrp)).ToList();
        }
    }
}
