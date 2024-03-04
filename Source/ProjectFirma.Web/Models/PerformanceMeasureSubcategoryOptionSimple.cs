/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureSubcategoryOptionSimple.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureSubcategoryOptionSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureSubcategoryOptionSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureSubcategoryOptionSimple(PerformanceMeasureSubcategoryOption performanceMeasureSubcategoryOption)
            : this()
        {
            PerformanceMeasureSubcategoryOptionID = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            PerformanceMeasureSubcategoryID = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryID;
            PerformanceMeasureSubcategoryOptionName = performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
            SortOrder = performanceMeasureSubcategoryOption.SortOrder;
            HasAssociatedActuals = performanceMeasureSubcategoryOption.HasDependentObjects();
            HasCurrentAssociatedActuals = performanceMeasureSubcategoryOption.HasCurrentDependentObjects();
            ShowOnFactSheet = performanceMeasureSubcategoryOption.ShowOnFactSheet;
            IsArchived = performanceMeasureSubcategoryOption.IsArchived;
           // if (HasCurrentAssociatedActuals)
           // {
                AssociatedProjectsCount = performanceMeasureSubcategoryOption.GetCurrentDependentProjectCount();
            //}

        }

        public int PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }
        public string PerformanceMeasureSubcategoryOptionName { get; set; }
        public int? SortOrder { get; set; }
        public bool HasAssociatedActuals { get; set; }
        public bool HasCurrentAssociatedActuals { get; set; }
        public bool ShowOnFactSheet { get; set; }
        public bool IsArchived { get; set; }
        public int AssociatedProjectsCount { get; set; }
    }
}
