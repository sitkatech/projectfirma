using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureReportedValuesGridSpec : GridSpec<PerformanceMeasureReportedValue>
    {
        public PerformanceMeasureReportedValuesGridSpec(Models.PerformanceMeasure performanceMeasure)
        {
            Add("Year", a => a.CalendarYear, 50, DhtmlxGridColumnFormatType.None, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.Project.ToGridHeaderString(),
                a => UrlTemplate.MakeHrefString(a.ProjectUrl, a.ProjectName),
                350,
                DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), a => a.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            foreach (var indicatorSubcategory in performanceMeasure.IndicatorSubcategories.OrderBy(x => x.IndicatorSubcategoryDisplayName))
            {
                Add(indicatorSubcategory.IndicatorSubcategoryDisplayName,
                    a =>
                    {
                        var performanceMeasureActualSubcategoryOption =
                            a.PerformanceMeasureActualSubcategoryOptions.SingleOrDefault(x => x.IndicatorSubcategoryID == indicatorSubcategory.IndicatorSubcategoryID);
                        if (performanceMeasureActualSubcategoryOption != null)
                        {
                            return performanceMeasureActualSubcategoryOption.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName;
                        }
                        return string.Empty;
                    }, 120, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            var reportedValueColumnName = string.Format("{0} ({1})",
                Models.FieldDefinition.ReportedValue.ToGridHeaderString(),
                performanceMeasure.Indicator.MeasurementUnitType.MeasurementUnitTypeDisplayName);
            if (performanceMeasure.PerformanceMeasureType == PerformanceMeasureType.PerformanceMeasure33)
            {
                Add(reportedValueColumnName, a => a.ReportedValue, 150, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            else
            {
                Add(reportedValueColumnName, a => a.ReportedValue, 150, DhtmlxGridColumnFormatType.Decimal, DhtmlxGridColumnAggregationType.Total);
            }
            Add(Models.FieldDefinition.Latitude.ToGridHeaderString(), a => a.Project.ProjectLocationPointLatitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(Models.FieldDefinition.Longitude.ToGridHeaderString(), a => a.Project.ProjectLocationPointLongitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(Models.FieldDefinition.Region.ToGridHeaderString(), a => a.Project.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("State", a => a.Project.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            Add("Jurisdiction", a => a.Project.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            Add("Watershed", a => a.Project.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
        }
    }
}