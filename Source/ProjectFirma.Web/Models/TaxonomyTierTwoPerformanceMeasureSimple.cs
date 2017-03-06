/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierTwoPerformanceMeasureSimple.cs" company="Tahoe Regional Planning Agency">
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
namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierTwoPerformanceMeasureSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TaxonomyTierTwoPerformanceMeasureSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwoPerformanceMeasureSimple(int taxonomyTierTwoPerformanceMeasureID, int taxonomyTierTwoID, int performanceMeasureID, bool isPrimaryTaxonomyTierTwo)
            : this()
        {
            TaxonomyTierTwoPerformanceMeasureID = taxonomyTierTwoPerformanceMeasureID;
            TaxonomyTierTwoID = taxonomyTierTwoID;
            PerformanceMeasureID = performanceMeasureID;
            IsPrimaryTaxonomyTierTwo = isPrimaryTaxonomyTierTwo;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public TaxonomyTierTwoPerformanceMeasureSimple(TaxonomyTierTwoPerformanceMeasure programPerformanceMeasure)
            : this()
        {
            TaxonomyTierTwoPerformanceMeasureID = programPerformanceMeasure.TaxonomyTierTwoPerformanceMeasureID;
            TaxonomyTierTwoID = programPerformanceMeasure.TaxonomyTierTwoID;
            PerformanceMeasureID = programPerformanceMeasure.PerformanceMeasureID;
            IsPrimaryTaxonomyTierTwo = programPerformanceMeasure.IsPrimaryTaxonomyTierTwo;
        }

        public int TaxonomyTierTwoPerformanceMeasureID { get; set; }
        public int TaxonomyTierTwoID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public bool IsPrimaryTaxonomyTierTwo { get; set; }
    }
}
