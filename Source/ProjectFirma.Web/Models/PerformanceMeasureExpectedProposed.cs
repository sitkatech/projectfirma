/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureExpectedProposed.cs" company="Tahoe Regional Planning Agency">
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
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureExpectedProposed : IAuditableEntity, IPerformanceMeasureValue
    {
        public string ExpectedValueDisplay
        {
            get { return GetExpectedValueDisplay(ExpectedValue, PerformanceMeasure); }
        }

        private static string GetExpectedValueDisplay(double? expectedValue, PerformanceMeasure performanceMeasure)
        {
            return performanceMeasure.MeasurementUnitType.DisplayValue(expectedValue);
        }

        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.AllProposedProjects.Find(ProposedProjectID);
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasures.Find(PerformanceMeasureID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.AuditDescriptionString : ViewUtilities.NotFoundString;
                var expectedValue = GetExpectedValueDisplay(ExpectedValue, performanceMeasure);
                return $"Proposed Project: {projectName}, Performance Measure: {performanceMeasureName}, Expected Value: {expectedValue}";
            }
        }

        public string PerformanceMeasureSubcategoriesAsString
        {
            get
            {
                return PerformanceMeasureExpectedSubcategoryOptionProposeds.Any()
                    ? String.Join(", ",
                        PerformanceMeasureExpectedSubcategoryOptionProposeds.OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                            .Select(x => String.Format("[{0}: {1}]", x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName, x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName)))
                    : ViewUtilities.NoneString;
            }
        }

        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureSubcategoryOptions
        {
            get { return new List<IPerformanceMeasureValueSubcategoryOption>(PerformanceMeasureExpectedSubcategoryOptionProposeds.ToList()); }
        }
        public double? ReportedValue
        {
            get { return ExpectedValue; }
        }
    }
}
