using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Indicator
{
    public class IndicatorGridSpec : GridSpec<Models.Indicator>
    {
        public IndicatorGridSpec()
        {
            Add("#", a => a.IndicatorID, 30);
            Add("Indicator Name", a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.IndicatorDisplayName), 300, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.MeasurementUnit.ToGridHeaderString("Unit"), a => a.MeasurementUnitType.MeasurementUnitTypeDisplayName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Type",
                a => a.IndicatorType.IndicatorTypeDisplayName,
                60,
                DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Definition", a => a.IndicatorDefinition, 400, DhtmlxGridColumnFilterType.Html);
            Add("Simple Description",
                a => a.IndicatorPublicDescriptionHtmlString ?? new HtmlString(string.Empty),
                400,
                DhtmlxGridColumnFilterType.Html);
        }
    }
}