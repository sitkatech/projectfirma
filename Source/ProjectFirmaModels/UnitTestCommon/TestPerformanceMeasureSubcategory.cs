/*-----------------------------------------------------------------------
<copyright file="TestPerformanceMeasureSubcategory.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureSubcategory
        {
            public static PerformanceMeasureSubcategory Create(PerformanceMeasure performanceMeasure, string performanceMeasureSubcategoryName)
            {
                var performanceMeasureSubcategory = new PerformanceMeasureSubcategory(performanceMeasure, performanceMeasureSubcategoryName);
                performanceMeasure.PerformanceMeasureSubcategories.Add(performanceMeasureSubcategory);
                return performanceMeasureSubcategory;
            }

            public static PerformanceMeasureSubcategory CreateWithSubcategoryOptions(PerformanceMeasure performanceMeasure, int performanceMeasureSubcategoryID, string performanceMeasureSubcategoryName)
            {
                var performanceMeasureSubcategory = Create(performanceMeasure, performanceMeasureSubcategoryName);
                performanceMeasureSubcategory.PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
                var subcategoryOptionIDBase = performanceMeasureSubcategoryID*10;
                var subcategoryOption1 = TestFramework.TestPerformanceMeasureSubcategoryOption.Create(subcategoryOptionIDBase + 1, performanceMeasureSubcategory, $"{performanceMeasureSubcategoryName}Option1");
                var subcategoryOption2 = TestFramework.TestPerformanceMeasureSubcategoryOption.Create(subcategoryOptionIDBase + 2, performanceMeasureSubcategory, $"{performanceMeasureSubcategoryName}Option2");
                var subcategoryOption3 = TestFramework.TestPerformanceMeasureSubcategoryOption.Create(subcategoryOptionIDBase + 3, performanceMeasureSubcategory, $"{performanceMeasureSubcategoryName}Option3");
                return performanceMeasureSubcategory;
            }
        }
    }
}
