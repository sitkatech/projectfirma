/*-----------------------------------------------------------------------
<copyright file="ImageGalleryViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class ImageGalleryViewData
    {
        public readonly Person CurrentPerson;
        public readonly string GalleryName;
        public readonly IEnumerable<IFileResourcePhoto> GalleryImages;
        public readonly string SelectKeyImageUrl;
        public readonly string AddNewPhotoUrl;
        public readonly bool UserCanAddPhotos;
        public readonly bool UserCanSelectKeyPhoto;
        public readonly int CurrentKeyPhotoID;
        public readonly bool IsGalleryMode;
        public readonly Func<IFileResourcePhoto, object> SortFunction;
        public readonly string ImageEntityName;

        public ImageGalleryViewData(Person currentPerson, string galleryName, IEnumerable<IFileResourcePhoto> galleryImages, bool canAddPhotos, string addNewPhotoUrl, string selectKeyImageUrl, bool isGalleryMode, Func<IFileResourcePhoto, object> sortFunction, string imageEntityName)
        {
            CurrentPerson = currentPerson;
            GalleryImages = galleryImages.ToList();
            UserCanAddPhotos = canAddPhotos;
            SelectKeyImageUrl = selectKeyImageUrl;
            AddNewPhotoUrl = addNewPhotoUrl;
            GalleryName = galleryName;
            UserCanSelectKeyPhoto = !string.IsNullOrWhiteSpace(selectKeyImageUrl);
            CurrentKeyPhotoID = (UserCanSelectKeyPhoto && GalleryImages.Any(x => x.IsKeyPhoto)) ? GalleryImages.Single(x => x.IsKeyPhoto).PrimaryKey : ModelObjectHelpers.NotYetAssignedID;
            IsGalleryMode = isGalleryMode;
            SortFunction = sortFunction;
            ImageEntityName = imageEntityName;
        }
    }
}
