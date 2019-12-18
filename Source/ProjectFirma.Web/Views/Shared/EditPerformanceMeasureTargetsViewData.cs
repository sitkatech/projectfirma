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

namespace ProjectFirma.Web.Views.Shared
{
    public class EditPerformanceMeasureTargetsViewData
    {
        public ProjectFirmaModels.Models.PerformanceMeasure PerformanceMeasure { get; }
        public EditPerformanceMeasureTargetsViewDataForAngular ViewDataForAngular { get; }
        public ProjectFirmaModels.Models.FieldDefinition PerformanceMeasureFieldDefinition { get; }
        public bool ShowGeoSpatialAreaInstructions { get;}

        public enum PerformanceMeasureTargetType
        {
            TargetByYear,
            TargetByGeospatialArea
        }

        public EditPerformanceMeasureTargetsViewData(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
                                                     EditPerformanceMeasureTargetsViewDataForAngular viewDataForAngular,
                                                     PerformanceMeasureTargetType performanceMeasureTargetType)
        {
            PerformanceMeasure = performanceMeasure;
            ViewDataForAngular = viewDataForAngular;
            PerformanceMeasureFieldDefinition = FieldDefinitionEnum.PerformanceMeasure.ToType();
            ShowGeoSpatialAreaInstructions = performanceMeasureTargetType == PerformanceMeasureTargetType.TargetByGeospatialArea;
        }
    }

    public class EditPerformanceMeasureTargetsViewDataForAngular
    {
        public int? PerformanceMeasureSubcategoryID { get; }
        public int DefaultReportingPeriodYear { get; }
        public List<PerformanceMeasureTargetValueType> PerformanceMeasureTargetValueTypes { get; }
        public List<int> ReportingPeriodsWithActuals { get; }

        public string DefaultTargetLabel { get; }

        public EditPerformanceMeasureTargetsViewDataForAngular(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, int defaultReportingPeriodYear, List<PerformanceMeasureTargetValueType> performanceMeasureTargetValueTypes, bool isGeospatialAreaTarget)
        {
            PerformanceMeasureTargetValueTypes = performanceMeasureTargetValueTypes;
            DefaultReportingPeriodYear = defaultReportingPeriodYear;
            ReportingPeriodsWithActuals = performanceMeasure.PerformanceMeasureActuals.Select(x => x.PerformanceMeasureReportingPeriod).Select(x => x.PerformanceMeasureReportingPeriodID).ToList();
            DefaultTargetLabel = isGeospatialAreaTarget ? $"{FieldDefinitionEnum.GeospatialArea.ToType().GetFieldDefinitionLabel()} Target" : $"P.M. Target";
        }
    }
}
