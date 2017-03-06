/*-----------------------------------------------------------------------
<copyright file="BudgetsValidationResult.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BudgetsValidationResult
    {
        private readonly List<string> _warningMessages;

        public BudgetsValidationResult()
        {
            _warningMessages = new List<string>();
        }

        public BudgetsValidationResult(Dictionary<Models.FundingSource, HashSet<int>> missingFundingSourceYears)
            : this(missingFundingSourceYears, new List<int>())
        {
        }

        public BudgetsValidationResult(List<int> missingYears)
            : this(new Dictionary<Models.FundingSource, HashSet<int>>(), missingYears)
        {
        }

        public BudgetsValidationResult(Dictionary<Models.FundingSource, HashSet<int>> missingFundingSourceYears, List<int> missingYears) :this()
        {
            if (missingYears.Any())
            {
                _warningMessages.Add(string.Format("Missing Budget Amounts for {0}", string.Join(", ", missingYears)));
            }

            if (missingFundingSourceYears.Any())
            {
                _warningMessages.AddRange(
                    missingFundingSourceYears.Select(
                        missingFundingSourceYear =>
                            string.Format("Missing Budget Amounts for Funding Source '{0}' for the following years: {1}",
                                missingFundingSourceYear.Key.DisplayName,
                                string.Join(", ", missingFundingSourceYear.Value))).ToList());
            }
        }

        public BudgetsValidationResult(string customErrorMessage)
        {
            _warningMessages = new List<string> {customErrorMessage};
        }

        public List<string> GetWarningMessages()
        {
            return _warningMessages;
        }

        public bool IsValid
        {
            get { return !_warningMessages.Any(); }
        }
    }
}
