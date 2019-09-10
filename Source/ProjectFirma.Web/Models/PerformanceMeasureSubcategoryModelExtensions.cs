using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using MoreLinq;
using Newtonsoft.Json;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static class PerformanceMeasureSubcategoryModelExtensions
    {
        public static List<GoogleChartJson> MakeGoogleChartJsons(PerformanceMeasure performanceMeasure, List<ProjectPerformanceMeasureReportingPeriodValue> projectPerformanceMeasureReportingPeriodValues, string chartUniqueName)
        {
            var performanceMeasureSubcategoryOptionReportedValues = projectPerformanceMeasureReportingPeriodValues.SelectMany(x => x.PerformanceMeasureSubcategoryOptionReportedValues).GroupBy(x => x.PerformanceMeasureSubcategory);
            var performanceMeasureReportingPeriods = projectPerformanceMeasureReportingPeriodValues.Select(x => x.PerformanceMeasureReportingPeriod).Distinct(new HavePrimaryKeyComparer<PerformanceMeasureReportingPeriod>()).ToList();
            var googleChartJsons = new List<GoogleChartJson>();
            foreach (var groupedBySubcategory in performanceMeasureSubcategoryOptionReportedValues.Where(x => x.Key.ShowOnChart()))
            {
                var performanceMeasureSubcategory = groupedBySubcategory.Key;
                Check.RequireNotNull(performanceMeasureSubcategory.ChartConfigurationJson, "All PerformanceMeasure Subcategories need to have a Google Chart Configuration Json");
                var groupedBySubcategoryOption = groupedBySubcategory.GroupBy(c => new Tuple<string, int>(c.ChartName, c.SortOrder)).ToList(); // Item1 is ChartName, Item2 is SortOrder
                var chartColumns = performanceMeasure.HasRealSubcategories() ? groupedBySubcategoryOption.OrderBy(x => x.Key.Item2).Select(x => x.Key.Item1).ToList() : new List<string> { performanceMeasure.GetDisplayName() };
                var hasTargets = GetTargetValueType(performanceMeasureReportingPeriods) != PerformanceMeasureTargetValueType.NoTarget;
                var reverseTooltipOrder = performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ColumnChart || performanceMeasureSubcategory.GoogleChartType == GoogleChartType.ComboChart;

                var googleChartDataTable = performanceMeasure.SwapChartAxes
                    ? GetGoogleChartDataTableWithReportingPeriodsAsVerticalAxis(performanceMeasure, hasTargets, performanceMeasureReportingPeriods, groupedBySubcategoryOption)
                    : GetGoogleChartDataTableWithReportingPeriodsAsHorixontalAxis(performanceMeasure, performanceMeasureReportingPeriods, hasTargets, groupedBySubcategoryOption, chartColumns, performanceMeasure.IsSummable, reverseTooltipOrder);
                var legendTitle = performanceMeasure.HasRealSubcategories() ? performanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName : performanceMeasure.GetDisplayName();
                var chartName = $"{performanceMeasure.GetJavascriptSafeChartUniqueName()}PerformanceMeasureSubcategory{performanceMeasureSubcategory.PerformanceMeasureSubcategoryID}";
                var saveConfigurationUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x =>
                    x.SaveChartConfiguration(performanceMeasure,
                        performanceMeasureSubcategory.PerformanceMeasureSubcategoryID));
                var resetConfigurationUrl =
                    SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x =>
                        x.ResetChartConfiguration(performanceMeasure,
                            performanceMeasureSubcategory.PerformanceMeasureSubcategoryID));
                var chartConfiguration = JsonConvert.DeserializeObject<GoogleChartConfiguration>(performanceMeasureSubcategory.ChartConfigurationJson);
                if (performanceMeasureSubcategory.PerformanceMeasure.IsSummable && !performanceMeasure.SwapChartAxes)
                {
                    chartConfiguration.Tooltip = new GoogleChartTooltip(true);
                }
                
                var googleChartJson = new GoogleChartJson(legendTitle, $"{chartUniqueName}{chartName}", chartConfiguration,
                    performanceMeasureSubcategory.GoogleChartType, googleChartDataTable,
                    chartColumns, saveConfigurationUrl, resetConfigurationUrl);
                googleChartJsons.Add(googleChartJson);
            }
            return googleChartJsons;
        }

        public static GoogleChartDataTable GetGoogleChartDataTableWithReportingPeriodsAsHorixontalAxis(PerformanceMeasure performanceMeasure,
            ICollection<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods,
            bool hasTargets,
            IReadOnlyCollection<IGrouping<Tuple<string, int>, PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>> groupedBySubcategoryOption,
            IEnumerable<string> subcategoryOptions,
            bool hasToolTipWithTotal,
            bool reverseTooltipOrder)
        {
            var googleChartRowCs = new List<GoogleChartRowC>();
            foreach (var performanceMeasureReportingPeriod in performanceMeasureReportingPeriods.OrderBy(x => x.PerformanceMeasureReportingPeriodBeginDate))
            {
                var googleChartRowVs = new List<GoogleChartRowV> { new GoogleChartRowV(performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel) };
                if (hasTargets)
                {
                    googleChartRowVs.Add(new GoogleChartRowV(performanceMeasureReportingPeriod.TargetValue, GetFormattedTargetValue(performanceMeasureReportingPeriod, performanceMeasure)));
                }
                if (hasToolTipWithTotal)
                {
                    googleChartRowVs.Add(new GoogleChartRowV(null, FormattedDataTooltip(groupedBySubcategoryOption, performanceMeasureReportingPeriod, performanceMeasure.MeasurementUnitType, reverseTooltipOrder)));
                }
                googleChartRowVs.AddRange(groupedBySubcategoryOption.OrderBy(x => x.Key.Item2).Select(x =>
                {
                    var calendarYearReportedValue = x.Where(isorv => isorv.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel)
                                                        .Sum(isorv => isorv.ReportedValue) ?? 0;
                    return new GoogleChartRowV(calendarYearReportedValue, GoogleChartJson.GetFormattedValue(calendarYearReportedValue, performanceMeasure.MeasurementUnitType));
                }));

                googleChartRowCs.Add(new GoogleChartRowC(googleChartRowVs));
            }

            // reporting period is going to be the first column and it will be our horizontal axis
            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn("Reporting Period", GoogleChartColumnDataType.String) };
            if (hasTargets)
            {
                // GoogleChartType for targets is always LINE; we also always render the target line first to stay consistent
                googleChartColumns.Add(new GoogleChartColumn(GetTargetColumnLabel(performanceMeasureReportingPeriods), GoogleChartColumnDataType.Number));
            }

            // add column with row tooltip
            if (hasToolTipWithTotal)
            {
                googleChartColumns.Add(new GoogleChartColumn(GoogleChartColumnDataType.String.ColumnDataType, "tooltip", new GoogleChartProperty()));
            }

            // all the subcategory option values are individual columns and series and they will be on the vertical axis
            googleChartColumns.AddRange(subcategoryOptions.Select(x => new GoogleChartColumn(x, GoogleChartColumnDataType.Number)));

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return googleChartDataTable;
        }

        private static GoogleChartDataTable GetGoogleChartDataTableWithReportingPeriodsAsVerticalAxis(PerformanceMeasure performanceMeasure,
            bool hasTargets,
            ICollection<PerformanceMeasureReportingPeriod> performanceMeasureReportingPeriods,
            IEnumerable<IGrouping<Tuple<string, int>, PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>> groupedBySubcategoryOption)
        {
            var googleChartRowCs = new List<GoogleChartRowC>();
            var targetRowVs = new List<GoogleChartRowV>();
            if (hasTargets)
            {
                targetRowVs.Add(new GoogleChartRowV(GetTargetColumnLabel(performanceMeasureReportingPeriods)));
                targetRowVs.AddRange(performanceMeasureReportingPeriods.OrderBy(x => x.PerformanceMeasureReportingPeriodBeginDate)
                    .Select(x => new GoogleChartRowV(x.TargetValue, GetFormattedTargetValue(x, performanceMeasure))));
                googleChartRowCs.Add(new GoogleChartRowC(targetRowVs));
            }

            foreach (var performanceMeasureSubcategoryOption in groupedBySubcategoryOption.OrderBy(x => x.Key.Item2))
            {
                var googleChartRowVs = new List<GoogleChartRowV> { new GoogleChartRowV(performanceMeasureSubcategoryOption.Key.Item1) };
                googleChartRowVs.AddRange(performanceMeasureSubcategoryOption.OrderBy(x => x.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodBeginDate).Select(irviso =>
                    new GoogleChartRowV(irviso.ReportedValue, GoogleChartJson.GetFormattedValue(irviso.ReportedValue, performanceMeasure.MeasurementUnitType))));
                googleChartRowCs.Add(new GoogleChartRowC(googleChartRowVs));
            }

            var googleChartColumns = new List<GoogleChartColumn> { new GoogleChartColumn(performanceMeasure.GetDisplayName(), GoogleChartColumnDataType.String) };
            googleChartColumns.AddRange(performanceMeasureReportingPeriods.OrderBy(x => x.PerformanceMeasureReportingPeriodBeginDate).Select(x =>
                new GoogleChartColumn(x.PerformanceMeasureReportingPeriodID.ToString(), x.PerformanceMeasureReportingPeriodLabel, GoogleChartColumnDataType.Number.ColumnDataType)));

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return googleChartDataTable;
        }

        private static string GetTargetColumnLabel(ICollection<PerformanceMeasureReportingPeriod> performanceMeasurePerformanceMeasureReportingPeriods)
        {
            return GetTargetValueType(performanceMeasurePerformanceMeasureReportingPeriods) == PerformanceMeasureTargetValueType.OverallTarget ? performanceMeasurePerformanceMeasureReportingPeriods.First().TargetValueDescription : "Target";
        }

        private static string GetFormattedTargetValue(PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, PerformanceMeasure performanceMeasure)
        {
            return $"{GoogleChartJson.GetFormattedValue(performanceMeasureReportingPeriod.TargetValue, performanceMeasure.MeasurementUnitType)} ({performanceMeasureReportingPeriod.TargetValueDescription})";
        }

        public static PerformanceMeasureTargetValueType GetTargetValueType(ICollection<PerformanceMeasureReportingPeriod> performanceMeasurePerformanceMeasureReportingPeriods)
        {
            var performanceMeasureReportingPeriods = performanceMeasurePerformanceMeasureReportingPeriods;
            if (!performanceMeasureReportingPeriods.Any(x => x.TargetValue.HasValue))
            {
                return PerformanceMeasureTargetValueType.NoTarget;
            }

            if (performanceMeasureReportingPeriods.Select(x => $"{x.TargetValue}{x.TargetValueDescription}").Distinct().Count() == 1)
            {
                return PerformanceMeasureTargetValueType.OverallTarget;
            }
            return PerformanceMeasureTargetValueType.TargetPerReportingPeriod;
        }

        public static string FormattedDataTooltip(IReadOnlyCollection<IGrouping<Tuple<string, int>, PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>> groupedBySubcategoryOption, 
                                                  PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod, MeasurementUnitType performanceMeasureMeasurementUnitType, bool reverseTooltipOrder)
        {
            // shape data
            var calendarReportedYearValuesDictionary = new Dictionary<string, double>();
            if (reverseTooltipOrder)
            {
                MoreEnumerable.ForEach(groupedBySubcategoryOption.OrderByDescending(x => x.Key.Item2), x =>
                {
                    var calendarYearReportedValue = Enumerable.Where<PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>(x, isorv => isorv.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel)
                                                        .Sum(isorv => isorv.ReportedValue) ?? 0;
                    calendarReportedYearValuesDictionary.Add(x.Key.Item1, calendarYearReportedValue);
                });
            }
            else
            {
                MoreEnumerable.ForEach(groupedBySubcategoryOption.OrderBy(x => x.Key.Item2), x =>
                {
                    var calendarYearReportedValue = Enumerable.Where<PerformanceMeasureReportingPeriodSubcategoryOptionReportedValue>(x, isorv => isorv.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel == performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel)
                                                        .Sum(isorv => isorv.ReportedValue) ?? 0;
                    calendarReportedYearValuesDictionary.Add(x.Key.Item1, calendarYearReportedValue);
                });
            }

            var stringPrecision = new String('0', performanceMeasureMeasurementUnitType.NumberOfSignificantDigits);
            var prefix = performanceMeasureMeasurementUnitType == MeasurementUnitType.Dollars ? "$" : null;

            // build html for tooltip
            var html = "<div class='googleTooltipDiv'>";
            html += $"<p><b>{performanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodLabel}</b></p>";
            html += "<table class='table table-striped googleTooltipTable'>";
            foreach (KeyValuePair<string, double> calendarReportedYearValue in calendarReportedYearValuesDictionary)
            {
                var formattedValue = calendarReportedYearValue.Value.ToString($"#,###,###,##0.{stringPrecision}");


                html += $"<tr><td>{calendarReportedYearValue.Key}</td><td style='text-align: right'><b>{prefix ?? String.Empty}{formattedValue} {performanceMeasureMeasurementUnitType.LegendDisplayName ?? String.Empty}</b></td></tr>";
            }

            var formattedTotal = calendarReportedYearValuesDictionary.Sum(x => x.Value).ToString($"#,###,###,##0.{stringPrecision}");
            html += $"<tr class='googleTooltipTableTotalRow'><td>Total</td><td style='text-align: right'><b>{prefix ?? String.Empty}{formattedTotal} {performanceMeasureMeasurementUnitType.LegendDisplayName ?? String.Empty}</b></td></tr>";
            html += "</table></div>";

            return html;
        }
    }
}