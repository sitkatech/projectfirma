using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Project
{
    public class EIPPerformanceMeasureSubcategoriesTotalReportedValue
    {
        public readonly Models.Project Project;
        public Models.EIPPerformanceMeasure EIPPerformanceMeasure { get; private set; }
        public readonly List<IEIPPerformanceMeasureValueSubcategoryOption> EIPPerformanceMeasureActualSubcategoryOptions;
        public double? TotalReportedValue { get; private set; }

        public EIPPerformanceMeasureSubcategoriesTotalReportedValue(Models.Project project, List<IEIPPerformanceMeasureValueSubcategoryOption> subcategoryOptions, Models.EIPPerformanceMeasure eipPerformanceMeasure, double? totalReportedValue)
        {
            Project = project;
            EIPPerformanceMeasureActualSubcategoryOptions = subcategoryOptions;
            EIPPerformanceMeasure = eipPerformanceMeasure;
            TotalReportedValue = totalReportedValue;
        }

        public int EIPPerformanceMeasureID
        {
            get { return EIPPerformanceMeasure.EIPPerformanceMeasureID; }
        }
        public string EIPPerformanceMeasureName
        {
            get { return EIPPerformanceMeasure.DisplayName; }
        }

        public string EIPPerformanceMeasureUrl
        {
            get { return EIPPerformanceMeasure.GetSummaryUrl(); }
        }

        public string ProjectName
        {
            get { return Project.DisplayName; }
        }
        public string ProjectUrl
        {
            get { return Project.GetSummaryUrl(); }
        }

        public EIPPerformanceMeasureType EIPPerformanceMeasureType
        {
            get { return EIPPerformanceMeasure.EIPPerformanceMeasureType; }
        }

        public MeasurementUnitType MeasurementUnitType
        {
            get { return EIPPerformanceMeasure.Indicator.MeasurementUnitType; }
        }

        public string IndicatorSubcategoriesAsString
        {
            get
            {
                return EIPPerformanceMeasureActualSubcategoryOptions.Any()
                    ? string.Join("\r\n",
                        EIPPerformanceMeasureActualSubcategoryOptions.OrderBy(x => x.IndicatorSubcategory.IndicatorSubcategoryDisplayName)
                            .Select(x => string.Format("{0}: {1}", x.IndicatorSubcategory.IndicatorSubcategoryDisplayName, x.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName)))
                    : ViewUtilities.NoneString;
            }
        }

        public List<IEIPPerformanceMeasureValueSubcategoryOption> IndicatorSubcategoryOptions
        {
            get { return new List<IEIPPerformanceMeasureValueSubcategoryOption>(EIPPerformanceMeasureActualSubcategoryOptions); }
        }

        public string TotalReportedValueDisplay
        {
            get { return MeasurementUnitType.DisplayValue(TotalReportedValue); }
        }

        public decimal? CalculateWeightedTotalExpenditure()
        {
            var reportedValuesForAllSubcategories = EIPPerformanceMeasure.GetReportedEIPPerformanceMeasureValues(Project.ProjectID)
                .Where(x => ProjectFirmaDateUtilities.DateIsInReportingRange(x.CalendarYear))
                .Sum(x => x.ReportedValue ?? 0);
            if (Math.Abs(reportedValuesForAllSubcategories) < double.Epsilon)
            {
                return null;
            }

            var projectFundingSourceExpenditures = Project.ProjectFundingSourceExpenditures.Where(x => ProjectFirmaDateUtilities.DateIsInReportingRange(x.CalendarYear)).ToList();
            var weight = TotalReportedValue / reportedValuesForAllSubcategories;
            return projectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) * Convert.ToDecimal(weight);
        }

        public decimal? CalculateWeightedTotalExpenditurePerEIPPerformanceMeasure()
        {
            var totalExpenditure = CalculateWeightedTotalExpenditure();

            if (totalExpenditure == 0 || TotalReportedValue == null || TotalReportedValue == 0)
                return null;

            return totalExpenditure / (decimal)TotalReportedValue.Value;
        }
    }
}