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
using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class EditProjectLocationSimpleViewData : FirmaViewData
    {
        public readonly IEnumerable<SelectListItem> ProjectLocationSelectListItems;
        public readonly MapInitJson MapInitJson;
        public readonly string MapFormID;
        public readonly string MapPostUrl;
        public readonly string ProjectLocationInformationContainer;
        public readonly string ProjectLocationAreaGeoJsonUrl;
        public readonly string GeoserverUrl;
        public readonly string WatershedLayerName;

        public EditProjectLocationSimpleViewData(Person currentPerson, MapInitJson mapInitJson,
            IEnumerable<SelectListItem> projectLocationSelectListItems, string mapPostUrl, string mapFormID,
            string geoserverUrl, string watershedLayerName)
            : base(currentPerson)
        {
            MapInitJson = mapInitJson;
            ProjectLocationSelectListItems = projectLocationSelectListItems;
            MapPostUrl = mapPostUrl;
            MapFormID = mapFormID;
            ProjectLocationInformationContainer = $"{mapInitJson.MapDivID}LocationInformationContainer";
            ProjectLocationAreaGeoJsonUrl = SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(x => x.GetProjectLocationAreaGeoJson(null));
            GeoserverUrl = geoserverUrl;
            WatershedLayerName = watershedLayerName;
        }
    }
}
