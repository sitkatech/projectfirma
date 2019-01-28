using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LtInfo.Common.ExcelWorkbookUtilities;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureChartExcelSpec : ExcelWorksheetSpec<PerformanceMeasureChartDataSimple>
    {
        public PerformanceMeasureChartExcelSpec(List<GoogleChartColumn> googleChartColumns)
        {
            AddColumn(FieldDefinitionEnum.ReportingYear.ToType().GetFieldDefinitionLabel(), x => x.Year);

            foreach (var googleChartColumn in googleChartColumns)
            {
                if (googleChartColumn != null)
                {
                    if (googleChartColumn.ColumnDataType != GoogleChartColumnDataType.Number.ColumnDataType)
                    {
                        AddColumn(googleChartColumn.ColumnLabel,
                            x => googleChartColumn.ColumnLabel != null && x.SubcategoryOptionValues.ContainsKey(googleChartColumn.ColumnLabel)
                                ? x.SubcategoryOptionValues[googleChartColumn.ColumnLabel].Value.ToString()
                                : String.Empty);
                    }
                    else
                    {
                        AddColumn(googleChartColumn.ColumnLabel,
                            x =>
                            {
                                var value = x.SubcategoryOptionValues[googleChartColumn.ColumnLabel].Value;
                                return value != null && x.SubcategoryOptionValues.ContainsKey(googleChartColumn.ColumnLabel) ? Decimal.Parse(value.ToString(), NumberStyles.Float) : 0;
                            });
                    }
                }
            }

            AddColumn("Total", x => x.SubcategoryOptionValues.Values.Sum(y => y.Value != null && Decimal.TryParse(y.Value.ToString(), out var value) ? value : 0));
        }
    }
}