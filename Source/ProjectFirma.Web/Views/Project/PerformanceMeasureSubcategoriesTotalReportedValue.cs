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
            get { return PerformanceMeasure.DisplayName; }
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
            get { return Project.GetSummaryUrl(); }
        }

        public MeasurementUnitType MeasurementUnitType
        {
            get { return PerformanceMeasure.Indicator.MeasurementUnitType; }
        }

        public string IndicatorSubcategoriesAsString
        {
            get
            {
                return PerformanceMeasureActualSubcategoryOptions.Any()
                    ? string.Join("\r\n",
                        PerformanceMeasureActualSubcategoryOptions.OrderBy(x => x.IndicatorSubcategory.IndicatorSubcategoryDisplayName)
                            .Select(x => string.Format("{0}: {1}", x.IndicatorSubcategory.IndicatorSubcategoryDisplayName, x.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName)))
                    : ViewUtilities.NoneString;
            }
        }

        public List<IPerformanceMeasureValueSubcategoryOption> IndicatorSubcategoryOptions
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