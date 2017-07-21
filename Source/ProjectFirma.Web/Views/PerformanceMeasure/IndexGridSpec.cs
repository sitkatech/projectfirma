/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency">
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
using System.Globalization;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class IndexGridSpec : GridSpec<Models.PerformanceMeasure>
    {
        public IndexGridSpec()
        {
            Add("#", a => UrlTemplate.MakeHrefString(a.GetInfoSheetUrl(), a.PerformanceMeasureID.ToString(CultureInfo.InvariantCulture)), 35, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.PerformanceMeasure.ToGridHeaderString(MultiTenantHelpers.GetPerformanceMeasureName()), a => UrlTemplate.MakeHrefString(a.GetInfoSheetUrl(), a.PerformanceMeasureDisplayName), 320, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.MeasurementUnit.ToGridHeaderString("Units"), a => a.MeasurementUnitType.MeasurementUnitTypeDisplayName, 110, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add($"{MultiTenantHelpers.GetPerformanceMeasureNamePluralized()} Definition", a => a.PerformanceMeasureDefinition, 350, DhtmlxGridColumnFilterType.Text);
            Add("# of Subcategories", a => a.GetRealSubcategoryCount(), 110);
            Add($"# of {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", a => a.ReportedProjectsCount, 80);
            Add($"# of {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()} Expected", a => a.ExpectedProjectsCount, 100);
        }
    }
}
