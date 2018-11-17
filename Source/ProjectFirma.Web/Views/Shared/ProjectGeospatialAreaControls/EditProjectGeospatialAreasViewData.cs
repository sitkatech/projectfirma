/*-----------------------------------------------------------------------
<copyright file="EditProjectGeospatialAreasViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls
{
    public class EditProjectGeospatialAreasViewData : FirmaViewData
    {
        public readonly EditProjectGeospatialAreasViewDataForAngular ViewDataForAngular;
        public readonly string EditProjectGeospatialAreasFormID;
        public readonly string EditProjectGeospatialAreasUrl;
        public readonly bool HasProjectLocationPoint;
        public readonly bool HasProjectLocationDetail;
        public readonly string SimplePointMarkerImg;

        public EditProjectGeospatialAreasViewData(Person currentPerson, MapInitJson mapInitJson, List<Models.GeospatialArea> geospatialAreasInViewModel, TenantAttribute tenantAttribute, string editProjectGeospatialAreasUrl, string editProjectGeospatialAreasFormID, bool hasProjectLocationPoint, bool hasProjectLocationDetail) : base(currentPerson)
        {
            ViewDataForAngular = new EditProjectGeospatialAreasViewDataForAngular(mapInitJson, geospatialAreasInViewModel, tenantAttribute);
            EditProjectGeospatialAreasFormID = editProjectGeospatialAreasFormID;
            EditProjectGeospatialAreasUrl = editProjectGeospatialAreasUrl;
            HasProjectLocationPoint = hasProjectLocationPoint;
            HasProjectLocationDetail = hasProjectLocationDetail;

            SimplePointMarkerImg = "https://api.tiles.mapbox.com/v3/marker/pin-s-marker+838383.png";
        }
    }

    public class EditProjectGeospatialAreasViewDataForAngular
    {
        public readonly MapInitJson MapInitJson;
        public readonly string FindGeospatialAreaByNameUrl;
        public readonly string TypeAheadInputId;
        public Dictionary<int, string> GeospatialAreaNameByID;
        public readonly string GeospatialAreaMapServiceLayerName;
        public readonly string MapServiceUrl;
        public readonly string GeospatialAreaFieldDefinitionLabel;

        public EditProjectGeospatialAreasViewDataForAngular(MapInitJson mapInitJson, List<Models.GeospatialArea> geospatialAreasInViewModel, TenantAttribute tenantAttribute)
        {
            MapInitJson = mapInitJson;
            FindGeospatialAreaByNameUrl = SitkaRoute<ProjectGeospatialAreaController>.BuildUrlFromExpression(c => c.FindGeospatialAreaByName(null));
            TypeAheadInputId = "geospatialAreaSearch";
            GeospatialAreaNameByID = geospatialAreasInViewModel.ToDictionary(x => x.GeospatialAreaID, x => x.GeospatialAreaName);
            GeospatialAreaMapServiceLayerName = geospatialAreasInViewModel.FirstOrDefault().GeospatialAreaType.GeospatialAreaLayerName;
            MapServiceUrl = geospatialAreasInViewModel.FirstOrDefault().GeospatialAreaType.MapServiceUrl;
            GeospatialAreaFieldDefinitionLabel =
                geospatialAreasInViewModel.FirstOrDefault().GeospatialAreaType.GeospatialAreaTypeName;
        }
    }
}
