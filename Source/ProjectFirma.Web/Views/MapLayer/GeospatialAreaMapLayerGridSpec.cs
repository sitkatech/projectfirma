/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.MapLayer
{
    public class GeospatialAreaMapLayerGridSpec : GridSpec<ProjectFirmaModels.Models.GeospatialAreaType>
    {
        public GeospatialAreaMapLayerGridSpec(bool userCanManage)
        {
            if (userCanManage)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(x.GetEditMapLayerUrl(), "Edit Geospatial Area Map Layer"), 30, DhtmlxGridColumnFilterType.None);
            }
            Add("Display Name", x => x.GeospatialAreaTypeNamePluralized, 250);
            Add(FieldDefinitionEnum.MapLayerDisplayOnAllMaps.ToType().ToGridHeaderString(), x => x.DisplayOnAllProjectMaps ? "Yes" : "No", 175);
            Add(FieldDefinitionEnum.MapLayerLayerIsOnByDefault.ToType().ToGridHeaderString(), x => x.LayerIsOnByDefault ? "Yes" : "No", 175);
        }
    }
}
