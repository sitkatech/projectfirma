/*-----------------------------------------------------------------------
<copyright file="TaxonomyBranchOrganizationTypeExpenditure.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyBranchOrganizationTypeExpenditure
    {
        public readonly OrganizationType OrganizationType;
        public readonly HtmlString TaxonomyBranchName;
        public readonly HtmlString TaxonomyTrunkName;
        public readonly decimal ExpenditureAmount;

        public TaxonomyBranchOrganizationTypeExpenditure(OrganizationType organizationType, TaxonomyBranch taxonomyBranch, decimal expenditureAmount) : this(organizationType, taxonomyBranch.GetDisplayNameAsUrl(), taxonomyBranch.TaxonomyTrunk.GetDisplayNameAsUrl(), expenditureAmount)
        {
        }

        public TaxonomyBranchOrganizationTypeExpenditure(OrganizationType organizationType, string taxonomyBranchName, string taxonomyTrunkName, decimal expenditureAmount)
            : this(organizationType, new HtmlString(taxonomyBranchName), new HtmlString(taxonomyTrunkName), expenditureAmount)
        {
        }

        private TaxonomyBranchOrganizationTypeExpenditure(OrganizationType organizationType, HtmlString taxonomyBranchName, HtmlString taxonomyTrunkName, decimal expenditureAmount)
        {
            OrganizationType = organizationType;
            TaxonomyBranchName = taxonomyBranchName;
            TaxonomyTrunkName = taxonomyTrunkName;
            ExpenditureAmount = expenditureAmount;
        }
    }
}
