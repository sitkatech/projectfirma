/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureTargetsViewData.cs" company="Tahoe Regional Planning Agency">
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
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class EditPerformanceMeasureTargetsViewData
    {        
        public ProjectFirmaModels.Models.PerformanceMeasure PerformanceMeasure { get; }
        public List<PerformanceMeasureTargetValueType> PerformanceMeasureTargetValueTypes { get; }
        public EditPerformanceMeasureTargetsViewDataForAngular ViewDataForAngular { get; }
        public ProjectFirmaModels.Models.FieldDefinition PerformanceMeasureFieldDefinition { get; }

        public EditPerformanceMeasureTargetsViewData(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, EditPerformanceMeasureTargetsViewDataForAngular viewDataForAngular, List<PerformanceMeasureTargetValueType> performanceMeasureTargetValueTypes)
        {
            PerformanceMeasure = performanceMeasure;
            ViewDataForAngular = viewDataForAngular;
            PerformanceMeasureTargetValueTypes = performanceMeasureTargetValueTypes;
            PerformanceMeasureFieldDefinition = FieldDefinitionEnum.PerformanceMeasure.ToType();
            
        }
    }

    public class EditPerformanceMeasureTargetsViewDataForAngular
    {
        public int? PerformanceMeasureSubcategoryID { get; }
        public int DefaultReportingPeriodYear { get; }
        public Dictionary<string, int> PerformanceMeasureTargetValueTypes { get; }
        public List<int> ReportingPeriodsWithActuals { get; }

        public EditPerformanceMeasureTargetsViewDataForAngular(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, int defaultReportingPeriodYear, Dictionary<string, int> performanceMeasureTargetValueTypes)
        {
            PerformanceMeasureTargetValueTypes = performanceMeasureTargetValueTypes;
            DefaultReportingPeriodYear = defaultReportingPeriodYear;
            ReportingPeriodsWithActuals = performanceMeasure.PerformanceMeasureReportingPeriods.Where(x => x.PerformanceMeasureActuals.Any() || x.PerformanceMeasureActualUpdates.Any()).Select(x => x.PerformanceMeasureReportingPeriodID).ToList();
        }
    }
}
