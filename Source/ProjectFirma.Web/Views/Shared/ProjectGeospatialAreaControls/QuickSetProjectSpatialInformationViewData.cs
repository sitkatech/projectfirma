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
    public class QuickSetProjectSpatialInformationViewData : FirmaViewData
    {
        //public ProjectFirmaModels.Models.Project Project { get; set; }
        public DbGeometry ProjectSimpleLocation { get; }
        public List<GeospatialAreaType> GeospatialAreaTypes { get; }
        public string EditProjectGeospatialAreasUrl { get; }


        public QuickSetProjectSpatialInformationViewDataForAngular ViewDataForAngular { get; }
        public string EditProjectGeospatialAreasFormID { get; }
        public bool HasProjectLocationPoint { get; }
        public bool HasProjectLocationDetail { get; }
        public List<ProjectFirmaModels.Models.GeospatialArea> GeospatialAreaIDsContainingProjectSimpleLocation { get; }
        public string SimplePointMarkerImg { get; }

        public QuickSetProjectSpatialInformationViewData(Person currentPerson, 
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
            GeospatialAreaIDsContainingProjectSimpleLocation = geospatialAreasContainingProjectSimpleLocation;
            SimplePointMarkerImg = "https://api.tiles.mapbox.com/v3/marker/pin-s-marker+838383.png";
            ViewDataForAngular = new QuickSetProjectSpatialInformationViewDataForAngular(mapInitJson, geospatialAreaTypes, geospatialAreasContainingProjectSimpleLocation, hasProjectLocationPoint);
        }

    }


    public class QuickSetProjectSpatialInformationViewDataForAngular
    {
        public MapInitJson MapInitJson { get; }
        //public string FindGeospatialAreaByNameUrl { get; }

        //public string GeospatialAreaMapServiceLayerName { get; }
        public string MapServiceUrl { get; }
        public List<GeospatialAreaTypeSimple> GeospatialAreaTypes { get; }
        public List<int> GeospatialAreaIDsContainingProjectSimpleLocation { get; }
        public bool HasProjectLocationPoint { get; }

        public QuickSetProjectSpatialInformationViewDataForAngular(MapInitJson mapInitJson,
                                                                   //List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreasInViewModel, 
                                                                   List<GeospatialAreaType> geospatialAreaTypes, 
                                                                   List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreasContainingProjectSimpleLocation, 
                                                                   bool hasProjectLocationPoint)
        {
            MapInitJson = mapInitJson;
            //FindGeospatialAreaByNameUrl = SitkaRoute<ProjectGeospatialAreaController>.BuildUrlFromExpression(c => c.FindGeospatialAreaByName(geospatialAreaType, null));

            //GeospatialAreaMapServiceLayerName = geospatialAreaType.GeospatialAreaLayerName;
            MapServiceUrl = geospatialAreaTypes.FirstOrDefault().MapServiceUrl;
            GeospatialAreaTypes = geospatialAreaTypes.Select(x => new GeospatialAreaTypeSimple(x)).ToList();

            GeospatialAreaIDsContainingProjectSimpleLocation = geospatialAreasContainingProjectSimpleLocation.Select(x => x.GeospatialAreaID).ToList();

            HasProjectLocationPoint = hasProjectLocationPoint;
        }
    }

    public class GeospatialAreaTypeSimple
    {

        public int GeospatialAreaTypeID { get; }
        public string GeospatialAreaTypeName { get; }
        public string GeospatialAreaTypeNamePluralized { get; }
        public string GeospatialAreaTypeLayerName { get; }

        public GeospatialAreaTypeSimple(GeospatialAreaType geospatialAreaType)
        {
            GeospatialAreaTypeID = geospatialAreaType.GeospatialAreaTypeID;
            GeospatialAreaTypeName = geospatialAreaType.GeospatialAreaTypeName;
            GeospatialAreaTypeNamePluralized = geospatialAreaType.GeospatialAreaTypeNamePluralized;
            GeospatialAreaTypeLayerName = geospatialAreaType.GeospatialAreaLayerName;
        }
    }
}
