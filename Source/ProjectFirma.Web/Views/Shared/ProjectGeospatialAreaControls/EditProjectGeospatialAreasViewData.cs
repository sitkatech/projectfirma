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
using ApprovalUtilities.Utilities;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls
{
    public class EditProjectGeospatialAreasViewData : FirmaViewData
    {
        public GeospatialAreaType GeospatialAreaType { get; }
        public EditProjectGeospatialAreasViewDataForAngular ViewDataForAngular { get; }
        public string EditProjectGeospatialAreasFormID { get; }
        public string EditProjectGeospatialAreasUrl { get; }
        public bool HasProjectLocationPoint { get; }
        public bool HasProjectLocationDetail { get; }
        public List<ProjectFirmaModels.Models.GeospatialArea> GeospatialAreaIDsContainingProjectSimpleLocation { get; }
        public string SimplePointMarkerImg { get; }
        public string EditSimpleLocationUrl { get; }

        public EditProjectGeospatialAreasViewData(FirmaSession currentFirmaSession, MapInitJson mapInitJson,
            List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreasInViewModel, string editProjectGeospatialAreasUrl,
            string editProjectGeospatialAreasFormID, bool hasProjectLocationPoint, bool hasProjectLocationDetail,
            GeospatialAreaType geospatialAreaType, List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreasContainingProjectSimpleLocation, string editSimpleLocationUrl) : base(currentFirmaSession)
        {
            GeospatialAreaType = geospatialAreaType;
            GeospatialAreaIDsContainingProjectSimpleLocation = geospatialAreasContainingProjectSimpleLocation;

            ViewDataForAngular =
                new EditProjectGeospatialAreasViewDataForAngular(mapInitJson, geospatialAreasInViewModel,
                    geospatialAreaType, geospatialAreasContainingProjectSimpleLocation, hasProjectLocationPoint);
            EditProjectGeospatialAreasFormID = editProjectGeospatialAreasFormID;
            EditProjectGeospatialAreasUrl = editProjectGeospatialAreasUrl;
            HasProjectLocationPoint = hasProjectLocationPoint;
            HasProjectLocationDetail = hasProjectLocationDetail;

            SimplePointMarkerImg = "https://api.tiles.mapbox.com/v3/marker/pin-s-marker+838383.png";

            EditSimpleLocationUrl = editSimpleLocationUrl;
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
        public readonly List<int> GeospatialAreaIDsContainingProjectSimpleLocation;
        public readonly bool HasProjectLocationPoint;

        public EditProjectGeospatialAreasViewDataForAngular(MapInitJson mapInitJson,
            List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreasInViewModel, GeospatialAreaType geospatialAreaType,
            List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreasContainingProjectSimpleLocation, bool hasProjectLocationPoint)
        {
            MapInitJson = mapInitJson;
            FindGeospatialAreaByNameUrl =
                SitkaRoute<ProjectGeospatialAreaController>.BuildUrlFromExpression(c =>
                    c.FindGeospatialAreaByName(geospatialAreaType, null));
            TypeAheadInputId = "geospatialAreaSearch";
            
            GeospatialAreaMapServiceLayerName = geospatialAreaType.GeospatialAreaLayerName;
            MapServiceUrl = geospatialAreaType.MapServiceUrl();
            GeospatialAreaTypeName = geospatialAreaType.GeospatialAreaTypeName;

            GeospatialAreaNameByID =
                geospatialAreasInViewModel.ToDictionary(x => x.GeospatialAreaID, x => x.GeospatialAreaName);

            GeospatialAreaNameByID.AddAll(
                geospatialAreasContainingProjectSimpleLocation
                    .Where(x => !GeospatialAreaNameByID.ContainsKey(x.GeospatialAreaID)).ToDictionary(
                        x => x.GeospatialAreaID,
                        x => x.GeospatialAreaName));

            GeospatialAreaIDsContainingProjectSimpleLocation = geospatialAreasContainingProjectSimpleLocation
                .Select(x => x.GeospatialAreaID).ToList();

            HasProjectLocationPoint = hasProjectLocationPoint;
        }
    }
}
