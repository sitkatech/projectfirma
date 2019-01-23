/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActualSubcategoryOptionUpdateSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureActualSubcategoryOptionUpdateSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionUpdateSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionUpdateSimple(int performanceMeasureActualSubcategoryOptionUpdateID,
            int performanceMeasureActualUpdateID,
            int? performanceMeasureSubcategoryOptionID,
            int performanceMeasureID,
            int performanceMeasureSubcategoryID) : this()
        {
            PerformanceMeasureActualSubcategoryOptionUpdateID = performanceMeasureActualSubcategoryOptionUpdateID;
            PerformanceMeasureActualUpdateID = performanceMeasureActualUpdateID;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureID;
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        public PerformanceMeasureActualSubcategoryOptionUpdateSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureActualSubcategoryOption,
            PerformanceMeasureActualUpdate performanceMeasureActualUpdate)
            : this(
                performanceMeasureActualSubcategoryOption.PrimaryKey,
                performanceMeasureActualUpdate.PerformanceMeasureActualUpdateID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasure.PerformanceMeasureID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID)
        {
        }

        public int PerformanceMeasureActualSubcategoryOptionUpdateID { get; set; }
        public int PerformanceMeasureActualUpdateID { get; set; }
        [DisplayName("PerformanceMeasureSubcategory Option")]
        public int? PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }
    }
}
