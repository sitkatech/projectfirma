using System.Linq;
using System.Web;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using Microsoft.Ajax.Utilities;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingByPerformanceMeasureByProjectGridSpec : GridSpec<PerformanceMeasureSubcategoriesTotalReportedValue>
    {
        public SpendingByPerformanceMeasureByProjectGridSpec(Models.PerformanceMeasure performanceMeasure)
        {
            Add(Models.FieldDefinition.Project.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.ProjectUrl, a.ProjectName), 350, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderStringWider(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
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
                    },
                    120,
                    DhtmlxGridColumnFilterType.SelectFilterStrict);
            }

            var reportedValueColumnName = string.Format("{0} ({1})",
                Models.FieldDefinition.ReportedValue.ToGridHeaderString(),
                performanceMeasure.Indicator.MeasurementUnitType.MeasurementUnitTypeDisplayName);
            if (performanceMeasure.PerformanceMeasureType == PerformanceMeasureType.PerformanceMeasure33)
            {
                Add(reportedValueColumnName, a => a.TotalReportedValue, 150, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            else
            {
                Add(reportedValueColumnName, a => a.TotalReportedValue, 150, DhtmlxGridColumnFormatType.Decimal, DhtmlxGridColumnAggregationType.Total);
            }
            
            Add(Models.FieldDefinition.ReportedExpenditure.ToGridHeaderString(), x => x.CalculateWeightedTotalExpenditure(), 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);

            var reportedValueUnitCostColumnName = string.Format("Estimated Cost Per {0} ", performanceMeasure.Indicator.MeasurementUnitType.SingularDisplayName);
            Add(reportedValueUnitCostColumnName, a => a.CalculateWeightedTotalExpenditurePerPerformanceMeasure(), 100, DhtmlxGridColumnFormatType.Currency);

            Add("Other Reported Performance Measures",
                a =>
                {
                    var reportedPerformanceMeasures = a.Project.GetReportedPerformanceMeasures().Where(x => a.PerformanceMeasureID != x.PerformanceMeasure.PerformanceMeasureID).ToList();
                    var htmlStrings = reportedPerformanceMeasures.DistinctBy(x => x.PerformanceMeasureID).Select(x => UrlTemplate.MakeHrefString(x.PerformanceMeasure.GetSummaryUrl(), x.PerformanceMeasure.PerformanceMeasureID.ToString())).ToList();
                    return new HtmlString(string.Join(", ", htmlStrings));
                },
             200,
             DhtmlxGridColumnFilterType.Html);

            Add(Models.FieldDefinition.Latitude.ToGridHeaderString(), a => a.Project.ProjectLocationPointLatitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(Models.FieldDefinition.Longitude.ToGridHeaderString(), a => a.Project.ProjectLocationPointLongitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(Models.FieldDefinition.Region.ToGridHeaderString(), a => a.Project.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("State", a => a.Project.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            Add("Jurisdiction", a => a.Project.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            Add("Watershed", a => a.Project.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
        }
    }
}