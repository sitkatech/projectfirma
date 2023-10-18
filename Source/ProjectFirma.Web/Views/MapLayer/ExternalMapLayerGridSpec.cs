﻿/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.MapLayer
{
    public class ExternalMapLayerGridSpec : GridSpec<ProjectFirmaModels.Models.ExternalMapLayer>
    {
        public ExternalMapLayerGridSpec(bool userCanManage)
        {
            if (userCanManage)
            {
                Add("delete", x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, AgGridColumnFilterType.None);
                Add("edit", x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(x.GetEditUrl(), "Edit External Map Layer"), 30, AgGridColumnFilterType.None);
            }
            Add(FieldDefinitionEnum.ExternalMapLayerDisplayName.ToType().ToGridHeaderString(), x => x.DisplayName, 150);
            Add(FieldDefinitionEnum.ExternalMapLayerUrl.ToType().ToGridHeaderString(), x => x.LayerUrl, 250);
            Add(FieldDefinitionEnum.ExternalMapLayerDescription.ToType().ToGridHeaderString(), x => x.LayerDescription, 300);
            Add(FieldDefinitionEnum.ExternalMapLayerFeatureNameField.ToType().ToGridHeaderString(), x => x.FeatureNameField, 150);
//            Add("Display on all " + FieldDefinitionEnum.Project.ToType().FieldDefinitionDisplayName + " maps?", x => x.DisplayOnAllProjectMaps ? "Yes" : "No", 75);
            Add(FieldDefinitionEnum.ExternalMapLayerDisplayOnAllMaps.ToType().ToGridHeaderString(), x => x.DisplayOnAllProjectMaps ? "Yes" : "No", 75);
            Add(FieldDefinitionEnum.GeospatialAreaTypeOnByDefaultOnProjectMap.ToType().ToGridHeaderString(), x => x.LayerIsOnByDefault ? "Yes" : "No", 75);
            Add(FieldDefinitionEnum.ExternalMapLayerIsActive.ToType().ToGridHeaderString(), x => x.IsActive ? "Yes" : "No", 75);
            Add(FieldDefinitionEnum.ExternalMapLayerIsATiledMapService.ToType().ToGridHeaderString(), x => x.IsTiledMapService ? "Yes" : "No", 75);
        }
    }
}
