/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierTwoSimple.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
    public class TaxonomyTierTwoSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TaxonomyTierTwoSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTierTwoSimple(int taxonomyTierTwoID, int taxonomyTierThreeID, string taxonomyTierTwoName, string taxonomyTierTwoDescription)
            : this()
        {
            TaxonomyTierTwoID = taxonomyTierTwoID;
            TaxonomyTierThreeID = taxonomyTierThreeID;
            TaxonomyTierTwoName = taxonomyTierTwoName;
            TaxonomyTierTwoDescription = taxonomyTierTwoDescription;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public TaxonomyTierTwoSimple(TaxonomyTierTwo taxonomyTierTwo)
            : this()
        {
            TaxonomyTierTwoID = taxonomyTierTwo.TaxonomyTierTwoID;
            TaxonomyTierThreeID = taxonomyTierTwo.TaxonomyTierThreeID;
            TaxonomyTierTwoName = taxonomyTierTwo.TaxonomyTierTwoName;
            TaxonomyTierTwoDescription = taxonomyTierTwo.TaxonomyTierTwoDescription;
            DisplayName = taxonomyTierTwo.DisplayName;
        }

        public int TaxonomyTierTwoID { get; set; }
        public int TaxonomyTierThreeID { get; set; }
        public string TaxonomyTierTwoName { get; set; }
        public string TaxonomyTierTwoDescription { get; set; }
        public string DisplayName { get; set; }
    }
}
