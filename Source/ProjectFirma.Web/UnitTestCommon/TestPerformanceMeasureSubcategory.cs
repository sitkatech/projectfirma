/*-----------------------------------------------------------------------
<copyright file="TestPerformanceMeasureSubcategory.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
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
                var subcategoryOption1 = TestPerformanceMeasureSubcategoryOption.Create(subcategoryOptionIDBase + 1, performanceMeasureSubcategory, string.Format("{0}Option1", performanceMeasureSubcategoryName));
                var subcategoryOption2 = TestPerformanceMeasureSubcategoryOption.Create(subcategoryOptionIDBase + 2, performanceMeasureSubcategory, string.Format("{0}Option2", performanceMeasureSubcategoryName));
                var subcategoryOption3 = TestPerformanceMeasureSubcategoryOption.Create(subcategoryOptionIDBase + 3, performanceMeasureSubcategory, string.Format("{0}Option3", performanceMeasureSubcategoryName));
                return performanceMeasureSubcategory;
            }
        }
    }
}
