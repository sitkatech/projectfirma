using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using Newtonsoft.Json;

namespace ProjectFirma.Web.Models
{
    public partial class IndicatorSubcategory : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get { return IndicatorSubcategoryDisplayName; }
        }

        public bool ShowOnChart
        {
            get { return !String.IsNullOrWhiteSpace(ChartConfigurationJson); }
        }

        public static List<GoogleChartJson> MakeGoogleChartJsonsForSubcategories(PerformanceMeasure performanceMeasure,
            IEnumerable<PerformanceMeasureReportedValue> performanceMeasureReportedValues,
            IEnumerable<int> yearRange)
        {
            return
                performanceMeasure.IndicatorSubcategories.Where(x => x.ShowOnChart)
                    .Select(x => MakeGoogleChartJson(performanceMeasure, x, performanceMeasureReportedValues, yearRange)).ToList();
        }

        private static GoogleChartJson MakeGoogleChartJson(PerformanceMeasure performanceMeasure, IndicatorSubcategory indicatorSubcategory, IEnumerable<PerformanceMeasureReportedValue> performanceMeasureReportedValues, IEnumerable<int> yearRange)
        {
            var indicatorSubcategoryOptionsWithCalendarYearReportedValues = indicatorSubcategory.IndicatorSubcategoryOptions.ToDictionary(x => x.ChartName, x =>
            {
                var calendarYearReportedValuesDict =
                    performanceMeasureReportedValues.SelectMany(pmav => pmav.PerformanceMeasureActualSubcategoryOptions)
                        .Where(pmavsco => indicatorSubcategory.IndicatorSubcategoryID == pmavsco.IndicatorSubcategoryID && pmavsco.IndicatorSubcategoryOptionID == x.IndicatorSubcategoryOptionID)
                        .GroupBy(pmavsco => pmavsco.PerformanceMeasureActual.CalendarYear)
                        .ToDictionary(cy => cy.Key, cy => cy.Sum(exp => exp.PerformanceMeasureActual.ActualValue));

                var calendarYearReportedValues =
                    yearRange.OrderBy(year => year).Select(year => new CalendarYearReportedValue(year, calendarYearReportedValuesDict.ContainsKey(year) ? calendarYearReportedValuesDict[year] : 0));
                return calendarYearReportedValues;
            });

            var googleChartJson = MakeGoogleChartJsonForIndicatorSubcategory(performanceMeasure, yearRange, indicatorSubcategory, indicatorSubcategoryOptionsWithCalendarYearReportedValues, indicatorSubcategory.IndicatorSubcategoryDisplayName);
            return googleChartJson;
        }

        private static GoogleChartJson MakeGoogleChartJsonForIndicatorSubcategory(PerformanceMeasure performanceMeasure,
            IEnumerable<int> yearRange,
            IndicatorSubcategory indicatorSubcategory,
            Dictionary<string, IEnumerable<CalendarYearReportedValue>> indicatorSubcategoryOptionsWithCalendarYearReportedValues,
            string legendTitle)
        {
            var googleChartType = (GoogleChartType) Enum.Parse(typeof(GoogleChartType), indicatorSubcategory.ChartType);
            var googleChartDataTable = GetGoogleChartDataTableForPerformanceMeasure(yearRange, performanceMeasure.Indicator.MeasurementUnitType, googleChartType, indicatorSubcategoryOptionsWithCalendarYearReportedValues);
            var googleChartJson = MakeGoogleChartJsonForIndicatorSubcategory(indicatorSubcategory, googleChartDataTable);
            return googleChartJson;
        }

        public static GoogleChartJson MakeGoogleChartJsonForIndicatorSubcategory(IndicatorSubcategory indicatorSubcategory, GoogleChartDataTable googleChartDataTable)
        {
            var indicator = indicatorSubcategory.Indicator;

            var chartConfiguration = indicatorSubcategory.ShowOnChart
                ? JsonConvert.DeserializeObject<GoogleChartConfiguration>(indicatorSubcategory.ChartConfigurationJson)
                : new GoogleChartConfiguration(indicator.IndicatorDisplayName, indicator.MeasurementUnitType.MeasurementUnitTypeDisplayName.ToProperCase(), indicator.MeasurementUnitType);

            var indicatorID = indicator.IndicatorID;
            var indicatorSubcategoryID = indicatorSubcategory.IndicatorSubcategoryID;
            var chartName = string.Format("Indicator{0}IndicatorSubcategory{1}", indicatorID, indicatorSubcategoryID);
            var chartPopupUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(x => x.IndicatorChartPopup(indicatorID));
            var saveConfigurationUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(x => x.SaveChartConfiguration(indicatorID, indicatorSubcategoryID));
            var chartGroupID = indicatorID.ToString();
            var legendTitle = indicatorSubcategory.IndicatorSubcategoryDisplayName;
            var googleChartType = (GoogleChartType) Enum.Parse(typeof(GoogleChartType), indicatorSubcategory.ChartType);
            var googleChartJson = new GoogleChartJson(legendTitle, chartName, chartConfiguration, googleChartType, googleChartDataTable, chartPopupUrl, chartGroupID, saveConfigurationUrl);
            return googleChartJson;
        }

        public static GoogleChartDataTable MakeGoogleChartDataTableForIndicatorWithOnlyOneSubcategory(
            IIndicatorWithOnlyOneSubcategory indicatorWithOnlyOneSubcategory)
        {
            var googleChartType = (GoogleChartType) Enum.Parse(typeof(GoogleChartType), indicatorWithOnlyOneSubcategory.IndicatorSubcategory.ChartType);
            var swapAxes = indicatorWithOnlyOneSubcategory.IndicatorSubcategory.SwapChartAxes ?? false;
            if (swapAxes)
            {
                return GetGoogleDataTableForNonPerformanceMeasureIndicatorWithReportingPeriodsAsSubcategory(indicatorWithOnlyOneSubcategory, googleChartType);
            }
            return GetGoogleChartDataTableForNonPerformanceMeasureIndicator(indicatorWithOnlyOneSubcategory, googleChartType);
        }

        private static GoogleChartDataTable GetGoogleChartDataTableForPerformanceMeasure(IEnumerable<int> yearRange, MeasurementUnitType measurementUnitType, GoogleChartType googleChartType, Dictionary<string, IEnumerable<CalendarYearReportedValue>> indicatorSubcategoryOptionsWithCalendarYearReportedValues)
        {
            var seriesChartType = googleChartType == GoogleChartType.ComboChart ? GoogleChartType.LineChart : googleChartType;

            var googleChartRowCs = new List<GoogleChartRowC>();

            foreach (var year in yearRange.OrderBy(x => x))
            {
                var googleChartRowVs = new List<GoogleChartRowV> { new GoogleChartRowV(year, year.ToString()) };
                googleChartRowVs.AddRange(
                    indicatorSubcategoryOptionsWithCalendarYearReportedValues.OrderBy(x => x.Key)
                        .Select(x =>
                        {
                            //calendarYearReportedValue used to never be null, but commit 124877 changed flow so it can be null now, so catch null and return 0.
                            var calendarYearReportedValue = x.Value.SingleOrDefault(y => y.CalendarYear == year);
                            var reportedValue = calendarYearReportedValue == null ? 0 : calendarYearReportedValue.ReportedValue;
                            return new GoogleChartRowV(reportedValue, GoogleChartJson.GetFormattedValue(reportedValue, measurementUnitType));
                        }));

                googleChartRowCs.Add(new GoogleChartRowC(googleChartRowVs));
            }

            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn("Year", GoogleChartColumnDataType.String, seriesChartType) };
            googleChartColumns.AddRange(indicatorSubcategoryOptionsWithCalendarYearReportedValues.OrderBy(x => x.Key).Select(x => new GoogleChartColumn(x.Key, GoogleChartColumnDataType.Number, seriesChartType)));

            return new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
        }

        private static GoogleChartDataTable GetGoogleChartDataTableForNonPerformanceMeasureIndicator(IIndicatorWithOnlyOneSubcategory indicatorWithOnlyOneSubcategory, GoogleChartType googleChartType)
        {
            var rowCs = new List<GoogleChartRowC>();
            var hasTargets = (GetTargetValueType(indicatorWithOnlyOneSubcategory) != IndicatorTargetValueType.NoTarget);

            var indicatorReportingPeriods = indicatorWithOnlyOneSubcategory.GetIndicatorReportingPeriods();
            foreach (var indicatorReportingPeriod in indicatorReportingPeriods.OrderBy(x => x.ReportingPeriodBeginDate))
            {
                var rowVs = new List<GoogleChartRowV> { new GoogleChartRowV(indicatorReportingPeriod.ReportingPeriodLabel) };
                rowVs.AddRange(
                    indicatorWithOnlyOneSubcategory.GetIndicatorReportedValues()
                        .Where(x => x.IndicatorReportingPeriod.ReportingPeriodLabel == indicatorReportingPeriod.ReportingPeriodLabel)
                        .OrderBy(x => x.SortOrder)
                        .Select(
                            irviso =>
                                new GoogleChartRowV(irviso.ReportedValue,
                                    GoogleChartJson.GetFormattedValue(irviso.ReportedValue, indicatorWithOnlyOneSubcategory.Indicator.MeasurementUnitType))));

                if (hasTargets)
                {
                    rowVs.Add(new GoogleChartRowV(indicatorReportingPeriod.TargetValue, GetFormattedTargetValue(indicatorReportingPeriod, indicatorWithOnlyOneSubcategory)));
                }
                rowCs.Add(new GoogleChartRowC(rowVs));
            }

            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn("Reporting Period", GoogleChartColumnDataType.String, googleChartType) };
            var indicatorSubcategoryOptions = indicatorWithOnlyOneSubcategory.IndicatorSubcategory.IndicatorSubcategoryOptions;
            googleChartColumns.AddRange(
                indicatorSubcategoryOptions.OrderBy(x => x.SortOrder).Select(x => new GoogleChartColumn(x.IndicatorSubcategoryOptionName, GoogleChartColumnDataType.Number, googleChartType)));

            if (hasTargets)
            {
                // GoogleChartType for targets is always LINE
                googleChartColumns.Add(new GoogleChartColumn(GetTargetColumnLabel(indicatorWithOnlyOneSubcategory), GoogleChartColumnDataType.Number, GoogleChartType.LineChart));
            }

            return new GoogleChartDataTable(googleChartColumns, rowCs);
        }

        private static GoogleChartDataTable GetGoogleDataTableForNonPerformanceMeasureIndicatorWithReportingPeriodsAsSubcategory(IIndicatorWithOnlyOneSubcategory indicatorWithOnlyOneSubcategory, GoogleChartType googleChartType)
        {
            var indicator = indicatorWithOnlyOneSubcategory.Indicator;
            var googleChartColumns = new List<GoogleChartColumn> {
                new GoogleChartColumn(indicator.IndicatorDisplayName, GoogleChartColumnDataType.String, googleChartType)
            };
            var indicatorReportingPeriods = indicatorWithOnlyOneSubcategory.GetIndicatorReportingPeriods();
            googleChartColumns.AddRange(
                indicatorReportingPeriods.OrderBy(x => x.ReportingPeriodBeginDate)
                    .Select(
                        reportingPeriod =>
                            new GoogleChartColumn(reportingPeriod.ReportingPeriodID.ToString(),
                                reportingPeriod.ReportingPeriodLabel,
                                "number",
                                googleChartType,
                                GoogleChartAxisType.Primary)));


            var googleChartRowCs = new List<GoogleChartRowC>();
            var sustainabilityIndicatorReporteds = indicatorWithOnlyOneSubcategory.GetIndicatorReportedValues();
            foreach (var indicatorSubcategoryOption in indicatorWithOnlyOneSubcategory.IndicatorSubcategory.IndicatorSubcategoryOptions.OrderBy(x => x.SortOrder))
            {
                var googleChartRowVs = new List<GoogleChartRowV> { new GoogleChartRowV(indicatorSubcategoryOption.IndicatorSubcategoryOptionName) };
                googleChartRowVs.AddRange(
                    sustainabilityIndicatorReporteds.Where(
                        x => x.IndicatorReportedSubcategoryOptions.Any(y => y.IndicatorSubcategoryOptionID == indicatorSubcategoryOption.IndicatorSubcategoryOptionID))
                        .OrderBy(x => x.IndicatorReportingPeriod.ReportingPeriodBeginDate)
                        .Select(irviso => new GoogleChartRowV(irviso.ReportedValue, GoogleChartJson.GetFormattedValue(irviso.ReportedValue, indicator.MeasurementUnitType))));
                googleChartRowCs.Add(new GoogleChartRowC(googleChartRowVs));
            }

            var targetRowVs = new List<GoogleChartRowV>();
            var hasTargets = (GetTargetValueType(indicatorWithOnlyOneSubcategory) != IndicatorTargetValueType.NoTarget);
            if (hasTargets)
            {
                targetRowVs.Add(new GoogleChartRowV(GetTargetColumnLabel(indicatorWithOnlyOneSubcategory)));
                targetRowVs.AddRange(indicatorReportingPeriods.OrderBy(x => x.ReportingPeriodBeginDate).Select(x => new GoogleChartRowV(x.TargetValue, GetFormattedTargetValue(x, indicatorWithOnlyOneSubcategory))));
                googleChartRowCs.Add(new GoogleChartRowC(targetRowVs));    
            }
           
            return new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
        }

        private static string GetTargetColumnLabel(IIndicatorWithOnlyOneSubcategory indicatorWithOnlyOneSubcategory)
        {
            return GetTargetValueType(indicatorWithOnlyOneSubcategory) == IndicatorTargetValueType.OverallTarget ? indicatorWithOnlyOneSubcategory.GetIndicatorReportingPeriods().First().TargetValueDescription : "Target";
        }

        private static string GetFormattedTargetValue(IIndicatorReportingPeriod indicatorReportingPeriod, IIndicatorWithOnlyOneSubcategory indicatorWithOnlyOneSubcategory)
        {
            return GetTargetValueType(indicatorWithOnlyOneSubcategory) == IndicatorTargetValueType.OverallTarget
                ? String.Format("{0}", GoogleChartJson.GetFormattedValue(indicatorReportingPeriod.TargetValue, indicatorWithOnlyOneSubcategory.Indicator.MeasurementUnitType))
                : String.Format("{0} ({1})", GoogleChartJson.GetFormattedValue(indicatorReportingPeriod.TargetValue, indicatorWithOnlyOneSubcategory.Indicator.MeasurementUnitType), indicatorReportingPeriod.TargetValueDescription);
        }

        public static IndicatorTargetValueType GetTargetValueType(IIndicatorWithOnlyOneSubcategory indicatorWithOnlyOneSubcategory)
        {
            var indicatorReportingPeriods = indicatorWithOnlyOneSubcategory.GetIndicatorReportingPeriods();
            if (!indicatorReportingPeriods.Any(x => x.TargetValue.HasValue))
            {
                return IndicatorTargetValueType.NoTarget;
            }

            if (indicatorReportingPeriods.Select(x => String.Format("{0}{1}", x.TargetValue, x.TargetValueDescription)).Distinct().Count() == 1)
            {
                return IndicatorTargetValueType.OverallTarget;
            }
            return IndicatorTargetValueType.TargetPerReportingPeriod;
        }
    }
}