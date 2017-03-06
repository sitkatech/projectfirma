/*-----------------------------------------------------------------------
<copyright file="TestPerformanceMeasureExpected.cs" company="Tahoe Regional Planning Agency">
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
        public static class TestPerformanceMeasureExpected
        {
            public static PerformanceMeasureExpected Create()
            {
                var project = TestProject.Create();
                var performanceMeasure = TestPerformanceMeasure.Create();
                return Create(project, performanceMeasure);
            }

            public static PerformanceMeasureExpected Create(Project project, PerformanceMeasure performanceMeasure)
            {
                var performanceMeasureExpected = PerformanceMeasureExpected.CreateNewBlank(project, performanceMeasure);
                return performanceMeasureExpected;
            }

            public static PerformanceMeasureExpected Create(int performanceMeasureExpectedID, Project project, PerformanceMeasure performanceMeasure, double expectedValue)
            {
                var performanceMeasureExpected = PerformanceMeasureExpected.CreateNewBlank(project, performanceMeasure);
                performanceMeasureExpected.PerformanceMeasureExpectedID = performanceMeasureExpectedID;
                performanceMeasureExpected.ExpectedValue = expectedValue;
                return performanceMeasureExpected;
            }
        }
    }
}
