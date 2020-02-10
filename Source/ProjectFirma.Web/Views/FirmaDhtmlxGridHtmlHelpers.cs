/*-----------------------------------------------------------------------
<copyright file="FirmaDhtmlxGridHtmlHelpers.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views
{
    public static class FirmaDhtmlxGridHtmlHelpers
    {
        public static readonly HtmlString PlusIcon = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus-sign gi-1x blue");
        public static readonly HtmlString FactSheetIcon = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-search gi-1x blue");
        public static readonly UrlTemplate<string> ExcelDownloadUrl =
            new UrlTemplate<string>(SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.ExportGridToExcel(UrlTemplate.Parameter1String)));

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
            var dhtmlxGridHeader = DhtmlxGridHtmlHelpers.BuildDhtmlxGridHeader(gridSpec, gridName, ExcelDownloadUrl);

            var dhtmlxGrid = DhtmlxGridHtmlHelpers.DhtmlxGridImpl(gridSpec,
                gridName,
                optionalGridDataUrl,
                $"background-color:white;{styleString}",
                null, dhtmlxGridHeader, dhtmlxGridResizeType);

            return new HtmlString(dhtmlxGrid);
        }
    }
}
