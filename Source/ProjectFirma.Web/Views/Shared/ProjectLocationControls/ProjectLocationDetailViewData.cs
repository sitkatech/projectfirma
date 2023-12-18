/*-----------------------------------------------------------------------
<copyright file="ProjectLocationDetailViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectLocationDetailViewData : FirmaUserControlViewData
    {
        public int ProjectID { get; }
        public bool HasProjectLocationPoint { get; }
        public MapInitJson MapInitJson { get; }
        public LayerGeoJson EditableLayerGeoJson { get; }
        public string UploadGisFileUrl { get; }
        public string MapFormID { get; }
        public string SaveFeatureCollectionUrl { get; }
        public int AnnotationMaxLength { get; }
        public string SimplePointMarkerImg { get; }
        public bool LocationIsPrivate { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }


        public ProjectLocationDetailViewData(int projectID, MapInitJson mapInitJson, LayerGeoJson editableLayerGeoJson, string uploadGisFileUrl, 
            string mapFormID, string saveFeatureCollectionUrl, int annotationMaxLength, bool hasProjectLocationPoint, bool locationIsPrivate)
        {
            ProjectID = projectID;
            MapInitJson = mapInitJson;
            EditableLayerGeoJson = editableLayerGeoJson;
            UploadGisFileUrl = uploadGisFileUrl;
            MapFormID = mapFormID;
            SaveFeatureCollectionUrl = saveFeatureCollectionUrl;
            AnnotationMaxLength = annotationMaxLength;
            HasProjectLocationPoint = hasProjectLocationPoint;
            SimplePointMarkerImg = $"https://api.tiles.mapbox.com/v4/marker/pin-s-marker+838383.png?access_token={FirmaWebConfiguration.MapBoxApiKey}";
            LocationIsPrivate = locationIsPrivate;
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
        }
    }
}
