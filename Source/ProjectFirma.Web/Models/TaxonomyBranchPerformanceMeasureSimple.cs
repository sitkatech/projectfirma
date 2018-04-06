/*-----------------------------------------------------------------------
<copyright file="TaxonomyBranchPerformanceMeasureSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
namespace ProjectFirma.Web.Models
{
    public class TaxonomyBranchPerformanceMeasureSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TaxonomyBranchPerformanceMeasureSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyBranchPerformanceMeasureSimple(int taxonomyBranchID, int performanceMeasureID, bool isPrimaryTaxonomyBranch)
            : this()
        {
            TaxonomyBranchID = taxonomyBranchID;
            PerformanceMeasureID = performanceMeasureID;
            IsPrimaryTaxonomyBranch = isPrimaryTaxonomyBranch;
        }

        public int TaxonomyBranchPerformanceMeasureID { get; set; }
        public int TaxonomyBranchID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public bool IsPrimaryTaxonomyBranch { get; set; }
    }
}
