/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.MapLayer
{
    public class IndexViewData : FirmaViewData
    {
        public ExternalMapLayerGridSpec ExternalMapLayerGridSpec { get; }
        public string ExternalMapLayerGridName { get; }
        public string ExternalMapLayerGridDataUrl { get; }
        public string NewUrl { get; }
        public GeospatialAreaMapLayerGridSpec GeospatialAreaMapLayerGridSpec { get; }
        public string GeospatialAreaMapLayerGridName { get; }
        public string GeospatialAreaMapLayerGridDataUrl { get; }
        public bool UserCanManage { get; }


        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, string externalMapLayerGridDataUrl, string geospatialAreaMapLayerGridDataUrl, bool userCanManage)
            : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"{FieldDefinitionEnum.ExternalMapLayer.ToType().GetFieldDefinitionLabelPluralized()}";
            ExternalMapLayerGridSpec = new ExternalMapLayerGridSpec(userCanManage)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.ExternalMapLayer.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.ExternalMapLayer.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };
            ExternalMapLayerGridName = "externalMapLayersGrid";
            ExternalMapLayerGridDataUrl = externalMapLayerGridDataUrl;
            NewUrl = SitkaRoute<MapLayerController>.BuildUrlFromExpression(x => x.New());

            GeospatialAreaMapLayerGridSpec = new GeospatialAreaMapLayerGridSpec(userCanManage)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.GeospatialArea.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.GeospatialArea.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };
            GeospatialAreaMapLayerGridName = "geospatialAreaMapLayersGrid";
            GeospatialAreaMapLayerGridDataUrl = geospatialAreaMapLayerGridDataUrl;

            UserCanManage = userCanManage;

        }
    }
}
