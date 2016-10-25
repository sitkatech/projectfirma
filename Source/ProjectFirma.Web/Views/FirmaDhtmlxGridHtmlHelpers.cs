using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.DhtmlWrappers;

namespace ProjectFirma.Web.Views
{
    public static class FirmaDhtmlxGridHtmlHelpers
    {
        public static readonly HtmlString PlusIcon = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus-sign gi-1x blue");
        public static readonly HtmlString FactSheetIcon = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-search gi-1x blue");
        public static readonly UrlTemplate<string> ExcelDownloadWithFooterUrl =
            new UrlTemplate<string>(SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.ExportGridToExcel(UrlTemplate.Parameter1String, true)));
        public static readonly UrlTemplate<string> ExcelDownloadWithoutFooterUrl =
            new UrlTemplate<string>(SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.ExportGridToExcel(UrlTemplate.Parameter1String, false)));

        /// <summary>
        /// All grids use this
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="html"></param>
        /// <param name="gridSpec"></param>
        /// <param name="gridName"></param>
        /// <param name="optionalGridDataUrl"></param>
        /// <param name="styleString"></param>
        /// <param name="dhtmlxGridResizeType"></param>
        /// <returns></returns>
        public static HtmlString DhtmlxGrid<T>(this HtmlHelper html, GridSpec<T> gridSpec, string gridName, string optionalGridDataUrl, string styleString, DhtmlxGridResizeType dhtmlxGridResizeType)
        {
            var dhtmlxGridHeader = DhtmlxGridHtmlHelpers.BuildDhtmlxGridHeader(gridSpec, gridName, ExcelDownloadWithFooterUrl, ExcelDownloadWithoutFooterUrl);

            var dhtmlxGrid = DhtmlxGridHtmlHelpers.DhtmlxGridImpl(gridSpec,
                gridName,
                optionalGridDataUrl,
                string.Format("background-color:white;{0}", styleString),
                null, dhtmlxGridHeader, dhtmlxGridResizeType);

            return new HtmlString(dhtmlxGrid);
        }
    }
}