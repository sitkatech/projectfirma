using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureReportedValue : IEIPPerformanceMeasureReportedValue
    {
        public readonly Project Project;
        public int CalendarYear { get; private set; }
        public EIPPerformanceMeasure EIPPerformanceMeasure { get; private set; }
        public double? ReportedValue { get; private set; }

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

        public readonly List<EIPPerformanceMeasureActualSubcategoryOption> EIPPerformanceMeasureActualSubcategoryOptions;

        private EIPPerformanceMeasureReportedValue(EIPPerformanceMeasureActual eipPerformanceMeasureActual)
        {
            EIPPerformanceMeasure = eipPerformanceMeasureActual.EIPPerformanceMeasure;
            CalendarYear = eipPerformanceMeasureActual.CalendarYear;
            ReportedValue = eipPerformanceMeasureActual.ActualValue;
            Project = eipPerformanceMeasureActual.Project;
            EIPPerformanceMeasureActualSubcategoryOptions = eipPerformanceMeasureActual.EIPPerformanceMeasureActualSubcategoryOptions.ToList();
        }

        public EIPPerformanceMeasureReportedValue(EIPPerformanceMeasure eipPerformanceMeasure, Project project, int calendarYear, double reportedValue)
        {
            EIPPerformanceMeasure = eipPerformanceMeasure;
            CalendarYear = calendarYear;
            ReportedValue = reportedValue;
            Project = project;
            EIPPerformanceMeasureActualSubcategoryOptions = new List<EIPPerformanceMeasureActualSubcategoryOption>();
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

        public string ReportedValueDisplay
        {
            get { return MeasurementUnitType.DisplayValue(ReportedValue); }
        }

        public static List<EIPPerformanceMeasureReportedValue> MakeFromList(IEnumerable<EIPPerformanceMeasureActual> eipPerformanceMeasureActuals)
        {
            return eipPerformanceMeasureActuals.Select(x => new EIPPerformanceMeasureReportedValue(x)).ToList();
        }
        
        public decimal? CalculateWeightedAnnualExpenditure()
        {
            var reportedValuesForAllSubcategories = EIPPerformanceMeasure.GetReportedEIPPerformanceMeasureValues(Project.ProjectID).Where(x => x.CalendarYear == CalendarYear).Sum(x => x.ReportedValue ?? 0);
            if (Math.Abs(reportedValuesForAllSubcategories) < double.Epsilon)
            {
                return null;
            }

            var projectFundingSourceExpenditures = Project.ProjectFundingSourceExpenditures.Where(x => x.CalendarYear == CalendarYear).ToList();
            var weight = ReportedValue / reportedValuesForAllSubcategories;
            return projectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) * Convert.ToDecimal(weight);
        }

        public decimal? CalculateWeightedAnnualExpenditurePerEIPPerformanceMeasure()
        {
            var annualExpenditure = CalculateWeightedAnnualExpenditure();

            if (annualExpenditure == 0 || ReportedValue == null || ReportedValue == 0)
                return null;

            return annualExpenditure / (decimal)ReportedValue.Value;
        }
    }
}