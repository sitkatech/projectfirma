using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureExpectedGridSpec : GridSpec<PerformanceMeasureExpected>
    {
        public PerformanceMeasureExpectedGridSpec(Models.PerformanceMeasure performanceMeasure)
        {
            Add(Models.FieldDefinition.Project.ToGridHeaderString(),
                a => UrlTemplate.MakeHrefString(a.Project.GetSummaryUrl(), a.Project.DisplayName),
                350,
                DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), a => a.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            foreach (var indicatorSubcategory in performanceMeasure.IndicatorSubcategories.OrderBy(x => x.IndicatorSubcategoryDisplayName))
            {
                Add(indicatorSubcategory.IndicatorSubcategoryDisplayName,
                    a =>
                    {
                        var performanceMeasureExpectedSubcategoryOption =
                            a.PerformanceMeasureExpectedSubcategoryOptions.SingleOrDefault(x => x.IndicatorSubcategoryID == indicatorSubcategory.IndicatorSubcategoryID);
                        if (performanceMeasureExpectedSubcategoryOption != null)
                        {
                            return performanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName;
                        }
                        return string.Empty;
                    },
                    120,
                    DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            var expectedValueColumnName = string.Format("{0} ({1})",
                Models.FieldDefinition.ExpectedValue.ToGridHeaderString(),
                performanceMeasure.Indicator.MeasurementUnitType.MeasurementUnitTypeDisplayName);

            Add(expectedValueColumnName, a => a.ExpectedValue, 150, DhtmlxGridColumnFormatType.Decimal, DhtmlxGridColumnAggregationType.Total);
        }
    }
}