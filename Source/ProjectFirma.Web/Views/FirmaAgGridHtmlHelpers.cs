/*-----------------------------------------------------------------------
<copyright file="FirmaDhtmlxGridHtmlHelpers.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views
{
    public static class FirmaAgGridHtmlHelpers
    {
        public static readonly HtmlString PlusIcon = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-plus-sign gi-1x blue");
        public static readonly HtmlString FactSheetIcon = BootstrapHtmlHelpers.MakeGlyphIcon("glyphicon-search gi-1x blue");
        public static readonly UrlTemplate<string> ExcelDownloadUrl = new UrlTemplate<string>(SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.ExportGridToExcel(UrlTemplate.Parameter1String)));

        /// <summary>
        /// All grids use this
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="html"></param>
        /// <param name="gridSpec"></param>
        /// <param name="gridName"></param>
        /// <param name="optionalGridDataUrl"></param>
        /// <param name="styleString"></param>
        /// <param name="agGridResizeType"></param>
        /// <returns></returns>
        public static HtmlString AgGrid<T>(this HtmlHelper html, GridSpec<T> gridSpec, string gridName, string optionalGridDataUrl, string styleString, AgGridResizeType agGridResizeType)
        {
            var dhtmlxGridHeader = AgGridHtmlHelpers.BuildDhtmlxGridHeader(gridSpec, gridName, ExcelDownloadUrl);

            var saveGridSettingsUrl = SitkaRoute<GridSettingsController>.BuildUrlFromExpression(c => c.SaveGridSettings());

            var dhtmlxGrid = AgGridHtmlHelpers.AgGridImpl(gridSpec,
                gridName,
                optionalGridDataUrl,
                $"background-color:white;{styleString}",
                null, dhtmlxGridHeader, agGridResizeType, saveGridSettingsUrl);

            return new HtmlString(dhtmlxGrid);
        }
    }
}
