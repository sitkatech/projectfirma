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
    public class SpendingByEIPPerformanceMeasureByProjectGridSpec : GridSpec<EIPPerformanceMeasureSubcategoriesTotalReportedValue>
    {
        public SpendingByEIPPerformanceMeasureByProjectGridSpec(Models.EIPPerformanceMeasure eipPerformanceMeasure)
        {
            Add(Models.FieldDefinition.Project.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.ProjectUrl, a.ProjectName), 350, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.Stage.ToGridHeaderStringWider(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
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
                    },
                    120,
                    DhtmlxGridColumnFilterType.SelectFilterStrict);
            }

            var reportedValueColumnName = string.Format("{0} ({1})",
                Models.FieldDefinition.ReportedValue.ToGridHeaderString(),
                eipPerformanceMeasure.Indicator.MeasurementUnitType.MeasurementUnitTypeDisplayName);
            if (eipPerformanceMeasure.EIPPerformanceMeasureType == EIPPerformanceMeasureType.EIPPerformanceMeasure33)
            {
                Add(reportedValueColumnName, a => a.TotalReportedValue, 150, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            else
            {
                Add(reportedValueColumnName, a => a.TotalReportedValue, 150, DhtmlxGridColumnFormatType.Decimal, DhtmlxGridColumnAggregationType.Total);
            }
            
            Add(Models.FieldDefinition.ReportedExpenditure.ToGridHeaderString(), x => x.CalculateWeightedTotalExpenditure(), 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);

            var reportedValueUnitCostColumnName = string.Format("Estimated Cost Per {0} ", eipPerformanceMeasure.Indicator.MeasurementUnitType.SingularDisplayName);
            Add(reportedValueUnitCostColumnName, a => a.CalculateWeightedTotalExpenditurePerEIPPerformanceMeasure(), 100, DhtmlxGridColumnFormatType.Currency);

            Add("Other Reported Performance Measures",
                a =>
                {
                    var reportedEIPPerformanceMeasures = a.Project.GetReportedEIPPerformanceMeasures().Where(x => a.EIPPerformanceMeasureID != x.EIPPerformanceMeasure.EIPPerformanceMeasureID).ToList();
                    var htmlStrings = reportedEIPPerformanceMeasures.DistinctBy(x => x.EIPPerformanceMeasureID).Select(x => UrlTemplate.MakeHrefString(x.EIPPerformanceMeasure.GetSummaryUrl(), x.EIPPerformanceMeasure.EIPPerformanceMeasureID.ToString())).ToList();
                    return new HtmlString(string.Join(", ", htmlStrings));
                },
             200,
             DhtmlxGridColumnFilterType.Html);

            Add(Models.FieldDefinition.Latitude.ToGridHeaderString(), a => a.Project.ProjectLocationPointLatitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(Models.FieldDefinition.Longitude.ToGridHeaderString(), a => a.Project.ProjectLocationPointLongitude, 80, DhtmlxGridColumnFormatType.LatLong);
            Add(Models.FieldDefinition.Region.ToGridHeaderString(), a => a.Project.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.ProjectLocationState.ToGridHeaderString(), a => a.Project.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.ProjectLocationJurisdiction.ToGridHeaderString(), a => a.Project.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.ProjectLocationWatershed.ToGridHeaderString(), a => a.Project.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
        }
    }
}