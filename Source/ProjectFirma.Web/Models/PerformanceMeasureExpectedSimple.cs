/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureExpectedSimple.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureExpectedSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureExpectedSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureExpectedSimple(int performanceMeasureExpectedID, string displayName, int performanceMeasureID, double? expectedValue)
            : this()
        {
            PerformanceMeasureExpectedID = performanceMeasureExpectedID;
            DisplayName = displayName;
            PerformanceMeasureID = performanceMeasureID;
            ExpectedValue = expectedValue;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureExpectedSimple(PerformanceMeasureExpected performanceMeasureExpected)
            : this()
        {
            PerformanceMeasureExpectedID = performanceMeasureExpected.PerformanceMeasureExpectedID;
            DisplayName = performanceMeasureExpected.PerformanceMeasure.PerformanceMeasureDisplayName;
            PerformanceMeasureID = performanceMeasureExpected.PerformanceMeasureID;
            ExpectedValue = performanceMeasureExpected.ExpectedValue;
            PerformanceMeasureExpectedSubcategoryOptions = PerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(performanceMeasureExpected);
        }

        public PerformanceMeasureExpectedSimple(PerformanceMeasureExpectedProposed performanceMeasureExpectedProposed)
        {
            PerformanceMeasureExpectedID = performanceMeasureExpectedProposed.PerformanceMeasureExpectedProposedID;
            DisplayName = performanceMeasureExpectedProposed.PerformanceMeasure.PerformanceMeasureDisplayName;
            PerformanceMeasureID = performanceMeasureExpectedProposed.PerformanceMeasureID;
            ExpectedValue = performanceMeasureExpectedProposed.ExpectedValue;
            PerformanceMeasureExpectedSubcategoryOptions = PerformanceMeasureValueSubcategoryOption.GetAllPossibleSubcategoryOptions(performanceMeasureExpectedProposed);
        }

        public int PerformanceMeasureExpectedID { get; set; }
        public string DisplayName { get; set; }
        public int PerformanceMeasureID { get; set; }
        public double? ExpectedValue { get; set; }        
        public List<PerformanceMeasureExpectedSubcategoryOptionSimple> PerformanceMeasureExpectedSubcategoryOptions { get; set; }
    }
}
