﻿/*-----------------------------------------------------------------------
<copyright file="TestPerformanceMeasureSubcategoryOption.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirmaModels.Models;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureSubcategoryOption
        {
            public static PerformanceMeasureSubcategoryOption Create(int performanceMeasureSubcategoryOptionID, PerformanceMeasureSubcategory performanceMeasureSubcategory, string performanceMeasureSubcategoryOptionName)
            {
                var performanceMeasureSubcategoryOption = new PerformanceMeasureSubcategoryOption(performanceMeasureSubcategory, performanceMeasureSubcategoryOptionName, false, false);
                performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
                return performanceMeasureSubcategoryOption;
            }

            public static PerformanceMeasureSubcategoryOption Create(DatabaseEntities dbContext, int performanceMeasureSubcategoryOptionID, PerformanceMeasureSubcategory performanceMeasureSubcategory, string performanceMeasureSubcategoryOptionName)
            {
                var performanceMeasureSubcategoryOption = Create(performanceMeasureSubcategoryOptionID, performanceMeasureSubcategory, performanceMeasureSubcategoryOptionName);
                dbContext.AllPerformanceMeasureSubcategoryOptions.Add(performanceMeasureSubcategoryOption);
                return performanceMeasureSubcategoryOption;
            }
        }
    }
}
