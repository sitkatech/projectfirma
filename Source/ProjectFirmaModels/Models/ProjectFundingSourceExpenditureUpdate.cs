/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditureUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectFundingSourceExpenditureUpdate : ICostTypeFundingSourceExpenditure
    {
        public decimal? GetMonetaryAmount()
        {
            return ExpenditureAmount;
        }

        public ProjectFundingSourceExpenditureUpdate(int projectUpdateBatchID, int fundingSourceID, int calendarYear, decimal expenditureAmount, int? costTypeID) : this()
        {
            ProjectFundingSourceExpenditureUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            ProjectUpdateBatchID = projectUpdateBatchID;
            FundingSourceID = fundingSourceID;
            CalendarYear = calendarYear;
            ExpenditureAmount = expenditureAmount;
            CostTypeID = costTypeID;
        }


        public ProjectFundingSourceExpenditureUpdate(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource, int calendarYear, decimal expenditureAmount, int? costTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            ProjectFundingSourceExpenditureUpdateID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            ProjectUpdateBatchID = projectUpdateBatch.ProjectUpdateBatchID;
            ProjectUpdateBatch = projectUpdateBatch;
            projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.Add(this);
            FundingSourceID = fundingSource.FundingSourceID;
            FundingSource = fundingSource;
            CostTypeID = costTypeID;
            fundingSource.ProjectFundingSourceExpenditureUpdates.Add(this);
            CalendarYear = calendarYear;
            ExpenditureAmount = expenditureAmount;
        }
    }

}
