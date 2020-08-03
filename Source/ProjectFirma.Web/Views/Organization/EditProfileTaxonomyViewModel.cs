/*-----------------------------------------------------------------------
<copyright file="EditProfileTaxonomyViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;


namespace ProjectFirma.Web.Views.Organization
{
    public class EditProfileTaxonomyViewModel : FormViewModel
    {
        public int OrganizationID { get; set; }

        public List<string> TaxonomyCompoundKeys { get; set; }
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProfileTaxonomyViewModel()
        {
        }

        public EditProfileTaxonomyViewModel(ProjectFirmaModels.Models.Organization organization, List<string> taxonomyCompoundKeys)
        {
            OrganizationID = organization.OrganizationID;
            TaxonomyCompoundKeys = taxonomyCompoundKeys;
        }

        public void UpdateModel(ProjectFirmaModels.Models.Organization organization, FirmaSession currentFirmaSession,
            DatabaseEntities databaseEntities,
            ICollection<MatchmakerOrganizationTaxonomyTrunk> allMatchMakerOrganizationTaxonomyTrunks,
            ICollection<MatchmakerOrganizationTaxonomyBranch> allMatchMakerOrganizationTaxonomyBranches,
            ICollection<MatchmakerOrganizationTaxonomyLeaf> allMatchMakerOrganizationTaxonomyLeafs
            )
        {
            // determine which taxonomy level each key in TaxonomyCompoundKeys is
            var updatedTaxonomyTrunkIDs = new List<int>();
            var updatedTaxonomyBranchIDs = new List<int>();
            var updatedTaxonomyLeafIDs = new List<int>();
            foreach (var compoundKey in TaxonomyCompoundKeys)
            {
                var levelAndID = TaxonomyTierHelpers.GetTaxonomyLevelAndIDFromComboTreeNodeKey(compoundKey);
                switch (levelAndID.Item1)
                {
                    case TaxonomyLevelEnum.Trunk:
                        updatedTaxonomyTrunkIDs.Add(levelAndID.Item2);
                        break;
                    case TaxonomyLevelEnum.Branch:
                        updatedTaxonomyBranchIDs.Add(levelAndID.Item2);
                        break;
                    case TaxonomyLevelEnum.Leaf:
                        updatedTaxonomyLeafIDs.Add(levelAndID.Item2);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            if (MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                // merge trunk
                var taxonomyTrunksUpdated = updatedTaxonomyTrunkIDs.Select(x => new MatchmakerOrganizationTaxonomyTrunk(organization.OrganizationID, x, true)).ToList();
                organization.MatchmakerOrganizationTaxonomyTrunks.Merge(taxonomyTrunksUpdated,
                    allMatchMakerOrganizationTaxonomyTrunks,
                    (x, y) => x.OrganizationID == y.OrganizationID && x.TaxonomyTrunkID == y.TaxonomyTrunkID,
                    HttpRequestStorage.DatabaseEntities);
            }
            
            if (MultiTenantHelpers.IsTaxonomyLevelBranch() || MultiTenantHelpers.IsTaxonomyLevelTrunk())
            {
                // merge branch
                var taxonomyBranchesUpdated = updatedTaxonomyBranchIDs.Select(x => new MatchmakerOrganizationTaxonomyBranch(organization.OrganizationID, x, true)).ToList();
                organization.MatchmakerOrganizationTaxonomyBranches.Merge(taxonomyBranchesUpdated,
                    allMatchMakerOrganizationTaxonomyBranches,
                    (x, y) => x.OrganizationID == y.OrganizationID && x.TaxonomyBranchID == y.TaxonomyBranchID,
                    HttpRequestStorage.DatabaseEntities);
            }
            
            // merge leaf
            var taxonomyLeafsUpdated = updatedTaxonomyLeafIDs.Select(x => new MatchmakerOrganizationTaxonomyLeaf(organization.OrganizationID, x, true)).ToList();
            organization.MatchmakerOrganizationTaxonomyLeafs.Merge(taxonomyLeafsUpdated,
                allMatchMakerOrganizationTaxonomyLeafs,
                (x, y) => x.OrganizationID == y.OrganizationID && x.TaxonomyLeafID == y.TaxonomyLeafID,
                HttpRequestStorage.DatabaseEntities);
        }
    }
}
