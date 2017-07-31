/*-----------------------------------------------------------------------
<copyright file="EditProjectLocationSimpleViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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

using GeoJSON.Net.Feature;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class EditProjectLocationSimpleViewData : FirmaViewData
    {
        public readonly MapInitJson MapInitJson;
        public readonly string MapFormID;
        public readonly string MapPostUrl;
        public readonly string ProjectLocationInformationContainer;
        public readonly string ProjectLocationAreaGeoJsonUrl;
        public readonly string WatershedMapServerLayerName;
        public readonly string MapServerUrl;
        public readonly string ProjectLocationAreaIDFromWatershedIDUrlTemplate;
        public readonly Feature InitiallySelectedProjectLocationFeature;

        public EditProjectLocationSimpleViewData(Person currentPerson, MapInitJson mapInitJson, string mapPostUrl,
            string mapFormID, string watershedMapServerLayerName, string mapServerUrl,
            Feature initiallySelectedProjectLocationFeature)
            : base(currentPerson)
        {
            MapInitJson = mapInitJson;
            MapPostUrl = mapPostUrl;
            MapFormID = mapFormID;
            ProjectLocationInformationContainer = $"{mapInitJson.MapDivID}LocationInformationContainer";
            ProjectLocationAreaGeoJsonUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.GetProjectLocationAreaGeoJson(null));
            ProjectLocationAreaIDFromWatershedIDUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(c => c.ProjectLocationAreaIDFromWatershedID(UrlTemplate.Parameter1Int))).UrlTemplateString;
            WatershedMapServerLayerName = watershedMapServerLayerName;
            MapServerUrl = mapServerUrl;
            InitiallySelectedProjectLocationFeature = initiallySelectedProjectLocationFeature;
        }
    }
}
