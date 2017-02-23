/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierThreeSimple.cs" company="Tahoe Regional Planning Agency">
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
namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierThreeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TaxonomyTierThreeSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierThreeSimple(int taxonomyTierThreeID, string taxonomyTierThreeName, string taxonomyTierThreeDescription, string taxonomyTierThreeColor)
            : this()
        {
            TaxonomyTierThreeID = taxonomyTierThreeID;
            TaxonomyTierThreeName = taxonomyTierThreeName;
            TaxonomyTierThreeDescription = taxonomyTierThreeDescription;
            TaxonomyTierThreeColor = taxonomyTierThreeColor;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public TaxonomyTierThreeSimple(TaxonomyTierThree taxonomyTierThree)
            : this()
        {
            TaxonomyTierThreeID = taxonomyTierThree.TaxonomyTierThreeID;
            TaxonomyTierThreeName = taxonomyTierThree.TaxonomyTierThreeName;
            TaxonomyTierThreeDescription = taxonomyTierThree.TaxonomyTierThreeDescription;
            TaxonomyTierThreeColor = taxonomyTierThree.ThemeColor;
            DisplayName = taxonomyTierThree.DisplayName;
        }

        public int TaxonomyTierThreeID { get; set; }
        public string TaxonomyTierThreeName { get; set; }
        public string TaxonomyTierThreeDescription { get; set; }
        public string TaxonomyTierThreeColor { get; set; }
        public string DisplayName { get; set; }
    }
}
