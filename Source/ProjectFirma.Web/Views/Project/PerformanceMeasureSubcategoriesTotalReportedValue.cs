/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureSubcategoriesTotalReportedValue.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class PerformanceMeasureSubcategoriesTotalReportedValue
    {
        public ProjectFirmaModels.Models.Project Project { get; }
        public ProjectFirmaModels.Models.PerformanceMeasure PerformanceMeasure { get; }
        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureActualSubcategoryOptions { get; }
        public double? TotalReportedValue { get; }

        public PerformanceMeasureSubcategoriesTotalReportedValue(ProjectFirmaModels.Models.Project project, List<IPerformanceMeasureValueSubcategoryOption> subcategoryOptions, ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure, double? totalReportedValue)
        {
            Project = project;
            PerformanceMeasureActualSubcategoryOptions = subcategoryOptions;
            PerformanceMeasure = performanceMeasure;
            TotalReportedValue = totalReportedValue;
        }

        public int PerformanceMeasureID => PerformanceMeasure.PerformanceMeasureID;

        public string ProjectName => Project.GetDisplayName();

        public string ProjectUrl => Project.GetDetailUrl();

        public decimal? CalculateWeightedTotalExpenditure()
        {
            var reportedValuesForAllSubcategories = PerformanceMeasure.GetReportedPerformanceMeasureValues(Project)
                .Where(x => FirmaDateUtilities.DateIsInReportingRange(x.CalendarYear))
                .Sum(x => x.GetReportedValue() ?? 0);
            if (Math.Abs(reportedValuesForAllSubcategories) < double.Epsilon)
            {
                return null;
            }

            var projectFundingSourceExpenditures = Project.ProjectFundingSourceExpenditures.Where(x => FirmaDateUtilities.DateIsInReportingRange(x.CalendarYear)).ToList();
            var weight = TotalReportedValue / reportedValuesForAllSubcategories;
            return projectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) * Convert.ToDecimal(weight);
        }

        public decimal? CalculateWeightedTotalExpenditurePerPerformanceMeasure()
        {
            var totalExpenditure = CalculateWeightedTotalExpenditure();

            if (totalExpenditure == 0 || TotalReportedValue == null || TotalReportedValue == 0)
                return null;

            return totalExpenditure / (decimal)TotalReportedValue.Value;
        }
    }
}
