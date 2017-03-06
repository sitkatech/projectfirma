/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasuresValidationResult.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PerformanceMeasuresValidationResult
    {
        public static readonly string FoundIncompletePerformanceMeasureRowsMessage = string.Format("Found incomplete {0} rows. You must either delete irrelevant rows, or provide complete information for each row.", MultiTenantHelpers.GetPerformanceMeasureName());

        private readonly List<string> _warningMessages;

        public readonly HashSet<int> PerformanceMeasureActualUpdatesWithWarnings;

        public PerformanceMeasuresValidationResult(HashSet<int> missingYears, HashSet<int> performanceMeasureActualUpdatesWithWarnings)
        {
            PerformanceMeasureActualUpdatesWithWarnings = performanceMeasureActualUpdatesWithWarnings;
            _warningMessages = new List<string>();
            if (missingYears.Any())
            {
                _warningMessages.Add(string.Format("Missing {0} for {1}", MultiTenantHelpers.GetPerformanceMeasureName(), string.Join(", ", missingYears)));
            }
            if (performanceMeasureActualUpdatesWithWarnings.Any())
            {
                _warningMessages.Add(FoundIncompletePerformanceMeasureRowsMessage);
            }
        }

        public PerformanceMeasuresValidationResult(string customErrorMessage)
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
