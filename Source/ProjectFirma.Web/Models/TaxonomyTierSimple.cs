/*-----------------------------------------------------------------------
<copyright file="TaxonomyBranchSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TaxonomyTierSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public TaxonomyTierSimple(TaxonomyBranch taxonomyBranch) : this()
        {
            TaxonomyTierID = taxonomyBranch.TaxonomyBranchID;
            DisplayName = taxonomyBranch.GetDisplayName();
            ParentTaxonomyID = taxonomyBranch.TaxonomyTrunkID;
        }
        public TaxonomyTierSimple(TaxonomyTrunk taxonomyTrunk) : this()
        {
            TaxonomyTierID = taxonomyTrunk.TaxonomyTrunkID;
            DisplayName = taxonomyTrunk.GetDisplayName();
            ParentTaxonomyID = null; //trunks don't have parents
        }
        public TaxonomyTierSimple(TaxonomyLeaf taxonomyLeaf) : this()
        {
            TaxonomyTierID = taxonomyLeaf.TaxonomyLeafID;
            DisplayName = taxonomyLeaf.GetDisplayName();
            ParentTaxonomyID = taxonomyLeaf.TaxonomyBranchID;
        }

        public TaxonomyTierSimple(TaxonomyTier taxonomyTier) : this()
        {
            TaxonomyTierID = taxonomyTier.TaxonomyTierID;
            DisplayName = taxonomyTier.DisplayName;
        }

        public int TaxonomyTierID { get; set; }
        public string DisplayName { get; set; }
        public int? ParentTaxonomyID { get; set; }
    }
}
