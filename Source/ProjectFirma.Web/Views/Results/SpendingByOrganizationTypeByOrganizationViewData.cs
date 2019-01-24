/*-----------------------------------------------------------------------
<copyright file="SpendingByOrganizationTypeByOrganizationViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByOrganizationTypeByOrganizationViewData : FirmaUserControlViewData
    {
        public List<OrganizationType> OrganizationTypes { get; }
        public List<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure> ProjectFundingSourceExpenditures { get; }
        public List<ITaxonomyTier> TaxonomyTiers { get; }
        public string TaxonomyTierDisplayName { get; }
        public Dictionary<int, IEnumerable<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure>> ProjectFundingSourceExpendituresByTaxonomyTierID { get; }

        public SpendingByOrganizationTypeByOrganizationViewData(TenantAttribute tenantAttribute, List<OrganizationType> organizationTypes, List<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, List<ITaxonomyTier> taxonomyTiers)
        {
            OrganizationTypes = organizationTypes;
            ProjectFundingSourceExpenditures = projectFundingSourceExpenditures;
            TaxonomyTiers = taxonomyTiers;
            TaxonomyTierDisplayName = TaxonomyTierHelpers.ToType().GetFieldDefinitionForTaxonomyLevel(tenantAttribute.TaxonomyLevel).ToType().GetFieldDefinitionLabel();

            ProjectFundingSourceExpendituresByTaxonomyTierID = ProjectFundingSourceExpenditures.GroupBy(x => {
                    switch (tenantAttribute.TaxonomyLevel.ToEnum)
                    {
                        case TaxonomyLevelEnum.Trunk:
                            return x.Project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunkID;
                        case TaxonomyLevelEnum.Branch:
                            return x.Project.TaxonomyLeaf.TaxonomyBranchID;
                        case TaxonomyLevelEnum.Leaf:
                            return x.Project.TaxonomyLeafID;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                })
                .ToDictionary(x => x.Key, x => x.ToList() as IEnumerable<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure>);
        }

    }
}
