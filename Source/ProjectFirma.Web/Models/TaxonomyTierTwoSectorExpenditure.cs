/*-----------------------------------------------------------------------
<copyright file="TaxonomyTierTwoSectorExpenditure.cs" company="Sitka Technology Group">
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
using System.Web;

namespace ProjectFirma.Web.Models
{
    public class TaxonomyTierTwoSectorExpenditure
    {
        public readonly Sector Sector;
        public readonly HtmlString TaxonomyTierTwoName;
        public readonly HtmlString TaxonomyTierThreeName;
        public readonly decimal ExpenditureAmount;

        public TaxonomyTierTwoSectorExpenditure(Sector sector, TaxonomyTierTwo taxonomyTierTwo, decimal expenditureAmount) : this(sector, taxonomyTierTwo.GetDisplayNameAsUrl(), taxonomyTierTwo.TaxonomyTierThree.GetDisplayNameAsUrl(), expenditureAmount)
        {
        }

        public TaxonomyTierTwoSectorExpenditure(Sector sector, string taxonomyTierTwoName, string taxonomyTierThreeName, decimal expenditureAmount)
            : this(sector, new HtmlString(taxonomyTierTwoName), new HtmlString(taxonomyTierThreeName), expenditureAmount)
        {
        }

        private TaxonomyTierTwoSectorExpenditure(Sector sector, HtmlString taxonomyTierTwoName, HtmlString taxonomyTierThreeName, decimal expenditureAmount)
        {
            Sector = sector;
            TaxonomyTierTwoName = taxonomyTierTwoName;
            TaxonomyTierThreeName = taxonomyTierThreeName;
            ExpenditureAmount = expenditureAmount;
        }
    }
}
