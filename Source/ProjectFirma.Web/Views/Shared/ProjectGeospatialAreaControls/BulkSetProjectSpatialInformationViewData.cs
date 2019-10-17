using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using ApprovalUtilities.Utilities;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls
{
    public class BulkSetProjectSpatialInformationViewData : FirmaViewData
    {
        public DbGeometry ProjectSimpleLocation { get; }
        public List<GeospatialAreaType> GeospatialAreaTypes { get; }
        public string EditProjectGeospatialAreasUrl { get; }
        public BulkSetProjectSpatialInformationViewDataForAngular ViewDataForAngular { get; }
        public string EditProjectGeospatialAreasFormID { get; }
        public bool HasProjectLocationPoint { get; }
        public bool HasProjectLocationDetail { get; }
        public string SimplePointMarkerImg { get; }

        public BulkSetProjectSpatialInformationViewData(Person currentPerson, 
                                                         ProjectFirmaModels.Models.Project project, 
                                                         List<GeospatialAreaType> geospatialAreaTypes, 
                                                         MapInitJson mapInitJson, 
                                                         string editProjectGeospatialAreasUrl, 
                                                         string editProjectGeospatialAreasFormID, 
                                                         List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreasContainingProjectSimpleLocation, 
                                                         bool hasProjectLocationPoint, 
                                                         bool hasProjectLocationDetail) : base(currentPerson)
        {
            ProjectSimpleLocation = project.ProjectLocationPoint;
            GeospatialAreaTypes = geospatialAreaTypes;
            EditProjectGeospatialAreasUrl = editProjectGeospatialAreasUrl;
            EditProjectGeospatialAreasFormID = editProjectGeospatialAreasFormID;
            HasProjectLocationPoint = hasProjectLocationPoint;
            HasProjectLocationDetail = hasProjectLocationDetail;
            SimplePointMarkerImg = "https://api.tiles.mapbox.com/v3/marker/pin-s-marker+838383.png";

            ViewDataForAngular = new BulkSetProjectSpatialInformationViewDataForAngular(mapInitJson, geospatialAreaTypes, geospatialAreasContainingProjectSimpleLocation, hasProjectLocationPoint);
        }
    }


    public class BulkSetProjectSpatialInformationViewDataForAngular
    {
        public MapInitJson MapInitJson { get; }
        public string MapServiceUrl { get; }
        public List<GeospatialAreaTypeSimple> GeospatialAreaTypes { get; }
        public List<int> GeospatialAreaIDsContainingProjectSimpleLocation { get; }
        public bool HasProjectLocationPoint { get; }
        public Dictionary<int, string> GeospatialAreaNameByID { get; }

        public BulkSetProjectSpatialInformationViewDataForAngular(MapInitJson mapInitJson, 
                                                                  List<GeospatialAreaType> geospatialAreaTypes, 
                                                                  List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreasContainingProjectSimpleLocation, 
                                                                  bool hasProjectLocationPoint)
        {
            MapInitJson = mapInitJson;

            MapServiceUrl = geospatialAreaTypes.FirstOrDefault().MapServiceUrl;
            GeospatialAreaTypes = geospatialAreaTypes.OrderBy(gat => gat.GeospatialAreaTypeName).Select(x => new GeospatialAreaTypeSimple(x, geospatialAreasContainingProjectSimpleLocation.Where(gacpsl => gacpsl.GeospatialAreaTypeID == x.GeospatialAreaTypeID).Select(y => y.GeospatialAreaID).ToList())).ToList();

            GeospatialAreaIDsContainingProjectSimpleLocation = geospatialAreasContainingProjectSimpleLocation.Select(x => x.GeospatialAreaID).ToList();

            HasProjectLocationPoint = hasProjectLocationPoint;

            GeospatialAreaNameByID = geospatialAreasContainingProjectSimpleLocation.ToDictionary(x => x.GeospatialAreaID, y => y.GeospatialAreaName);
        }
    }

    public class GeospatialAreaTypeSimple
    {

        public int GeospatialAreaTypeID { get; }
        public string GeospatialAreaTypeName { get; }
        public string GeospatialAreaTypeNamePluralized { get; }
        public string GeospatialAreaTypeLayerName { get; }
        public string GeospatialAreaTypeMapServiceUrl { get; }
        public List<int> GeospatialAreaIDsContainingProjectSimpleLocation { get; }

        public GeospatialAreaTypeSimple(GeospatialAreaType geospatialAreaType)
        {
            GeospatialAreaTypeID = geospatialAreaType.GeospatialAreaTypeID;
            GeospatialAreaTypeName = geospatialAreaType.GeospatialAreaTypeName;
            GeospatialAreaTypeNamePluralized = geospatialAreaType.GeospatialAreaTypeNamePluralized;
            GeospatialAreaTypeLayerName = geospatialAreaType.GeospatialAreaLayerName;
            GeospatialAreaTypeMapServiceUrl = geospatialAreaType.MapServiceUrl;
        }

        public GeospatialAreaTypeSimple(GeospatialAreaType geospatialAreaType, List<int> geospatialAreaIDsContainingProjectSimpleLocation) : this(geospatialAreaType)
        {
            GeospatialAreaIDsContainingProjectSimpleLocation = geospatialAreaIDsContainingProjectSimpleLocation;
        }
    }
}
