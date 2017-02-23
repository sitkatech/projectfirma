/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureSubcategoriesTotalReportedValue.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Models;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Project
{
    public class PerformanceMeasureSubcategoriesTotalReportedValue
    {
        public readonly Models.Project Project;
        public Models.PerformanceMeasure PerformanceMeasure { get; private set; }
        public readonly List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureActualSubcategoryOptions;
        public double? TotalReportedValue { get; private set; }

        public PerformanceMeasureSubcategoriesTotalReportedValue(Models.Project project, List<IPerformanceMeasureValueSubcategoryOption> subcategoryOptions, Models.PerformanceMeasure performanceMeasure, double? totalReportedValue)
        {
            Project = project;
            PerformanceMeasureActualSubcategoryOptions = subcategoryOptions;
            PerformanceMeasure = performanceMeasure;
            TotalReportedValue = totalReportedValue;
        }

        public int PerformanceMeasureID
        {
            get { return PerformanceMeasure.PerformanceMeasureID; }
        }
        public string PerformanceMeasureName
        {
            get { return PerformanceMeasure.PerformanceMeasureDisplayName; }
        }

        public string PerformanceMeasureUrl
        {
            get { return PerformanceMeasure.GetSummaryUrl(); }
        }

        public string ProjectName
        {
            get { return Project.DisplayName; }
        }
        public string ProjectUrl
        {
            get { return Project.GetDetailUrl(); }
        }

        public MeasurementUnitType MeasurementUnitType
        {
            get { return PerformanceMeasure.MeasurementUnitType; }
        }

        public string PerformanceMeasureSubcategoriesAsString
        {
            get
            {
                return PerformanceMeasureActualSubcategoryOptions.Any()
                    ? string.Join("\r\n",
                        PerformanceMeasureActualSubcategoryOptions.OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                            .Select(x => string.Format("{0}: {1}", x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName, x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName)))
                    : ViewUtilities.NoneString;
            }
        }

        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureSubcategoryOptions
        {
            get { return new List<IPerformanceMeasureValueSubcategoryOption>(PerformanceMeasureActualSubcategoryOptions); }
        }

        public string TotalReportedValueDisplay
        {
            get { return MeasurementUnitType.DisplayValue(TotalReportedValue); }
        }

        public decimal? CalculateWeightedTotalExpenditure()
        {
            var reportedValuesForAllSubcategories = PerformanceMeasure.GetReportedPerformanceMeasureValues(Project.ProjectID)
                .Where(x => FirmaDateUtilities.DateIsInReportingRange(x.CalendarYear))
                .Sum(x => x.ReportedValue ?? 0);
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
