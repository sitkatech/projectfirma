using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.BootstrapWrappers;
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
            Add(Models.FieldDefinition.IndicatorDisplayName.ToGridHeaderString("Indicator Name"), a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.IndicatorDisplayName), 300, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.MeasurementUnit.ToGridHeaderString("Unit"), a => a.MeasurementUnitType.MeasurementUnitTypeDisplayName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Reported in EIP?",
                a =>
                    a.EIPPerformanceMeasure != null
                        ? UrlTemplate.MakeHrefString(a.GetEIPInfoSheetUrl(), BootstrapHtmlHelpers.MakeGlyphIconWithHiddenText("glyphicon-ok-circle", "Yes").ToString())
                        : new HtmlString("<span style='display:none'>No</span>"),
                100,
                DhtmlxGridColumnFilterType.SelectFilterHtmlStrict,
                DhtmlxGridColumnAlignType.Center);
            Add(Models.FieldDefinition.IndicatorType.ToGridHeaderString("Type"),
                a => a.IndicatorType.IndicatorTypeDisplayName,
                60,
                DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.IndicatorDefinition.ToGridHeaderString("Definition"), a => a.IndicatorDefinition, 400, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.IndicatorSimpleDescription.ToGridHeaderString("Simple Description"),
                a => a.IndicatorPublicDescriptionHtmlString ?? new HtmlString(string.Empty),
                400,
                DhtmlxGridColumnFilterType.Html);
        }
    }
}