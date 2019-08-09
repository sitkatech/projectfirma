/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceBudgetUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
    public partial class ProjectFundingSourceBudgetUpdate : IAuditableEntity, ICostTypeFundingSourceBudgetAmount
    {
        public string GetAuditDescriptionString()
        {
            return $"ProjectUpdateBatch: {ProjectUpdateBatchID}, Funding Source: {FundingSourceID}, Request Amount: {TargetedAmount.ToStringCurrency()}";
        }
        public decimal? GetMonetaryAmount(bool isSecured)
        {
            return isSecured ? SecuredAmount : TargetedAmount;
        }

        public void SetSecuredAndTargetedAmounts(decimal? securedAmount, decimal? targetedAmount)
        {
            SecuredAmount = securedAmount;
            TargetedAmount = targetedAmount;
        }

        public ProjectFundingSourceBudgetUpdate(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource, int? calendarYear, decimal securedAmount, decimal targetedAmount, int? costTypeID) : this()
        {
            ProjectFundingSourceBudgetUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            ProjectUpdateBatch = projectUpdateBatch;
            FundingSourceID = fundingSource.FundingSourceID;
            FundingSource = fundingSource;
            CalendarYear = calendarYear;
            SecuredAmount = securedAmount;
            TargetedAmount = targetedAmount;
            CostTypeID = costTypeID;
        }
    }
}