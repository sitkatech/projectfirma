/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.ComponentModel;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.FirmaPage
{
    public class EditViewModel : FormViewModel
    {
        [DisplayName("Page Content")]
        public HtmlString FirmaPageContentHtmlString { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditViewModel()
        {
        }
        
        public EditViewModel(ProjectFirmaModels.Models.FirmaPage firmaPage)
        {
            FirmaPageContentHtmlString = firmaPage != null ? firmaPage.GetFirmaPageContentHtmlString() : null;
        }

        public void UpdateModel(ProjectFirmaModels.Models.FirmaPage firmaPage, DatabaseEntities databaseEntities)
        {
            // delete file resources for any images that are no longer referenced in the HTML
            var imagesToDelete = FirmaPageContentHtmlString == null
                ? firmaPage.FirmaPageImages.ToList()
                : firmaPage.FirmaPageImages.Where(x => !FirmaPageContentHtmlString.ToString().ContainsCaseInsensitive(x.FileResourceInfo.GetFileResourceGUIDAsString())).ToList();

            foreach (var image in imagesToDelete)
            {
                // will cascade delete the FirmaPageImage
                image.FileResourceInfo.DeleteFull(databaseEntities);
            }
            firmaPage.FirmaPageContentHtmlString = FirmaPageContentHtmlString == null || string.IsNullOrWhiteSpace(FirmaPageContentHtmlString.ToString()) ? null : FirmaPageContentHtmlString;
        }
    }
}
