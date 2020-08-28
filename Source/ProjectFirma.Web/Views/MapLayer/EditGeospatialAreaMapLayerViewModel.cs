/*-----------------------------------------------------------------------
<copyright file="EditGeospatialAreaMapLayerViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.MapLayer
{
    public class EditGeospatialAreaMapLayerViewModel : FormViewModel
    {
        public int GeospatialAreaTypeID { get; set; }

        [Required]
        [DisplayName("Display on all maps?")]
        public bool DisplayOnAllMaps { get; set; }

        [Required]
        [DisplayName("Layer is on by default?")]
        public bool LayerIsOnByDefault { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditGeospatialAreaMapLayerViewModel()
        {
        }

        public EditGeospatialAreaMapLayerViewModel(ProjectFirmaModels.Models.GeospatialAreaType geospatialAreaType)
        {
            GeospatialAreaTypeID = geospatialAreaType.GeospatialAreaTypeID;
            DisplayOnAllMaps = geospatialAreaType.DisplayOnAllProjectMaps;
            LayerIsOnByDefault = geospatialAreaType.LayerIsOnByDefault;
        }

        public void UpdateModel(ProjectFirmaModels.Models.GeospatialAreaType geospatialAreaType)
        {
            geospatialAreaType.DisplayOnAllProjectMaps = DisplayOnAllMaps;
            geospatialAreaType.LayerIsOnByDefault = LayerIsOnByDefault;
        }

    }
}
