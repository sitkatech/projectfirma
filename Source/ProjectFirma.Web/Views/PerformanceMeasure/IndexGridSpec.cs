using System.Globalization;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class IndexGridSpec : GridSpec<Models.PerformanceMeasure>
    {
        public IndexGridSpec()
        {
            Add("#", a => UrlTemplate.MakeHrefString(a.GetInfoSheetUrl(), a.PerformanceMeasureID.ToString(CultureInfo.InvariantCulture)), 35, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.PerformanceMeasure.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetInfoSheetUrl(), a.DisplayNameNoNumber), 320, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.MeasurementUnit.ToGridHeaderString("Units"), a => a.MeasurementUnitType.MeasurementUnitTypeDisplayName, 110, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Performance Measure Definition", a => a.PerformanceMeasureDefinition, 350, DhtmlxGridColumnFilterType.Text);
            Add("# of Subcategories", a => a.GetRealSubcategoryCount(), 110);
            Add("# of Projects", a => a.ReportedProjectsCount, 80);
            Add("# of Projects Expected", a => a.ExpectedProjectsCount, 100);
        }
    }
}