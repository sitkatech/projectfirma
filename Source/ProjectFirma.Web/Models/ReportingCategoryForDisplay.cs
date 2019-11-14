/*-----------------------------------------------------------------------
<copyright file="ReportingCategoryForDisplay.cs" company="Tahoe Regional Planning Agency">
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

using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ReportingCategoryForDisplay
    {
        public int? PerformanceMeasureSubcategoryOptionID { get; set; }
        public double ReportedValue { get; set; }
        public string DisplayName { get; set; }
        public int SortOrder { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ReportingCategoryForDisplay()
        {
        }

        public ReportingCategoryForDisplay(PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasureSubcategoryOptionID = null;
            DisplayName = performanceMeasure.PerformanceMeasureDisplayName;
            SortOrder = 1;
        }

        public ReportingCategoryForDisplay(PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption)
        {
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            DisplayName = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
            SortOrder = performanceMeasureSubcategoryOption.SortOrder ?? 0;
        }
    }
}
