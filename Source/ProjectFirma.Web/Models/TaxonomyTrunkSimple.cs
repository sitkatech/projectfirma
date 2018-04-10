/*-----------------------------------------------------------------------
<copyright file="TaxonomyTrunkSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
    public class TaxonomyTrunkSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TaxonomyTrunkSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public TaxonomyTrunkSimple(int taxonomyTrunkID, string taxonomyTrunkName, string taxonomyTrunkDescription, string taxonomyTrunkColor)
            : this()
        {
            TaxonomyTrunkID = taxonomyTrunkID;
            TaxonomyTrunkName = taxonomyTrunkName;
            TaxonomyTrunkDescription = taxonomyTrunkDescription;
            TaxonomyTrunkColor = taxonomyTrunkColor;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public TaxonomyTrunkSimple(TaxonomyTrunk taxonomyTrunk)
            : this()
        {
            TaxonomyTrunkID = taxonomyTrunk.TaxonomyTrunkID;
            TaxonomyTrunkName = taxonomyTrunk.TaxonomyTrunkName;
            TaxonomyTrunkDescription = taxonomyTrunk.TaxonomyTrunkDescription;
            TaxonomyTrunkColor = taxonomyTrunk.ThemeColor;
            DisplayName = taxonomyTrunk.DisplayName;
        }

        public int TaxonomyTrunkID { get; set; }
        public string TaxonomyTrunkName { get; set; }
        public string TaxonomyTrunkDescription { get; set; }
        public string TaxonomyTrunkColor { get; set; }
        public string DisplayName { get; set; }
    }
}
