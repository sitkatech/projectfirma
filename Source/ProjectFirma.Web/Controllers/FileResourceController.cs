/*-----------------------------------------------------------------------
<copyright file="FileResourceController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Security.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class FileResourceController : FirmaBaseController
    {
        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        public ActionResult DisplayResource(string fileResourceGuidAsString)
        {
            Guid fileResourceGuid;
            var isStringAGuid = Guid.TryParse(fileResourceGuidAsString, out fileResourceGuid);
            if (isStringAGuid)
            {
                var fileResourceInfo = HttpRequestStorage.DatabaseEntities.FileResourceInfos.SingleOrDefault(x => x.FileResourceGUID == fileResourceGuid);

                return DisplayResourceImpl(fileResourceGuidAsString, fileResourceInfo);
            }
            // Unhappy path - return an HTTP 404
            // ---------------------------------
            var message = $"File Resource {fileResourceGuidAsString} Not Found in database. It may have been deleted.";
            throw new HttpException(404, message);
        }

        private ActionResult DisplayResourceImpl(string fileResourceInfoPrimaryKey, FileResourceInfo fileResourceInfo)
        {
            if (fileResourceInfo == null)
            {
                var message = $"File Resource {fileResourceInfoPrimaryKey} Not Found in database. It may have been deleted.";
                throw new HttpException(404, message);
            }

            // If you're adding new mime types to the system, you need to add them below -- 08/29/2019 SMG
            // Removed PDFResult & ExcelResult and just ran both through the FileResourceResult to fix bugs occurring - both PDF & Excel work fine/better with FileResourceResult -- 6/15/2020 MZ
            switch (fileResourceInfo.FileResourceMimeType.ToEnum)
            {
                case FileResourceMimeTypeEnum.PDF:
                case FileResourceMimeTypeEnum.ExcelXLS:
                case FileResourceMimeTypeEnum.ExcelXLSX:
                case FileResourceMimeTypeEnum.xExcelXLSX:
                case FileResourceMimeTypeEnum.WordDOCX:
                case FileResourceMimeTypeEnum.WordDOC:
                case FileResourceMimeTypeEnum.PowerpointPPTX:
                case FileResourceMimeTypeEnum.PowerpointPPT:
                case FileResourceMimeTypeEnum.CSS:
                case FileResourceMimeTypeEnum.KMZ:
                case FileResourceMimeTypeEnum.KML:
                case FileResourceMimeTypeEnum.XZIP:
                case FileResourceMimeTypeEnum.ZIP:
                    return new FileResourceResult(fileResourceInfo.GetOriginalCompleteFileName(), fileResourceInfo.FileResourceData.Data, fileResourceInfo.FileResourceMimeType);
                case FileResourceMimeTypeEnum.XPNG:
                case FileResourceMimeTypeEnum.PNG:
                case FileResourceMimeTypeEnum.TIFF:
                case FileResourceMimeTypeEnum.BMP:
                case FileResourceMimeTypeEnum.GIF:
                case FileResourceMimeTypeEnum.JPEG:
                case FileResourceMimeTypeEnum.PJPEG:
                    return File(fileResourceInfo.FileResourceData.Data, fileResourceInfo.FileResourceMimeType.FileResourceMimeTypeName);
                default:
                    // throw a more specific error that can hint to developers and assure users what needs to be done when adding a new mime type
                    throw new SitkaDisplayErrorException($"The file type \"{fileResourceInfo.FileResourceMimeType.FileResourceMimeTypeDisplayName}\" has not been explicitly whitelisted to download. The development team has been notified, if you continue to receive errors, please contact support.");
            }
        }

        [LoggedInUnclassifiedFeature]
        [CrossAreaRoute]
        public ActionResult DisplayResourceByID(FileResourceInfoPrimaryKey fileResourceInfoPrimaryKey)
        {
            var fileResourceInfo = fileResourceInfoPrimaryKey.EntityObject;
            return DisplayResourceImpl(fileResourceInfoPrimaryKey.PrimaryKeyValue.ToString(), fileResourceInfo);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        public ActionResult GetFileResourceResized(string fileResourceGuidAsString, int maxWidth, int maxHeight)
        {
            Guid fileResourceGuid;
            var isStringAGuid = Guid.TryParse(fileResourceGuidAsString, out fileResourceGuid);
            if (isStringAGuid)
            {
                var fileResourceInfo = HttpRequestStorage.DatabaseEntities.FileResourceInfos.SingleOrDefault(x => x.FileResourceGUID == fileResourceGuid);
                if (fileResourceInfo != null)
                {
                    // Happy path - return the resource
                    // ---------------------------------
                    switch (fileResourceInfo.FileResourceMimeType.ToEnum)
                    {
                        case FileResourceMimeTypeEnum.ExcelXLS:
                        case FileResourceMimeTypeEnum.ExcelXLSX:
                        case FileResourceMimeTypeEnum.xExcelXLSX:
                        case FileResourceMimeTypeEnum.PDF:
                        case FileResourceMimeTypeEnum.WordDOCX:
                        case FileResourceMimeTypeEnum.WordDOC:
                        case FileResourceMimeTypeEnum.PowerpointPPTX:
                        case FileResourceMimeTypeEnum.PowerpointPPT:
                            throw new ArgumentOutOfRangeException($"Not supported mime type {fileResourceInfo.FileResourceMimeType.FileResourceMimeTypeDisplayName}");
                        case FileResourceMimeTypeEnum.XPNG:
                        case FileResourceMimeTypeEnum.PNG:
                        case FileResourceMimeTypeEnum.TIFF:
                        case FileResourceMimeTypeEnum.BMP:
                        case FileResourceMimeTypeEnum.GIF:
                        case FileResourceMimeTypeEnum.JPEG:
                        case FileResourceMimeTypeEnum.PJPEG:
                            using (var scaledImage = ImageHelper.ScaleImage(fileResourceInfo.FileResourceData.Data, maxWidth, maxHeight))
                            {
                                using (var ms = new MemoryStream())
                                {
                                    scaledImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    return File(ms.ToArray(), FileResourceMimeType.PNG.FileResourceMimeTypeName);
                                }
                            }
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            // Unhappy path - return an HTTP 404
            // ---------------------------------
            var message = $"File Resource {fileResourceGuidAsString} Not Found in database. It may have been deleted.";
            throw new HttpException(404, message);
        }
    }
}