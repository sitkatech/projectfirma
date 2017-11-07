/*-----------------------------------------------------------------------
<copyright file="EditProjectWatershedsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirma.Web.Views.Shared.ProjectWatershedControls
{
    public class EditProjectWatershedsViewData : FirmaViewData
    {
        public readonly EditProjectWatershedsViewDataForAngular ViewDataForAngular;
        public readonly string EditProjectWatershedsFormID;
        public readonly string EditProjectWatershedsUrl;
        public readonly bool HasProjectLocationPoint;
        public readonly bool HasProjectLocationDetail;
        public readonly string SimplePointMarkerImg;

        public EditProjectWatershedsViewData(Person currentPerson, MapInitJson mapInitJson, List<Models.Watershed> watershedsInViewModel, TenantAttribute tenantAttribute, string editProjectWatershedsUrl, string editProjectWatershedsFormID, bool hasProjectLocationPoint, bool hasProjectLocationDetail) : base(currentPerson)
        {
            ViewDataForAngular = new EditProjectWatershedsViewDataForAngular(mapInitJson, watershedsInViewModel, tenantAttribute);
            EditProjectWatershedsFormID = editProjectWatershedsFormID;
            EditProjectWatershedsUrl = editProjectWatershedsUrl;
            HasProjectLocationPoint = hasProjectLocationPoint;
            HasProjectLocationDetail = hasProjectLocationDetail;

            SimplePointMarkerImg = "https://api.tiles.mapbox.com/v3/marker/pin-s-marker+838383.png";
        }
    }

    public class EditProjectWatershedsViewDataForAngular
    {
        public readonly MapInitJson MapInitJson;
        public readonly string FindWatershedByNameUrl;
        public readonly string TypeAheadInputId;
        public Dictionary<int, string> WatershedNameByID;
        public readonly string WatershedMapServiceLayerName;
        public readonly string MapServiceUrl;
        public readonly string WatershedFieldDefinitionLabel;

        public EditProjectWatershedsViewDataForAngular(MapInitJson mapInitJson, List<Models.Watershed> watershedsInViewModel, TenantAttribute tenantAttribute)
        {
            MapInitJson = mapInitJson;
            FindWatershedByNameUrl = SitkaRoute<ProjectWatershedController>.BuildUrlFromExpression(c => c.FindWatershedByName(null));
            TypeAheadInputId = "watershedSearch";
            WatershedNameByID = watershedsInViewModel.ToDictionary(x => x.WatershedID, x => x.WatershedName);
            WatershedMapServiceLayerName = tenantAttribute.WatershedLayerName;
            MapServiceUrl = tenantAttribute.MapServiceUrl;
            WatershedFieldDefinitionLabel = Models.FieldDefinition.Watershed.GetFieldDefinitionLabel();
        }
    }
}
