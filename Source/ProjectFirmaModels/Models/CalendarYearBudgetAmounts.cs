/*-----------------------------------------------------------------------
<copyright file="CalendarYearMonetaryAmount.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
namespace ProjectFirmaModels.Models
{
    public class CalendarYearBudgetAmounts
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public CalendarYearBudgetAmounts()
        {
        }

        public CalendarYearBudgetAmounts(int calendarYear, decimal? securedAmount, decimal? targetedAmount)
        {
            CalendarYear = calendarYear;
            SecuredAmount = securedAmount;
            TargetedAmount = targetedAmount;
        }

        public CalendarYearBudgetAmounts(int calendarYear, decimal? securedAmount, decimal? targetedAmount, bool isRelevant)
        {
            CalendarYear = calendarYear;
            SecuredAmount = securedAmount;
            TargetedAmount = targetedAmount;
            IsRelevant = isRelevant;
        }

        public int CalendarYear { get; set; }
        public decimal? SecuredAmount { get; set; }
        public decimal? TargetedAmount { get; set; }
        // Only used by ExpectedFundingByCostType pages
        public bool? IsRelevant { get; set; }

    }
}
