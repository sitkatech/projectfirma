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
    public partial class PerformanceMeasureSubcategory : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get { return PerformanceMeasureSubcategoryDisplayName; }
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
                performanceMeasure.PerformanceMeasureSubcategories.Where(x => x.ShowOnChart)
                    .Select(x => MakeGoogleChartJson(performanceMeasure, x, performanceMeasureReportedValues, yearRange)).ToList();
        }

        private static GoogleChartJson MakeGoogleChartJson(PerformanceMeasure performanceMeasure, PerformanceMeasureSubcategory performanceMeasureSubcategory, IEnumerable<PerformanceMeasureReportedValue> performanceMeasureReportedValues, IEnumerable<int> yearRange)
        {
            var performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues = performanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.ToDictionary(x => x.ChartName, x =>
            {
                var calendarYearReportedValuesDict =
                    performanceMeasureReportedValues.SelectMany(pmav => pmav.PerformanceMeasureActualSubcategoryOptions)
                        .Where(pmavsco => performanceMeasureSubcategory.PerformanceMeasureSubcategoryID == pmavsco.PerformanceMeasureSubcategoryID && pmavsco.PerformanceMeasureSubcategoryOptionID == x.PerformanceMeasureSubcategoryOptionID)
                        .GroupBy(pmavsco => pmavsco.PerformanceMeasureActual.CalendarYear)
                        .ToDictionary(cy => cy.Key, cy => cy.Sum(exp => exp.PerformanceMeasureActual.ActualValue));

                var calendarYearReportedValues =
                    yearRange.OrderBy(year => year).Select(year => new CalendarYearReportedValue(year, calendarYearReportedValuesDict.ContainsKey(year) ? calendarYearReportedValuesDict[year] : 0));
                return calendarYearReportedValues;
            });

            var googleChartJson = MakeGoogleChartJsonForPerformanceMeasureSubcategory(performanceMeasure, yearRange, performanceMeasureSubcategory, performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues, performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName);
            return googleChartJson;
        }

        private static GoogleChartJson MakeGoogleChartJsonForPerformanceMeasureSubcategory(PerformanceMeasure performanceMeasure,
            IEnumerable<int> yearRange,
            PerformanceMeasureSubcategory performanceMeasureSubcategory,
            Dictionary<string, IEnumerable<CalendarYearReportedValue>> performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues,
            string legendTitle)
        {
            var googleChartType = (GoogleChartType) Enum.Parse(typeof(GoogleChartType), performanceMeasureSubcategory.ChartType);
            var googleChartDataTable = GetGoogleChartDataTableForPerformanceMeasure(yearRange, performanceMeasure.MeasurementUnitType, googleChartType, performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues);
            var googleChartJson = MakeGoogleChartJsonForPerformanceMeasureSubcategory(performanceMeasureSubcategory, googleChartDataTable);
            return googleChartJson;
        }

        public static GoogleChartJson MakeGoogleChartJsonForPerformanceMeasureSubcategory(PerformanceMeasureSubcategory performanceMeasureSubcategory, GoogleChartDataTable googleChartDataTable)
        {
            var performanceMeasure = performanceMeasureSubcategory.PerformanceMeasure;

            var chartConfiguration = performanceMeasureSubcategory.ShowOnChart
                ? JsonConvert.DeserializeObject<GoogleChartConfiguration>(performanceMeasureSubcategory.ChartConfigurationJson)
                : new GoogleChartConfiguration(performanceMeasure.PerformanceMeasureDisplayName, performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName.ToProperCase(), performanceMeasure.MeasurementUnitType);

            var performanceMeasureID = performanceMeasure.PerformanceMeasureID;
            var performanceMeasureSubcategoryID = performanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
            var chartName = string.Format("PerformanceMeasure{0}PerformanceMeasureSubcategory{1}", performanceMeasureID, performanceMeasureSubcategoryID);
            var chartPopupUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.PerformanceMeasureChartPopup(performanceMeasureID));
            var saveConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.SaveChartConfiguration(performanceMeasureID, performanceMeasureSubcategoryID));
            var chartGroupID = performanceMeasureID.ToString();
            var legendTitle = performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
            var googleChartType = (GoogleChartType) Enum.Parse(typeof(GoogleChartType), performanceMeasureSubcategory.ChartType);
            var googleChartJson = new GoogleChartJson(legendTitle, chartName, chartConfiguration, googleChartType, googleChartDataTable, chartPopupUrl, chartGroupID, saveConfigurationUrl);
            return googleChartJson;
        }

        public static GoogleChartDataTable MakeGoogleChartDataTableForPerformanceMeasureWithOnlyOneSubcategory(
            IPerformanceMeasureWithOnlyOneSubcategory performanceMeasureWithOnlyOneSubcategory)
        {
            var googleChartType = (GoogleChartType) Enum.Parse(typeof(GoogleChartType), performanceMeasureWithOnlyOneSubcategory.PerformanceMeasureSubcategory.ChartType);
            var swapAxes = performanceMeasureWithOnlyOneSubcategory.PerformanceMeasureSubcategory.SwapChartAxes ?? false;
            if (swapAxes)
            {
                return GetGoogleDataTableForNonPerformanceMeasurePerformanceMeasureWithReportingPeriodsAsSubcategory(performanceMeasureWithOnlyOneSubcategory, googleChartType);
            }
            return GetGoogleChartDataTableForNonPerformanceMeasurePerformanceMeasure(performanceMeasureWithOnlyOneSubcategory, googleChartType);
        }

        private static GoogleChartDataTable GetGoogleChartDataTableForPerformanceMeasure(IEnumerable<int> yearRange, MeasurementUnitType measurementUnitType, GoogleChartType googleChartType, Dictionary<string, IEnumerable<CalendarYearReportedValue>> performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues)
        {
            var seriesChartType = googleChartType == GoogleChartType.ComboChart ? GoogleChartType.LineChart : googleChartType;

            var googleChartRowCs = new List<GoogleChartRowC>();

            foreach (var year in yearRange.OrderBy(x => x))
            {
                var googleChartRowVs = new List<GoogleChartRowV> { new GoogleChartRowV(year, year.ToString()) };
                googleChartRowVs.AddRange(
                    performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues.OrderBy(x => x.Key)
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
            googleChartColumns.AddRange(performanceMeasureSubcategoryOptionsWithCalendarYearReportedValues.OrderBy(x => x.Key).Select(x => new GoogleChartColumn(x.Key, GoogleChartColumnDataType.Number, seriesChartType)));

            return new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
        }

        private static GoogleChartDataTable GetGoogleChartDataTableForNonPerformanceMeasurePerformanceMeasure(IPerformanceMeasureWithOnlyOneSubcategory performanceMeasureWithOnlyOneSubcategory, GoogleChartType googleChartType)
        {
            var rowCs = new List<GoogleChartRowC>();
            var hasTargets = (GetTargetValueType(performanceMeasureWithOnlyOneSubcategory) != PerformanceMeasureTargetValueType.NoTarget);

            var performanceMeasureReportingPeriods = performanceMeasureWithOnlyOneSubcategory.GetPerformanceMeasureReportingPeriods();
            foreach (var performanceMeasureReportingPeriod in performanceMeasureReportingPeriods.OrderBy(x => x.ReportingPeriodBeginDate))
            {
                var rowVs = new List<GoogleChartRowV> { new GoogleChartRowV(performanceMeasureReportingPeriod.ReportingPeriodLabel) };
                rowVs.AddRange(
                    performanceMeasureWithOnlyOneSubcategory.GetPerformanceMeasureReportedValues()
                        .Where(x => x.PerformanceMeasureReportingPeriod.ReportingPeriodLabel == performanceMeasureReportingPeriod.ReportingPeriodLabel)
                        .OrderBy(x => x.SortOrder)
                        .Select(
                            irviso =>
                                new GoogleChartRowV(irviso.ReportedValue,
                                    GoogleChartJson.GetFormattedValue(irviso.ReportedValue, performanceMeasureWithOnlyOneSubcategory.PerformanceMeasure.MeasurementUnitType))));

                if (hasTargets)
                {
                    rowVs.Add(new GoogleChartRowV(performanceMeasureReportingPeriod.TargetValue, GetFormattedTargetValue(performanceMeasureReportingPeriod, performanceMeasureWithOnlyOneSubcategory)));
                }
                rowCs.Add(new GoogleChartRowC(rowVs));
            }

            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn("Reporting Period", GoogleChartColumnDataType.String, googleChartType) };
            var performanceMeasureSubcategoryOptions = performanceMeasureWithOnlyOneSubcategory.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions;
            googleChartColumns.AddRange(
                performanceMeasureSubcategoryOptions.OrderBy(x => x.SortOrder).Select(x => new GoogleChartColumn(x.PerformanceMeasureSubcategoryOptionName, GoogleChartColumnDataType.Number, googleChartType)));

            if (hasTargets)
            {
                // GoogleChartType for targets is always LINE
                googleChartColumns.Add(new GoogleChartColumn(GetTargetColumnLabel(performanceMeasureWithOnlyOneSubcategory), GoogleChartColumnDataType.Number, GoogleChartType.LineChart));
            }

            return new GoogleChartDataTable(googleChartColumns, rowCs);
        }

        private static GoogleChartDataTable GetGoogleDataTableForNonPerformanceMeasurePerformanceMeasureWithReportingPeriodsAsSubcategory(IPerformanceMeasureWithOnlyOneSubcategory performanceMeasureWithOnlyOneSubcategory, GoogleChartType googleChartType)
        {
            var performanceMeasure = performanceMeasureWithOnlyOneSubcategory.PerformanceMeasure;
            var googleChartColumns = new List<GoogleChartColumn> {
                new GoogleChartColumn(performanceMeasure.PerformanceMeasureDisplayName, GoogleChartColumnDataType.String, googleChartType)
            };
            var performanceMeasureReportingPeriods = performanceMeasureWithOnlyOneSubcategory.GetPerformanceMeasureReportingPeriods();
            googleChartColumns.AddRange(
                performanceMeasureReportingPeriods.OrderBy(x => x.ReportingPeriodBeginDate)
                    .Select(
                        reportingPeriod =>
                            new GoogleChartColumn(reportingPeriod.ReportingPeriodID.ToString(),
                                reportingPeriod.ReportingPeriodLabel,
                                "number",
                                googleChartType,
                                GoogleChartAxisType.Primary)));


            var googleChartRowCs = new List<GoogleChartRowC>();
            var sustainabilityPerformanceMeasureReporteds = performanceMeasureWithOnlyOneSubcategory.GetPerformanceMeasureReportedValues();
            foreach (var performanceMeasureSubcategoryOption in performanceMeasureWithOnlyOneSubcategory.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryOptions.OrderBy(x => x.SortOrder))
            {
                var googleChartRowVs = new List<GoogleChartRowV> { new GoogleChartRowV(performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName) };
                googleChartRowVs.AddRange(
                    sustainabilityPerformanceMeasureReporteds.Where(
                        x => x.PerformanceMeasureReportedSubcategoryOptions.Any(y => y.PerformanceMeasureSubcategoryOptionID == performanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID))
                        .OrderBy(x => x.PerformanceMeasureReportingPeriod.ReportingPeriodBeginDate)
                        .Select(irviso => new GoogleChartRowV(irviso.ReportedValue, GoogleChartJson.GetFormattedValue(irviso.ReportedValue, performanceMeasure.MeasurementUnitType))));
                googleChartRowCs.Add(new GoogleChartRowC(googleChartRowVs));
            }

            var targetRowVs = new List<GoogleChartRowV>();
            var hasTargets = (GetTargetValueType(performanceMeasureWithOnlyOneSubcategory) != PerformanceMeasureTargetValueType.NoTarget);
            if (hasTargets)
            {
                targetRowVs.Add(new GoogleChartRowV(GetTargetColumnLabel(performanceMeasureWithOnlyOneSubcategory)));
                targetRowVs.AddRange(performanceMeasureReportingPeriods.OrderBy(x => x.ReportingPeriodBeginDate).Select(x => new GoogleChartRowV(x.TargetValue, GetFormattedTargetValue(x, performanceMeasureWithOnlyOneSubcategory))));
                googleChartRowCs.Add(new GoogleChartRowC(targetRowVs));    
            }
           
            return new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
        }

        private static string GetTargetColumnLabel(IPerformanceMeasureWithOnlyOneSubcategory performanceMeasureWithOnlyOneSubcategory)
        {
            return GetTargetValueType(performanceMeasureWithOnlyOneSubcategory) == PerformanceMeasureTargetValueType.OverallTarget ? performanceMeasureWithOnlyOneSubcategory.GetPerformanceMeasureReportingPeriods().First().TargetValueDescription : "Target";
        }

        private static string GetFormattedTargetValue(IPerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, IPerformanceMeasureWithOnlyOneSubcategory performanceMeasureWithOnlyOneSubcategory)
        {
            return GetTargetValueType(performanceMeasureWithOnlyOneSubcategory) == PerformanceMeasureTargetValueType.OverallTarget
                ? String.Format("{0}", GoogleChartJson.GetFormattedValue(performanceMeasureReportingPeriod.TargetValue, performanceMeasureWithOnlyOneSubcategory.PerformanceMeasure.MeasurementUnitType))
                : String.Format("{0} ({1})", GoogleChartJson.GetFormattedValue(performanceMeasureReportingPeriod.TargetValue, performanceMeasureWithOnlyOneSubcategory.PerformanceMeasure.MeasurementUnitType), performanceMeasureReportingPeriod.TargetValueDescription);
        }

        public static PerformanceMeasureTargetValueType GetTargetValueType(IPerformanceMeasureWithOnlyOneSubcategory performanceMeasureWithOnlyOneSubcategory)
        {
            var performanceMeasureReportingPeriods = performanceMeasureWithOnlyOneSubcategory.GetPerformanceMeasureReportingPeriods();
            if (!performanceMeasureReportingPeriods.Any(x => x.TargetValue.HasValue))
            {
                return PerformanceMeasureTargetValueType.NoTarget;
            }

            if (performanceMeasureReportingPeriods.Select(x => String.Format("{0}{1}", x.TargetValue, x.TargetValueDescription)).Distinct().Count() == 1)
            {
                return PerformanceMeasureTargetValueType.OverallTarget;
            }
            return PerformanceMeasureTargetValueType.TargetPerReportingPeriod;
        }
    }
}