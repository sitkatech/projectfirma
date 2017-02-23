/*-----------------------------------------------------------------------
<copyright file="CsvDownloadResult.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Text;
using System.Web.Mvc;
using LtInfo.Common.Views;

namespace LtInfo.Common.MvcResults
{
    public class CsvDownloadResult : ActionResult
    {
        public CsvDownloadResult(DownloadFileDescriptor fileDescriptor, string csv)
        {
            CsvContents = csv;
            FileDescriptor = fileDescriptor;
        }

        public string CsvContents { get; set; }
        public DownloadFileDescriptor FileDescriptor { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var encoding = Encoding.UTF8;
            ViewUtilities.SetupHttpHeadersForDownload(context.HttpContext.Response, FileDescriptor, encoding);
            //var preamble = encoding.GetPreamble();
            var csvBytes = encoding.GetBytes(CsvContents);
            //context.HttpContext.Response.BinaryWrite(preamble);
            context.HttpContext.Response.BinaryWrite(csvBytes);
        }
    }
}
