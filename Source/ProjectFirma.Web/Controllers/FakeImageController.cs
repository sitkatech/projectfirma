/*-----------------------------------------------------------------------
<copyright file="FileResourceController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using System.IO;
using System.Web.Mvc;
using ProjectFirma.Web.Security.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Controllers
{
    public class FakeImageController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        public ActionResult ReturnEmptyImageAfterDelayInMilliseconds(int millisecondDelay)
        {
            System.Threading.Thread.Sleep(millisecondDelay);

            // No need to dispose the stream, MVC does it for you
            const string transparentFilenamePng = "1x1_transparent.png";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/img", transparentFilenamePng);
            FileStream stream = new FileStream(path, FileMode.Open);
            FileStreamResult result = new FileStreamResult(stream, "image/png");
            result.FileDownloadName = transparentFilenamePng;
            return result;
        }
    }
}