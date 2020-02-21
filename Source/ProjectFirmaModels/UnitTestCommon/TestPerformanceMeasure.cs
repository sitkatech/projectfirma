/*-----------------------------------------------------------------------
<copyright file="TestPerformanceMeasure.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using System.Collections.Generic;
using ApprovalUtilities.Utilities;
using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasure
        {
            public static PerformanceMeasure Create()
            {
                var randomGuid = Guid.NewGuid();
                var performanceMeasureDisplayName = $"PerformanceMeasureFakeName_{randomGuid}";
                var performanceMeasure = new PerformanceMeasure(performanceMeasureDisplayName, MeasurementUnitType.Acres, PerformanceMeasureType.Action, false, PerformanceMeasureDataSourceType.Project, false)
                {
                    PerformanceMeasureSubcategories = new List<PerformanceMeasureSubcategory>()
                };
                return performanceMeasure;
            }

            public static PerformanceMeasure CreateWithSubcategories(int performanceMeasureID, string performanceMeasureName)
            {
                var performanceMeasure = Create();
                var subcategoryIDBase = performanceMeasureID*10;
                var subcategory1 = TestPerformanceMeasureSubcategory.CreateWithSubcategoryOptions(performanceMeasure, subcategoryIDBase + 1, $"{performanceMeasureName}Subcategory1");
                var subcategory2 = TestPerformanceMeasureSubcategory.CreateWithSubcategoryOptions(performanceMeasure, subcategoryIDBase + 2, $"{performanceMeasureName}Subcategory2");
                var subcategory3 = TestPerformanceMeasureSubcategory.CreateWithSubcategoryOptions(performanceMeasure, subcategoryIDBase + 3, $"{performanceMeasureName}Subcategory3");
                performanceMeasure.PerformanceMeasureSubcategories.AddAll(new List<PerformanceMeasureSubcategory> {subcategory1, subcategory2, subcategory3});

                return performanceMeasure;
            }
        }
    }
}
