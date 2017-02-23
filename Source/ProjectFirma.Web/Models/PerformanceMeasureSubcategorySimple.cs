/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureSubcategorySimple.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureSubcategorySimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureSubcategorySimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureSubcategorySimple(PerformanceMeasureSubcategory performanceMeasureSubcategory) : this()
        {
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
            PerformanceMeasureID = performanceMeasureSubcategory.PerformanceMeasureID;
            PerformanceMeasureSubcategoryDisplayName = performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
            ShowOnChart = performanceMeasureSubcategory.ShowOnChart;
            PerformanceMeasureSubcategoryOptions = performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.ToList().Select(x => new PerformanceMeasureSubcategoryOptionSimple(x)).ToList();
        }

        public int PerformanceMeasureSubcategoryID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public string PerformanceMeasureSubcategoryDisplayName { get; set; }
        public bool ShowOnChart { get; set; }
        public List<PerformanceMeasureSubcategoryOptionSimple> PerformanceMeasureSubcategoryOptions { get; set; }
    }
}
