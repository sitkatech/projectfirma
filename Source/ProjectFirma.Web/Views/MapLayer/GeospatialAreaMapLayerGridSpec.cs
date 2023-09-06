/*-----------------------------------------------------------------------
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

using System.Collections.Generic;
using LtInfo.Common.AgGridWrappers;
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
            var areGeospatialAreasExternallySourced = MultiTenantHelpers.AreGeospatialAreasExternallySourced();
            if (userCanManage)
            {
                if (areGeospatialAreasExternallySourced)
                {
                    var cssClasses = new List<string> { "btn", "btn-xs", "btn-firma" };
                    Add(string.Empty,
                        x => AgGridHtmlHelpers.MakeModalDialogLink("Sync", x.GetSyncUrl(), 400, "Sync Data",
                            true, "Sync", "Cancel", cssClasses, null, null),
                        60, AgGridColumnFilterType.None);
                }
                Add("edit", x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(x.GetEditMapLayerUrl(), "Edit Geospatial Area Map Layer"), 30, AgGridColumnFilterType.None);
            }
            Add("Display Name", x => x.GeospatialAreaTypeNamePluralized, 250);
            Add(FieldDefinitionEnum.GeospatialAreaMapLayerDisplayAsReferenceLayer.ToType().ToGridHeaderString(), x => x.DisplayOnAllProjectMaps ? "Yes" : "No", 175);
            Add(FieldDefinitionEnum.GeospatialAreaTypeOnByDefaultOnProjectMap.ToType().ToGridHeaderString(), x => x.OnByDefaultOnProjectMap ? "Yes" : "No", 175);
            if (areGeospatialAreasExternallySourced)
            {
                Add("Service Url", x => x.ServiceUrl, 450);
            }
        }
    }
}
