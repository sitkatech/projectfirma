/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActualSubcategoryOptionSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureActualSubcategoryOptionSimple
    {
        public int PerformanceMeasureActualSubcategoryOptionID { get; set; }
        public int PerformanceMeasureActualID { get; set; }
        [DisplayName("Subcategory Option")]
        public int? PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionSimple(int performanceMeasureActualSubcategoryOptionID, int performanceMeasureActualID, int performanceMeasureSubcategoryOptionID, int performanceMeasureID, int performanceMeasureSubcategoryID) : this()
        {
            PerformanceMeasureActualSubcategoryOptionID = performanceMeasureActualSubcategoryOptionID;
            PerformanceMeasureActualID = performanceMeasureActualID;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureID;
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureActualSubcategoryOptionSimple(PerformanceMeasureActualSubcategoryOption performanceMeasureActualSubcategoryOption) : this()
        {
            PerformanceMeasureActualSubcategoryOptionID = performanceMeasureActualSubcategoryOption.PerformanceMeasureActualSubcategoryOptionID;
            PerformanceMeasureActualID = performanceMeasureActualSubcategoryOption.PerformanceMeasureActualID;
            PerformanceMeasureSubcategoryOptionID = performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            PerformanceMeasureID = performanceMeasureActualSubcategoryOption.PerformanceMeasureID;
            PerformanceMeasureSubcategoryID = performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryID;
        }

        public PerformanceMeasureActualSubcategoryOptionSimple(PerformanceMeasureValueSubcategoryOption performanceMeasureActualSubcategoryOption, PerformanceMeasureActual performanceMeasureActual)
            : this(
                performanceMeasureActualSubcategoryOption.PrimaryKey,
                performanceMeasureActual.PerformanceMeasureActualID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryOptionID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureID,
                performanceMeasureActualSubcategoryOption.PerformanceMeasureSubcategoryID)
        {
        }
    }
}
