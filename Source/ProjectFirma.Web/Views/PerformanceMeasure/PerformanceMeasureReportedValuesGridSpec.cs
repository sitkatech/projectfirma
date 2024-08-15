/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureReportedValuesGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureReportedValuesGridSpec : GridSpec<PerformanceMeasureReportedValue>
    {
        public PerformanceMeasureReportedValuesGridSpec(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            Add(FieldDefinitionEnum.ReportingYear.ToType().ToGridHeaderString(), a => a.GetCalendarYearDisplay(), 60, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.Project.ToType().ToGridHeaderString(),
                a => a.Project.GetDisplayNameAsUrl(),
                350,
                AgGridColumnFilterType.Html, 1);
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.Project.GetCanStewardProjectsOrganization().GetDisplayNameAsUrlForAgGrid(), 150,
                    AgGridColumnFilterType.HtmlLinkJson);
            }
            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.Project.GetPrimaryContactOrganization().GetShortNameAsUrlForAgGrid(), 150, AgGridColumnFilterType.HtmlLinkJson);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), a => a.Project.ProjectStage.GetProjectStageDisplayName(), 140, AgGridColumnFilterType.SelectFilterStrict);
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
                        }, 120, AgGridColumnFilterType.SelectFilterStrict);
                }
            }
            var reportedValueColumnName = $"{FieldDefinitionEnum.ReportedValue.ToType().ToGridHeaderString()} ({performanceMeasure.MeasurementUnitType.LegendDisplayName})";

            if (performanceMeasure.IsSummable)
            {
                Add(reportedValueColumnName, a => a.GetReportedValue(), 150, AgGridColumnFormatType.Decimal,
                    AgGridColumnAggregationType.Total);
            }
            else
            {
                Add(reportedValueColumnName, a => a.GetReportedValue(), 150, AgGridColumnFormatType.Decimal);
            }
            foreach (var geospatialAreaType in new List<GeospatialAreaType>())
            {
                Add($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", a => a.Project.GetProjectGeospatialAreaNamesAsHyperlinksForAgGrid(geospatialAreaType), 350, AgGridColumnFilterType.HtmlLinkListJson);
            }
        }
    }
}
