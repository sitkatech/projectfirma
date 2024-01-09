﻿/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureExpectedGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureExpectedGridSpec : GridSpec<PerformanceMeasureExpected>
    {
        public PerformanceMeasureExpectedGridSpec(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            Add(FieldDefinitionEnum.Project.ToType().ToGridHeaderString(),
                a => UrlTemplate.MakeHrefString(a.Project.GetDetailUrl(), a.Project.GetDisplayName()),
                350,
                AgGridColumnFilterType.Html);
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.Project.GetCanStewardProjectsOrganization().GetShortNameAsUrl(), 150,
                    AgGridColumnFilterType.Html);
            }
            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.Project.GetPrimaryContactOrganization().GetShortNameAsUrl(), 150, AgGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), a => a.Project.ProjectStage.GetProjectStageDisplayName(), 140, AgGridColumnFilterType.SelectFilterStrict);
            if (performanceMeasure.HasRealSubcategories())
            {
                foreach (var performanceMeasureSubcategory in performanceMeasure.PerformanceMeasureSubcategories.OrderBy(x => x.PerformanceMeasureSubcategoryDisplayName))
                {
                    Add(performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName,
                        a =>
                        {
                            var performanceMeasureExpectedSubcategoryOption =
                                a.PerformanceMeasureExpectedSubcategoryOptions.SingleOrDefault(x => x.PerformanceMeasureSubcategoryID == performanceMeasureSubcategory.PerformanceMeasureSubcategoryID);
                            if (performanceMeasureExpectedSubcategoryOption != null)
                            {
                                return performanceMeasureExpectedSubcategoryOption.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
                            }
                            return string.Empty;
                        },
                        120,
                        AgGridColumnFilterType.SelectFilterStrict);
                }
            }

            var expectedValueColumnName = $"{FieldDefinitionEnum.ExpectedValue.ToType().ToGridHeaderString()} ({performanceMeasure.MeasurementUnitType.LegendDisplayName})";

            Add(expectedValueColumnName, a => a.ExpectedValue, 150, AgGridColumnFormatType.Decimal, AgGridColumnAggregationType.Total);
        }
    }
}
