/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.MapLayer
{
    public class IndexViewData : FirmaViewData
    {
        public ExternalMapLayerGridSpec ExternalMapLayerGridSpec { get; }
        public string ExternalMapLayerGridName { get; }
        public string ExternalMapLayerGridDataUrl { get; }
        public string NewUrl { get; }
        public ViewPageContentViewData InternalMapLayersViewPageContentViewData { get; }
        public bool AreGeospatialAreasExternallySourced { get; }
        public ViewPageContentViewData ExternallySourcedGeospatialAreasInstructionsViewPageContentViewData { get; }
        public GeospatialAreaMapLayerGridSpec GeospatialAreaMapLayerGridSpec { get; }
        public string GeospatialAreaMapLayerGridName { get; }
        public string GeospatialAreaMapLayerGridDataUrl { get; }
        public bool UserCanManage { get; }


        public IndexViewData(FirmaSession currentFirmaSession, 
            ProjectFirmaModels.Models.FirmaPage externalMapLayersFirmaPage, string externalMapLayerGridDataUrl,
            ProjectFirmaModels.Models.FirmaPage internalMapLayersFirmaPage, string geospatialAreaMapLayerGridDataUrl, 
            ProjectFirmaModels.Models.FirmaPage externallySourcedGeospatialAreasInstructionsFirmaPage, bool userCanManage)
            : base(currentFirmaSession, externalMapLayersFirmaPage)
        {
            PageTitle = $"{FieldDefinitionEnum.GeospatialArea.ToType().GetFieldDefinitionLabelPluralized()}";
            ExternalMapLayerGridSpec = new ExternalMapLayerGridSpec(userCanManage)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.ExternalReferenceLayer.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.ExternalReferenceLayer.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };
            ExternalMapLayerGridName = "externalMapLayersGrid";
            ExternalMapLayerGridDataUrl = externalMapLayerGridDataUrl;
            NewUrl = SitkaRoute<MapLayerController>.BuildUrlFromExpression(x => x.New());

            var currentPersonCanManage = new FirmaPageManageFeature().HasPermission(currentFirmaSession).HasPermission;
            InternalMapLayersViewPageContentViewData = new ViewPageContentViewData(internalMapLayersFirmaPage, currentPersonCanManage);

            AreGeospatialAreasExternallySourced = MultiTenantHelpers.AreGeospatialAreasExternallySourced();
            ExternallySourcedGeospatialAreasInstructionsViewPageContentViewData = new ViewPageContentViewData(externallySourcedGeospatialAreasInstructionsFirmaPage, currentPersonCanManage);

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
