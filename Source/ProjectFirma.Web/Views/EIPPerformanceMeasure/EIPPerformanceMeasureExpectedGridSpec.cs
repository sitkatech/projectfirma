using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.EIPPerformanceMeasure
{
    public class EIPPerformanceMeasureExpectedGridSpec : GridSpec<EIPPerformanceMeasureExpected>
    {
        public EIPPerformanceMeasureExpectedGridSpec(Models.EIPPerformanceMeasure eipPerformanceMeasure)
        {
            Add(Models.FieldDefinition.Project.ToGridHeaderString(),
                a => UrlTemplate.MakeHrefString(a.Project.GetSummaryUrl(), a.Project.DisplayName),
                350,
                DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.Stage.ToGridHeaderString(), a => a.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            foreach (var indicatorSubcategory in eipPerformanceMeasure.IndicatorSubcategories.OrderBy(x => x.IndicatorSubcategoryDisplayName))
            {
                Add(indicatorSubcategory.IndicatorSubcategoryDisplayName,
                    a =>
                    {
                        var eipPerformanceMeasureExpectedSubcategoryOption =
                            a.EIPPerformanceMeasureExpectedSubcategoryOptions.SingleOrDefault(x => x.IndicatorSubcategoryID == indicatorSubcategory.IndicatorSubcategoryID);
                        if (eipPerformanceMeasureExpectedSubcategoryOption != null)
                        {
                            return eipPerformanceMeasureExpectedSubcategoryOption.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName;
                        }
                        return string.Empty;
                    },
                    120,
                    DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            var expectedValueColumnName = string.Format("{0} ({1})",
                Models.FieldDefinition.ExpectedValue.ToGridHeaderString(),
                eipPerformanceMeasure.Indicator.MeasurementUnitType.MeasurementUnitTypeDisplayName);
            if (eipPerformanceMeasure.EIPPerformanceMeasureType == EIPPerformanceMeasureType.EIPPerformanceMeasure33)
            {
                Add(expectedValueColumnName, a => a.ExpectedValue, 150, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            else
            {
                Add(expectedValueColumnName, a => a.ExpectedValue, 150, DhtmlxGridColumnFormatType.Decimal, DhtmlxGridColumnAggregationType.Total);
            }
        }
    }
}