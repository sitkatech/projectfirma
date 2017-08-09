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
        public static readonly string FoundIncompletePerformanceMeasureRowsMessage =
            $"Found incomplete {MultiTenantHelpers.GetPerformanceMeasureName()} rows. You must either delete irrelevant rows, or provide complete information for each row.";

        public static readonly string FoundDuplicatePerformanceMeasureRowsMessage = $"Found duplicate rows. The {Models.FieldDefinition.PerformanceMeasureSubcategory.GetFieldDefinitionLabelPluralized()} must be unique for each {MultiTenantHelpers.GetPerformanceMeasureName()}. Collapse the duplicate rows into one entry row then save the page.";

        private readonly List<string> _warningMessages;

        public readonly HashSet<int> PerformanceMeasureActualUpdatesWithWarnings;

        public PerformanceMeasuresValidationResult(HashSet<int> missingYears, HashSet<int> performanceMeasureActualUpdatesWithIncompleteWarnings, HashSet<int> performanceMeasureActualUpdatesWithDuplicateWarnings)
        {
            var ints = new HashSet<int>();
            ints.UnionWith(performanceMeasureActualUpdatesWithIncompleteWarnings);
            ints.UnionWith(performanceMeasureActualUpdatesWithDuplicateWarnings);

            PerformanceMeasureActualUpdatesWithWarnings = ints;
            _warningMessages = new List<string>();
            if (missingYears.Any())
            {
                _warningMessages.Add(
                    $"Missing {MultiTenantHelpers.GetPerformanceMeasureName()} for {string.Join(", ", missingYears)}");
            }
            if (performanceMeasureActualUpdatesWithIncompleteWarnings.Any())
            {
                _warningMessages.Add(FoundIncompletePerformanceMeasureRowsMessage);
            }
            if (performanceMeasureActualUpdatesWithDuplicateWarnings.Any())
            {
                _warningMessages.Add(FoundDuplicatePerformanceMeasureRowsMessage);
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

        public bool IsValid => !_warningMessages.Any();
    }
}
