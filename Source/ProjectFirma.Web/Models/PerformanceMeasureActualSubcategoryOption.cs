/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActualSubcategoryOption.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureActualSubcategoryOption : IAuditableEntity, IPerformanceMeasureValueSubcategoryOption
    {
        public string AuditDescriptionString
        {
            get
            {
                var performanceMeasureSubcategoryOption = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategoryOptions.Find(PerformanceMeasureSubcategoryOptionID);
                var performanceMeasureSubcategory = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureSubcategories.Find(PerformanceMeasureSubcategoryID);
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasures.Find(PerformanceMeasureID);
                var performanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOption != null ? performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName : ViewUtilities.NotFoundString;
                var performanceMeasureSubcategoryName = performanceMeasureSubcategory != null ? performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : ViewUtilities.NotFoundString;
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.PerformanceMeasureDisplayName : ViewUtilities.NotFoundString;
                return string.Format("Performance Measure: {0}, PerformanceMeasureSubcategory: {1}, PerformanceMeasureSubcategory Option: {2}", performanceMeasureName, performanceMeasureSubcategoryName, performanceMeasureSubcategoryOptionName);
            }
        }
    }
}
