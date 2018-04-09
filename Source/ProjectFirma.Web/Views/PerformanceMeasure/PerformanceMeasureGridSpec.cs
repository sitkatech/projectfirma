/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureGridSpec : GridSpec<Models.PerformanceMeasure>
    {
        public PerformanceMeasureGridSpec(bool hasDeletePermission)
        {
            if (hasDeletePermission)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            }
            Add(Models.FieldDefinition.PerformanceMeasure.ToGridHeaderString(MultiTenantHelpers.GetPerformanceMeasureName()),
                a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.PerformanceMeasureDisplayName),
                300,
                DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.MeasurementUnit.ToGridHeaderString("Unit"), a => a.MeasurementUnitType.MeasurementUnitTypeDisplayName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.PerformanceMeasureType.ToGridHeaderString("Type"), a => a.PerformanceMeasureType.PerformanceMeasureTypeDisplayName, 60, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Definition", a => a.PerformanceMeasureDefinition, 400, DhtmlxGridColumnFilterType.Html);
            Add($"# of {Models.FieldDefinition.PerformanceMeasureSubcategory.GetFieldDefinitionLabelPluralized()}", a => a.GetRealSubcategoryCount(), 110);
            Add($"# of {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", a => a.ReportedProjectsCount, 80);
            Add($"Primary {MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel().GetFieldDefinition().GetFieldDefinitionLabel()}", a => a.GetPrimaryTaxonomyTier() == null ? new HtmlString(string.Empty) : a.GetPrimaryTaxonomyTier().GetDisplayNameAsUrl(), 150);
        }
    }
}
