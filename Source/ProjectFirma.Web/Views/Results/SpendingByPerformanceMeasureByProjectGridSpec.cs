/*-----------------------------------------------------------------------
<copyright file="SpendingByPerformanceMeasureByProjectGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Linq;
using System.Web;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Project;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using Microsoft.Ajax.Utilities;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByPerformanceMeasureByProjectGridSpec : GridSpec<PerformanceMeasureSubcategoriesTotalReportedValue>
    {
        public SpendingByPerformanceMeasureByProjectGridSpec(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            Add(FieldDefinitionEnum.Project.ToType().ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.ProjectUrl, a.ProjectName), 350, AgGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.Project.ProjectStage.GetProjectStageDisplayName(), 90, AgGridColumnFilterType.SelectFilterStrict);
            foreach (var performanceMeasureSubcategory in performanceMeasure.PerformanceMeasureSubcategories.OrderBy(x => x.PerformanceMeasureSubcategoryDisplayName))
            {
                Add(performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName,
                    a =>
                    {
                        var performanceMeasureActualSubcategoryOption =
                            a.PerformanceMeasureActualSubcategoryOptions.SingleOrDefault(x => x.PerformanceMeasureSubcategoryID == performanceMeasureSubcategory.PerformanceMeasureSubcategoryID);
                        if (performanceMeasureActualSubcategoryOption != null)
                        {
                            return performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
                        }
                        return string.Empty;
                    },
                    120,
                    AgGridColumnFilterType.SelectFilterStrict);
            }

            var reportedValueColumnName = $"{FieldDefinitionEnum.ReportedValue.ToType().ToGridHeaderString()} ({performanceMeasure.MeasurementUnitType.LegendDisplayName})";

            Add(reportedValueColumnName, a => a.TotalReportedValue, 150, AgGridColumnFormatType.Decimal, AgGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.ReportedExpenditure.ToType().ToGridHeaderString(), x => x.CalculateWeightedTotalExpenditure(), 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);

            var reportedValueUnitCostColumnName = $"Estimated Cost Per {performanceMeasure.MeasurementUnitType.SingularDisplayName} ";
            Add(reportedValueUnitCostColumnName, a => a.CalculateWeightedTotalExpenditurePerPerformanceMeasure(), 100, AgGridColumnFormatType.Currency);

            Add($"Other Reported {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}",
                a =>
                {
                    var reportedPerformanceMeasures = a.Project.GetPerformanceMeasureReportedValues().Where(x => a.PerformanceMeasureID != x.PerformanceMeasure.PerformanceMeasureID).ToList();
                    var htmlStrings = reportedPerformanceMeasures.DistinctBy(x => x.PerformanceMeasureID).Select(x => UrlTemplate.MakeHrefString(x.PerformanceMeasure.GetSummaryUrl(), x.PerformanceMeasure.PerformanceMeasureID.ToString())).ToList();
                    return new HtmlString(string.Join(", ", htmlStrings));
                },
             200,
             AgGridColumnFilterType.Html);
        }
    }
}
