using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.Shared
{
    public class PerformanceMeasureChartDataSimple
    {
        public Dictionary<string, GoogleChartRowV> SubcategoryOptionValues { get; set; }
        public string Year { get; set; }

        public static List<PerformanceMeasureChartDataSimple> DeriveSimplesFromGoogleChartJson(GoogleChartJson googleChartJson, string mainColumnLabel)
        {
            var googleChartColumns = googleChartJson.GoogleChartDataTable.GoogleChartColumns;
            var mainColumnLabelIndex = googleChartColumns.FindIndex(x => x.ColumnLabel == mainColumnLabel);

            var googleChartDataSimples = googleChartJson.GoogleChartDataTable.GoogleChartRowCs.Select(googleChartRowC =>
                {
                    return new PerformanceMeasureChartDataSimple
                    {
                        Year = googleChartRowC.GoogleChartRowVs[mainColumnLabelIndex].Value.ToString(),
                        SubcategoryOptionValues = googleChartColumns.Where(x => x.ColumnLabel != null && IsValidColumn(x.ColumnLabel, googleChartJson))
                            .ToDictionary(x => x.ColumnLabel, x => googleChartRowC.GoogleChartRowVs[googleChartColumns.IndexOf(x)])
                    };
                })
                .ToList();
            googleChartDataSimples.Sort((x, y) => String.Compare(x.Year, y.Year, StringComparison.Ordinal));

            // Add total row
            googleChartDataSimples.Add(new PerformanceMeasureChartDataSimple
            {
                Year = "Total",
                SubcategoryOptionValues = googleChartDataSimples.SelectMany(x => x.SubcategoryOptionValues.Keys)
                    .Distinct()
                    .ToDictionary(x => x,
                        x =>
                        {
                            var columnDataType = googleChartColumns.Single(y => y.ColumnLabel == x).ColumnDataType;
                            return new GoogleChartRowV(googleChartDataSimples.Sum(y =>
                                {
                                    var value = y.SubcategoryOptionValues[x].Value;
                                    return columnDataType == GoogleChartColumnDataType.Number.ColumnDataType && value != null ? Decimal.Parse(value.ToString(), System.Globalization.NumberStyles.Float) : 0;
                                }),
                                GoogleChartColumnDataType.Number.ColumnDataType);
                        })
            });

            return googleChartDataSimples;
        }

        public static Func<GoogleChartColumn, bool> IsValidColumn(ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure)
        {
            return x => performanceMeasure.PerformanceMeasureSubcategories.SelectMany(x1 => x1.PerformanceMeasureSubcategoryOptions).Select(x2 => x2.PerformanceMeasureSubcategoryOptionName).ToList().Contains(x.ColumnLabel) ||
                        x.ColumnLabel == performanceMeasure.PerformanceMeasureDisplayName;
        }

        public static bool IsValidColumn(string columnLabel, GoogleChartJson googleChartJson)
        {
            if (googleChartJson.ChartColumns == null || !googleChartJson.ChartColumns.Any())
            {
                return true;
            }
            return googleChartJson.ChartColumns.Contains(columnLabel);
        }
    }
}