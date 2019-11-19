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

        public int PerformanceMeasureTargetID { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureReportingPeriodSimple()
        {
        }

        public PerformanceMeasureReportingPeriodSimple(PerformanceMeasureTarget performanceMeasureTarget)
        {
            PerformanceMeasureReportingPeriodID = performanceMeasureTarget.PerformanceMeasureReportingPeriodID;
            PerformanceMeasureReportingPeriodLabel = performanceMeasureTarget.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel;
            PerformanceMeasureReportingPeriodCalendarYear = performanceMeasureTarget.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear;
            TargetValue = performanceMeasureTarget.PerformanceMeasureTargetValue;
            TargetValueLabel = performanceMeasureTarget.PerformanceMeasureTargetValueLabel;
            PerformanceMeasureID = performanceMeasureTarget.PerformanceMeasureID;
            PerformanceMeasureTargetID = performanceMeasureTarget.PerformanceMeasureTargetID;
        }

        public PerformanceMeasureReportingPeriodSimple(ProjectFirmaModels.Models.PerformanceMeasureActual performanceMeasureActual)
        {
            PerformanceMeasureReportingPeriodID = performanceMeasureActual.PerformanceMeasureReportingPeriodID;
            PerformanceMeasureReportingPeriodLabel = performanceMeasureActual.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel;
            PerformanceMeasureReportingPeriodCalendarYear = performanceMeasureActual.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear;
            TargetValue = null;
            TargetValueLabel = string.Empty;
            PerformanceMeasureID = performanceMeasureActual.PerformanceMeasureID;
            PerformanceMeasureTargetID = -1;
        }


        public static List<PerformanceMeasureReportingPeriodSimple> MakeFromList(IEnumerable<PerformanceMeasureTarget> performanceMeasureTargets, 
                                                                                 IEnumerable<ProjectFirmaModels.Models.PerformanceMeasureActual> performanceMeasureActuals)
        {
            var reportingPeriodSimples = performanceMeasureTargets.Select(pmt => new PerformanceMeasureReportingPeriodSimple(pmt)).ToList();
            reportingPeriodSimples.AddRange(performanceMeasureActuals.Select(pma => new PerformanceMeasureReportingPeriodSimple(pma)));

            List<PerformanceMeasureReportingPeriodSimple> finalSimples = new List<PerformanceMeasureReportingPeriodSimple>();

            var calendarYearGroups = reportingPeriodSimples.GroupBy(x => x.PerformanceMeasureReportingPeriodCalendarYear);
            foreach (var currentGroup in calendarYearGroups)
            {
                // If there are multiple per calendar year, prefer the one with a TargetValue
                PerformanceMeasureReportingPeriodSimple reportingPeriodSimpleToAdd = currentGroup.FirstOrDefault(g => g.TargetValue.HasValue);
                if (reportingPeriodSimpleToAdd == null)
                {
                    // Otherwise, if no target value, take the first one available.
                    reportingPeriodSimpleToAdd = currentGroup.First();
                }

                finalSimples.Add(reportingPeriodSimpleToAdd);
            }

            return finalSimples;
        }
    }
}
