/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditureAmount.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class ProjectFundingSourceCostTypeExpenditureAmount
    {
        public int FundingSourceID { get; }
        public string FundingSourceName { get; }
        public string FundingSourceDisplayName { get; }
        public CostType CostType { get; }
        public int CalendarYear { get; }
        public decimal? MonetaryAmount { get; }
        public bool IsRealEntry { get; }

        private ProjectFundingSourceCostTypeExpenditureAmount(int fundingSourceID, string fundingSourceName, string fundingSourceDisplayName, CostType costType, int calendarYear, decimal? monetaryAmount, bool isRealEntry)
        {
            FundingSourceID = fundingSourceID;
            FundingSourceName = fundingSourceName;
            FundingSourceDisplayName = fundingSourceDisplayName;
            CostType = costType;
            CalendarYear = calendarYear;
            MonetaryAmount = monetaryAmount;
            IsRealEntry = isRealEntry;
        }

        public static List<ProjectFundingSourceCostTypeExpenditureAmount> CreateFromProjectFundingSourceExpenditures(List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            return projectFundingSourceExpenditures.Select(x => new ProjectFundingSourceCostTypeExpenditureAmount(x.FundingSource.FundingSourceID, x.FundingSource.FundingSourceName, x.FundingSource.GetDisplayName(), x.CostType, x.CalendarYear, x.GetMonetaryAmount(), true)).ToList();
        }
    }
}
