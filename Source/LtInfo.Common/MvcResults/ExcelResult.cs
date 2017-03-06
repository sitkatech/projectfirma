/*-----------------------------------------------------------------------
<copyright file="ExcelResult.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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
using System.IO;
using System.Web.Mvc;
using ClosedXML.Excel;

namespace LtInfo.Common.MvcResults
{
    public class ExcelResult : ActionResult
    {
        private readonly MemoryStream _memoryStream;
        private readonly string _fileName;

        public ExcelResult(XLWorkbook workbook, string fileName)
        {
            _fileName = fileName;
            _memoryStream = new MemoryStream();
            workbook.SaveAs(_memoryStream);
            _memoryStream.Seek(0, SeekOrigin.Begin);
        }

        public ExcelResult(MemoryStream memoryStream, string fileName)
        {
            _memoryStream = memoryStream;
            _fileName = fileName;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.Clear();
            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("content-disposition", string.Format("attachment;filename=\"{0}.xlsx\"", _fileName));
            using (_memoryStream)
            {
                _memoryStream.WriteTo(response.OutputStream);
            }
            response.End();
        }
    }
}
