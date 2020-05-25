/*-----------------------------------------------------------------------
<copyright file="FileResource.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.IO;
using System.Linq;
using LtInfo.Common;

namespace ProjectFirmaModels.Models
{
    public partial class FileResource : IAuditableEntity
    {
        public FileResourceData FileResourceData => FileResourceDatas.First();

        private Jpeg _photo;
        private bool _hasCheckedPhoto;

        public int GetImageWidth()
        {
            if (!_hasCheckedPhoto)
            {
                PopulateFileResourceDataAsImage();
            }

            return _photo.Width;
        }

        private void PopulateFileResourceDataAsImage()
        {
            var fileResourceDataAsMemoryStream = new MemoryStream(FileResourceData.Data);
            _photo = new Jpeg(new System.Drawing.Bitmap(fileResourceDataAsMemoryStream));
            _hasCheckedPhoto = true;
        }

        public int GetImageHeight()
        {
            if (!_hasCheckedPhoto)
            {
                PopulateFileResourceDataAsImage();
            }

            return _photo.Height;
        }

        public FileResourceOrientation GetOrientation()
        {
            return GetImageHeight() >= GetImageWidth() ? FileResourceOrientation.Portrait : FileResourceOrientation.Landscape;
        }

        public string GetFullGuidBasedFilename()
        {
            return $"{FileResourceGUID}{OriginalFileExtension}";
        }

        public string GetOriginalCompleteFileName()
        {
            return $"{OriginalBaseFilename}{OriginalFileExtension}";
        }

        public string GetAuditDescriptionString()
        {
            return $"{GetOriginalCompleteFileName()}";
        }

        public string GetFileResourceGUIDAsString()
        {
            return FileResourceGUID.ToString();
        }
    }
}
