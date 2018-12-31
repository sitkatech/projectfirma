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
        public GeospatialAreaType GeospatialAreaType { get; }
        public readonly EditProjectGeospatialAreasViewDataForAngular ViewDataForAngular;
        public readonly string EditProjectGeospatialAreasFormID;
        public readonly string EditProjectGeospatialAreasUrl;
        public readonly bool HasProjectLocationPoint;
        public readonly bool HasProjectLocationDetail;
        public readonly List<Models.GeospatialArea> GeospatialAreasContainingProjectSimpleLocation;
        public readonly string SimplePointMarkerImg;

        public EditProjectGeospatialAreasViewData(Person currentPerson, MapInitJson mapInitJson,
            List<Models.GeospatialArea> geospatialAreasInViewModel, string editProjectGeospatialAreasUrl,
            string editProjectGeospatialAreasFormID, bool hasProjectLocationPoint, bool hasProjectLocationDetail,
            GeospatialAreaType geospatialAreaType, List<Models.GeospatialArea> geospatialAreasContainingProjectSimpleLocation) : base(currentPerson)
        {
            GeospatialAreaType = geospatialAreaType;
            GeospatialAreasContainingProjectSimpleLocation = geospatialAreasContainingProjectSimpleLocation;

            ViewDataForAngular =
                new EditProjectGeospatialAreasViewDataForAngular(mapInitJson, geospatialAreasInViewModel,
                    geospatialAreaType, GeospatialAreasContainingProjectSimpleLocation);
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
        public readonly string GeospatialAreaTypeName;
        public readonly List<int> GeospatialAreasContainingProjectSimpleLocation;

        public EditProjectGeospatialAreasViewDataForAngular(MapInitJson mapInitJson, List<Models.GeospatialArea> geospatialAreasInViewModel, GeospatialAreaType geospatialAreaType, List<Models.GeospatialArea> geospatialAreasContainingProjectSimpleLocation)
        {
            MapInitJson = mapInitJson;
            FindGeospatialAreaByNameUrl = SitkaRoute<ProjectGeospatialAreaController>.BuildUrlFromExpression(c => c.FindGeospatialAreaByName(geospatialAreaType, null));
            TypeAheadInputId = "geospatialAreaSearch";
            GeospatialAreaNameByID = geospatialAreasInViewModel.ToDictionary(x => x.GeospatialAreaID, x => x.GeospatialAreaName);
            GeospatialAreaMapServiceLayerName = geospatialAreaType.GeospatialAreaLayerName;
            MapServiceUrl = geospatialAreaType.MapServiceUrl;
            GeospatialAreaTypeName = geospatialAreaType.GeospatialAreaTypeName;
            GeospatialAreasContainingProjectSimpleLocation = geospatialAreasContainingProjectSimpleLocation.Select(x => x.GeospatialAreaID).ToList();
        }
    }
}
