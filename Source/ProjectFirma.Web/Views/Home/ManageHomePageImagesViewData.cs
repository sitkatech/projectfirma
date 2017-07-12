/*-----------------------------------------------------------------------
<copyright file="FeaturedProjectsViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Home
{
    public class ManageHomePageImagesViewData : FirmaViewData
    {
        public readonly List<Models.FirmaHomePageImage> ManageHomePageImages;

        public ManageHomePageImagesViewData(Person currentPerson, List<Models.FirmaHomePageImage> firmaHomePageImages, ImageGalleryViewData imageGalleryViewData) : base(currentPerson)
        {
            ManageHomePageImages = firmaHomePageImages;
            ImageGalleryViewData = imageGalleryViewData;
        }

        public readonly ImageGalleryViewData ImageGalleryViewData;
    }
}
