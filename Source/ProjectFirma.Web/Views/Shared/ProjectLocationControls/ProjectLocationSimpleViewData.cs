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
using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectLocationSimpleViewData : FirmaViewData
    {
        public readonly ProjectLocationSimpleViewDataForAngular ViewDataForAngular;
        public readonly string MapFormID;

        public ProjectLocationSimpleViewData(Person currentPerson, MapInitJson mapInitJson,
            string findWatershedByNameUrl, TenantAttribute tenantAttribute, Feature currentFeature)
            : base(currentPerson)
        {
            ViewDataForAngular = new ProjectLocationSimpleViewDataForAngular(mapInitJson, findWatershedByNameUrl, tenantAttribute, currentFeature);
            MapFormID = "projectLocationSimpleForm";
        }
    }

    public class ProjectLocationSimpleViewDataForAngular
    {
        public readonly MapInitJson MapInitJson;
        public readonly string FindWatershedByNameUrl;
        public readonly string TypeAheadInputId;
        public readonly string WatershedFieldDefinitionLabel;
        public readonly string ProjectLocationFieldDefinitionLabel;
        public readonly string WatershedMapSericeLayerName;
        public readonly string MapServiceUrl;
        public readonly Feature CurrentFeature;
        public readonly string ProjectLocationAreaIDFromWatershedIDUrlTemplate;

        public ProjectLocationSimpleViewDataForAngular(MapInitJson mapInitJson, string findWatershedByNameUrl,
            TenantAttribute tenantAttribute, Feature currentFeature)
        {
            MapInitJson = mapInitJson;
            FindWatershedByNameUrl = findWatershedByNameUrl;
            TypeAheadInputId = "projectLocationSearch";
            WatershedFieldDefinitionLabel = Models.FieldDefinition.Watershed.GetFieldDefinitionLabel();
            ProjectLocationFieldDefinitionLabel = Models.FieldDefinition.ProjectLocation.GetFieldDefinitionLabel();
            WatershedMapSericeLayerName = tenantAttribute.WatershedLayerName;
            MapServiceUrl = tenantAttribute.MapServiceUrl;
            CurrentFeature = currentFeature;
            ProjectLocationAreaIDFromWatershedIDUrlTemplate =
                new UrlTemplate<int>(
                    SitkaRoute<ProjectLocationController>.BuildUrlFromExpression(
                        c => c.ProjectLocationAreaIDFromWatershedID(UrlTemplate.Parameter1Int))).UrlTemplateString;
        }
    }
}