/*-----------------------------------------------------------------------
<copyright file="EditGeospatialAreaDescriptionViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.GeospatialArea
{
    public class EditGeospatialAreaDescriptionViewModel : FormViewModel
    {
        [DisplayName("Page Content")]
        public HtmlString GeospatialAreaDescriptionContentHtmlString { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditGeospatialAreaDescriptionViewModel()
        {
        }
        
        public EditGeospatialAreaDescriptionViewModel(ProjectFirmaModels.Models.GeospatialArea geospatialArea)
        {
            GeospatialAreaDescriptionContentHtmlString = geospatialArea?.GeospatialAreaDescriptionContentHtmlString;
        }

        public void UpdateModel(ProjectFirmaModels.Models.GeospatialArea geospatialArea)
        {
            geospatialArea.GeospatialAreaDescriptionContentHtmlString = GeospatialAreaDescriptionContentHtmlString == null || string.IsNullOrWhiteSpace(GeospatialAreaDescriptionContentHtmlString.ToString()) ? null : GeospatialAreaDescriptionContentHtmlString;
        }
    }
}
