/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditure.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectFundingSourceExpenditure : IAuditableEntity, ICostTypeFundingSourceExpenditure
    {
        public decimal? GetMonetaryAmount()
        {
            return ExpenditureAmount;
        }

        public string GetAuditDescriptionString()
        {
            var expenditureAmount = ExpenditureAmount.ToStringCurrency();
            return
                $"Project: {ProjectID}, Funding Source: {FundingSourceID}, Year: {CalendarYear},  Expenditure: {expenditureAmount}";
        }

        public ProjectFundingSourceExpenditure(int projectID, int fundingSourceID, int calendarYear, decimal expenditureAmount, int? costTypeID) : this()
        {
            this.ProjectFundingSourceExpenditureID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.ProjectID = projectID;
            this.FundingSourceID = fundingSourceID;
            this.CalendarYear = calendarYear;
            this.ExpenditureAmount = expenditureAmount;
            this.CostTypeID = costTypeID;
        }
    }
}
