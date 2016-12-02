using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureReportedValue : IPerformanceMeasureReportedValue
    {
        public readonly Project Project;
        public int CalendarYear { get; private set; }
        public PerformanceMeasure PerformanceMeasure { get; private set; }
        public double? ReportedValue { get; private set; }

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
            get { return PerformanceMeasure.MeasurementUnitType; }
        }

        public readonly List<PerformanceMeasureActualSubcategoryOption> PerformanceMeasureActualSubcategoryOptions;

        private PerformanceMeasureReportedValue(PerformanceMeasureActual performanceMeasureActual)
        {
            PerformanceMeasure = performanceMeasureActual.PerformanceMeasure;
            CalendarYear = performanceMeasureActual.CalendarYear;
            ReportedValue = performanceMeasureActual.ActualValue;
            Project = performanceMeasureActual.Project;
            PerformanceMeasureActualSubcategoryOptions = performanceMeasureActual.PerformanceMeasureActualSubcategoryOptions.ToList();
        }

        public PerformanceMeasureReportedValue(PerformanceMeasure performanceMeasure, Project project, int calendarYear, double reportedValue)
        {
            PerformanceMeasure = performanceMeasure;
            CalendarYear = calendarYear;
            ReportedValue = reportedValue;
            Project = project;
            PerformanceMeasureActualSubcategoryOptions = new List<PerformanceMeasureActualSubcategoryOption>();
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

        public string ReportedValueDisplay
        {
            get { return MeasurementUnitType.DisplayValue(ReportedValue); }
        }

        public static List<PerformanceMeasureReportedValue> MakeFromList(IEnumerable<PerformanceMeasureActual> performanceMeasureActuals)
        {
            return performanceMeasureActuals.Select(x => new PerformanceMeasureReportedValue(x)).ToList();
        }
        
        public decimal? CalculateWeightedAnnualExpenditure()
        {
            var reportedValuesForAllSubcategories = PerformanceMeasure.GetReportedPerformanceMeasureValues(Project.ProjectID).Where(x => x.CalendarYear == CalendarYear).Sum(x => x.ReportedValue ?? 0);
            if (Math.Abs(reportedValuesForAllSubcategories) < double.Epsilon)
            {
                return null;
            }

            var projectFundingSourceExpenditures = Project.ProjectFundingSourceExpenditures.Where(x => x.CalendarYear == CalendarYear).ToList();
            var weight = ReportedValue / reportedValuesForAllSubcategories;
            return projectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) * Convert.ToDecimal(weight);
        }

        public decimal? CalculateWeightedAnnualExpenditurePerPerformanceMeasure()
        {
            var annualExpenditure = CalculateWeightedAnnualExpenditure();

            if (annualExpenditure == 0 || ReportedValue == null || ReportedValue == 0)
                return null;

            return annualExpenditure / (decimal)ReportedValue.Value;
        }
    }
}