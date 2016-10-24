using System.Globalization;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.EIPPerformanceMeasure
{
    public class IndexGridSpec : GridSpec<Models.EIPPerformanceMeasure>
    {
        public IndexGridSpec()
        {
            Add("#", a => UrlTemplate.MakeHrefString(a.GetInfoSheetUrl(), a.EIPPerformanceMeasureID.ToString(CultureInfo.InvariantCulture)), 35, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.EIPPerformanceMeasure.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetInfoSheetUrl(), a.DisplayNameNoNumber), 320, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.MeasurementUnit.ToGridHeaderString("Units"), a => a.Indicator.MeasurementUnitType.MeasurementUnitTypeDisplayName, 110, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.IndicatorDefinition.ToGridHeaderString("Performance Measure Definition"), a => a.Indicator.IndicatorDefinition, 350, DhtmlxGridColumnFilterType.Text);
            Add("# of Subcategories", a => a.Indicator.GetRealSubcategoryCount(), 110);
            Add("# of Projects", a => a.ReportedProjectsCount, 80);
            Add("# of Projects Expected", a => a.ExpectedProjectsCount, 100);
        }
    }
}