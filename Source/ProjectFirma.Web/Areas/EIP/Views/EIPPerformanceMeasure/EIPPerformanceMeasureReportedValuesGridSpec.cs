using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.EIPPerformanceMeasure
{
    public class EIPPerformanceMeasureReportedValuesGridSpec : GridSpec<EIPPerformanceMeasureReportedValue>
    {
        public EIPPerformanceMeasureReportedValuesGridSpec(Models.EIPPerformanceMeasure eipPerformanceMeasure)
        {
            Add("Year", a => a.CalendarYear, 50, DhtmlxGridColumnFormatType.None, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.Project.ToGridHeaderString(),
                a => UrlTemplate.MakeHrefString(a.ProjectUrl, a.ProjectName),
                350,
                DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinition.Stage.ToGridHeaderString(), a => a.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            foreach (var indicatorSubcategory in eipPerformanceMeasure.IndicatorSubcategories.OrderBy(x => x.IndicatorSubcategoryDisplayName))
            {
                Add(indicatorSubcategory.IndicatorSubcategoryDisplayName,
                    a =>
                    {
                        var eipPerformanceMeasureActualSubcategoryOption =
                            a.EIPPerformanceMeasureActualSubcategoryOptions.SingleOrDefault(x => x.IndicatorSubcategoryID == indicatorSubcategory.IndicatorSubcategoryID);
                        if (eipPerformanceMeasureActualSubcategoryOption != null)
                        {
                            return eipPerformanceMeasureActualSubcategoryOption.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName;
                        }
                        return string.Empty;
                    }, 120, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            var reportedValueColumnName = string.Format("{0} ({1})",
                FieldDefinition.ReportedValue.ToGridHeaderString(),
                eipPerformanceMeasure.Indicator.MeasurementUnitType.MeasurementUnitTypeDisplayName);
            if (eipPerformanceMeasure.EIPPerformanceMeasureType == EIPPerformanceMeasureType.EIPPerformanceMeasure33)
            {
                Add(reportedValueColumnName, a => a.ReportedValue, 150, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            else
            {
                Add(reportedValueColumnName, a => a.ReportedValue, 150, DhtmlxGridColumnFormatType.Decimal, DhtmlxGridColumnAggregationType.Total);
            }
            Add(FieldDefinition.Latitude.ToGridHeaderString(), a => a.Project.ProjectLocationPointLatitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(FieldDefinition.Longitude.ToGridHeaderString(), a => a.Project.ProjectLocationPointLongitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(FieldDefinition.Region.ToGridHeaderString(), a => a.Project.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinition.ProjectLocationState.ToGridHeaderString(), a => a.Project.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinition.ProjectLocationJurisdiction.ToGridHeaderString(), a => a.Project.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinition.ProjectLocationWatershed.ToGridHeaderString(), a => a.Project.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
        }
    }
}