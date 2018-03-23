/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierTwoOrganizationTypeExpenditure.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
    public class TaxonomyTierTwoOrganizationTypeExpenditure
    {
        public readonly OrganizationType OrganizationType;
        public readonly HtmlString TaxonomyTierTwoName;
        public readonly HtmlString TaxonomyTrunkName;
        public readonly decimal ExpenditureAmount;

        public TaxonomyTierTwoOrganizationTypeExpenditure(OrganizationType organizationType, TaxonomyTierTwo taxonomyTierTwo, decimal expenditureAmount) : this(organizationType, taxonomyTierTwo.GetDisplayNameAsUrl(), taxonomyTierTwo.TaxonomyTrunk.GetDisplayNameAsUrl(), expenditureAmount)
        {
        }

        public TaxonomyTierTwoOrganizationTypeExpenditure(OrganizationType organizationType, string taxonomyTierTwoName, string taxonomyTrunkName, decimal expenditureAmount)
            : this(organizationType, new HtmlString(taxonomyTierTwoName), new HtmlString(taxonomyTrunkName), expenditureAmount)
        {
        }

        private TaxonomyTierTwoOrganizationTypeExpenditure(OrganizationType organizationType, HtmlString taxonomyTierTwoName, HtmlString taxonomyTrunkName, decimal expenditureAmount)
        {
            OrganizationType = organizationType;
            TaxonomyTierTwoName = taxonomyTierTwoName;
            TaxonomyTrunkName = taxonomyTrunkName;
            ExpenditureAmount = expenditureAmount;
        }
    }
}
