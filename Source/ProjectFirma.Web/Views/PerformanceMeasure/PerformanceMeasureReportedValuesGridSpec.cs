/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureReportedValuesGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureReportedValuesGridSpec : GridSpec<PerformanceMeasureReportedValue>
    {
        public PerformanceMeasureReportedValuesGridSpec(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            Add(FieldDefinitionEnum.ReportingYear.ToType().ToGridHeaderString(), a => a.GetCalendarYearDisplay(), 60, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.Project.ToType().ToGridHeaderString(),
                a => a.Project.GetDisplayNameAsUrl(),
                350,
                DhtmlxGridColumnFilterType.Html);
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.Project.GetCanStewardProjectsOrganization().GetShortNameAsUrl(), 150,
                    DhtmlxGridColumnFilterType.Html);
            }
            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.Project.GetPrimaryContactOrganization().GetShortNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), a => a.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            if (performanceMeasure.HasRealSubcategories())
            {
                foreach (var performanceMeasureSubcategory in
                    performanceMeasure.PerformanceMeasureSubcategories.OrderBy(x =>
                        x.PerformanceMeasureSubcategoryDisplayName))
                {
                    Add(performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName,
                        a =>
                        {
                            var performanceMeasureActualSubcategoryOption =
                                a.PerformanceMeasureActualSubcategoryOptions.SingleOrDefault(x =>
                                    x.PerformanceMeasureSubcategoryID ==
                                    performanceMeasureSubcategory.PerformanceMeasureSubcategoryID);
                            if (performanceMeasureActualSubcategoryOption != null)
                            {
                                return performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOption
                                    .PerformanceMeasureSubcategoryOptionName;
                            }

                            return string.Empty;
                        }, 120, DhtmlxGridColumnFilterType.SelectFilterStrict);
                }
            }
            var reportedValueColumnName = $"{FieldDefinitionEnum.ReportedValue.ToType().ToGridHeaderString()} ({performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName})";

            if (performanceMeasure.IsAggregatable)
            {
                Add(reportedValueColumnName, a => a.GetReportedValue(), 150, DhtmlxGridColumnFormatType.Decimal,
                    DhtmlxGridColumnAggregationType.Total);
            }
            else
            {
                Add(reportedValueColumnName, a => a.GetReportedValue(), 150, DhtmlxGridColumnFormatType.Decimal);
            }
            foreach (var geospatialAreaType in new List<GeospatialAreaType>())
            {
                Add($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", a => a.Project.GetProjectGeospatialAreaNamesAsHyperlinks(geospatialAreaType), 350, DhtmlxGridColumnFilterType.Html);
            }
        }
    }
}
