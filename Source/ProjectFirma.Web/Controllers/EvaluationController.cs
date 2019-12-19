/*-----------------------------------------------------------------------
<copyright file="EvaluationController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirma.Web.Controllers
{
    public class EvaluationController : FirmaBaseController
    {

        //[GeospatialAreaViewFeature]
        //public ViewResult Index(GeospatialAreaTypePrimaryKey geospatialAreaTypePrimaryKey)
        //{
        //    var geospatialAreaType = geospatialAreaTypePrimaryKey.EntityObject;
        //    var layerGeoJsons = new List<LayerGeoJson>();
        //    layerGeoJsons = new List<LayerGeoJson>
        //    {
        //        geospatialAreaType.GetGeospatialAreaWmsLayerGeoJson("#59ACFF", 0.2m, LayerInitialVisibility.Show)
        //    };

        //    var mapInitJson = new MapInitJson("geospatialAreaIndex", 10, layerGeoJsons, MapInitJson.GetExternalMapLayers(), BoundingBox.MakeNewDefaultBoundingBox());

        //    var viewData = new IndexViewData(CurrentFirmaSession, geospatialAreaType, mapInitJson);
        //    return RazorView<Index, IndexViewData>(viewData);
        //}

        public void IndexGridJsonData()
        {
            throw new System.NotImplementedException();
        }
    }
}
